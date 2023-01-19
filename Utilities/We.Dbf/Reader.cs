//@see https://www.dbf2002.com/dbf-file-format.html

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace We.Dbf;
public class DbfDocument
{

    private readonly Subject<Header> _onHeaderLoaded = new Subject<Header>();
    private readonly Subject<List<FieldDescriptor>> _onFieldsDescriptorLoaded = new Subject<List<FieldDescriptor>>();
    private readonly Subject<List<RecordData>> _onRecordsLoaded = new Subject<List<RecordData>>();
    private readonly Subject<bool> _onAllRecordsloaded = new Subject<bool>();

    private readonly List<RecordData> Records = new();
    private bool _headerloaded;
    private Header _header;
    //private byte[] _datas;
    public string Filename { get; set; }
    public bool StoreRecords { get; set; }
    public int From { get; set; } = 0;
    public int? To { get; set; } = null;
    public DbfDocument() : this(string.Empty)
    {


    }
    public DbfDocument(string filename)
    {
        this.Filename = filename;

        Observable.CombineLatest(HeaderLoaded, FieldsDescriptorLoaded, (h, f) => new { h, f })
            .Subscribe(items =>
            {
                _header = items.h;
                _header.Fields.AddRange(items.f);
                _headerloaded = true;
            });

        RecordsLoaded.Subscribe(records =>
        {
            if (StoreRecords)
                Records.AddRange(records);

        });
        /*AllRecordsLoaded.Subscribe(v =>
        {
            if (v && StoreRecords && (Records.Count != To))
                throw new InvalidProgramException($"Records Count {Records.Count} != Header Record Count {_header.NumberOfRecord}");
        });*/
    }
    public IObservable<Header> HeaderLoaded => _onHeaderLoaded.AsObservable();
    public IObservable<List<FieldDescriptor>> FieldsDescriptorLoaded => _onFieldsDescriptorLoaded.AsObservable();
    public IObservable<List<RecordData>> RecordsLoaded => _onRecordsLoaded.AsObservable();
    public IObservable<bool> AllRecordsLoaded => _onAllRecordsloaded.AsObservable();
    public string TableName => Path.GetFileNameWithoutExtension(Filename);

    public byte[] Datas { get; set; } = new byte[0];

    public async Task Load(bool loadRecords = false, int? loadRecordSteps = 100, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(Filename))
            throw new ApplicationException("You must define Filename before loading !");

        if (!_headerloaded)
        {
            if (Datas.Length == 0)
                Datas = await File.ReadAllBytesAsync(Filename, cancellationToken);
            _header = new DbfHeaderReader().Read(Datas);
            _onHeaderLoaded.OnNext(_header);

            var _fieldsDesciptor = new DbfDescriptorFieldReader().Read(Datas);
            _onFieldsDescriptorLoaded.OnNext(_fieldsDesciptor);
        }
        if (loadRecords)
            await LoadRecords(loadRecordSteps, cancellationToken);
    }

    public async Task LoadRecords(int? loadRecordSteps = 100, CancellationToken cancellationToken = default)
    {
        if (!_headerloaded)
            await Load(false, null, cancellationToken);
        loadRecordSteps = (loadRecordSteps??1) <= 0 ? 1 : loadRecordSteps;
        await Task.Run(() =>
        {
            int countRecord = 0;
            To = To ?? _header.NumberOfRecord;
            int maxRecord = (To ?? _header.NumberOfRecord);
            DbfRecordReader _reader = new DbfRecordReader(_header);
            for (int i = From; i < _header.NumberOfRecord; i += (loadRecordSteps ?? _header.NumberOfRecord))
            {
                if (cancellationToken.IsCancellationRequested) { break; }
                _reader.From = i;
                _reader.To = i + (loadRecordSteps ?? _header.NumberOfRecord);
                var recs = _reader.Read(Datas, cancellationToken);
                if (countRecord + recs.Count > maxRecord)
                {
                    recs = recs.Take(maxRecord - recs.Count).ToList();
                }
                countRecord += recs.Count;
                _onRecordsLoaded.OnNext(recs);
                if (countRecord >= maxRecord)
                {
                    _onAllRecordsloaded.OnNext(true);
                    break;
                }
            }
        });
    }
}
internal interface IDbfReader<T>
{
    T Read(byte[] datas, CancellationToken cancellationToken);
}
internal class DbfHeaderReader : IDbfReader<Header>
{
    public Header Read(byte[] datas, CancellationToken cancellationToken = default)
    {
        Header _header = new();
        _header.NumberOfRecord = BitConverter.ToInt32(datas.Skip(4).Take(7).ToArray(), 0);
        _header.NumberOfBytesInHeader = BitConverter.ToInt16(datas.Skip(8).Take(2).ToArray(), 0);
        _header.NumberOfBytesInRecords = BitConverter.ToInt16(datas.Skip(10).Take(2).ToArray(), 0);

        return _header;
    }
}

internal class DbfDescriptorFieldReader : IDbfReader<List<FieldDescriptor>>
{
    public List<FieldDescriptor> Read(byte[] datas, CancellationToken cancellationToken = default)
    {
        List<FieldDescriptor> _fields = new();
        int start = 0x20;
        int step = 0x20;
        bool end = false;
        while (!end)
        {

            end = (datas.Skip(start).Take(1).ToArray()[0] == 0x0D);
            if (!end)
            {
                var values = datas.Skip(start).Take(step).ToArray();
                _fields.Add(ReadFieldDescriptorArray(values));
                start += step;
            }
        }
        return _fields;
    }
    private FieldDescriptor ReadFieldDescriptorArray(byte[] datas)
    {
        FieldDescriptor field = new();
        field.Name = Encoding.ASCII.GetString(datas.TakeWhile(x => x != 0).ToArray());
        field.Type = Encoding.ASCII.GetString(datas.Skip(11).Take(1).ToArray());
        field.Length = datas.Skip(16).Take(1).ToArray().ToInt32();
        field.DecimalCount = datas.Skip(17).Take(4).ToArray().ToInt32();
        return field;
    }
}

internal class DbfRecordReader : IDbfReader<List<RecordData>>
{

    private readonly Header _header;
    internal int From { get; set; } = 0;
    internal int To { get; set; }
    public DbfRecordReader(Header header)
    {
        this._header = header;
        this.To = _header.NumberOfRecord;
    }
    public List<RecordData> Read(byte[] datas, CancellationToken cancellationToken = default)
    {
        int _start = _header.NumberOfBytesInHeader;

        int total = (datas.Length - _start) / _header.NumberOfBytesInRecords;
        int total1 = _header.NumberOfRecord;
        if (total != total1)
            throw new InvalidProgramException($"total record by byte calculation {total} != header Number of Records {_header.NumberOfRecord}");
        List<RecordData> records = new();
        From = From < 0 ? 0 : From;
        To = To > total ? total : To;

        for (int i = From; i < To; i++)
        {
            if (cancellationToken.IsCancellationRequested) break;
            //Console.WriteLine($"Read Record {i + 1}/{total}");
            var record = ReadRecordArray(datas.Skip(_start + i * _header.NumberOfBytesInRecords).Take(_header.NumberOfBytesInRecords).ToArray());
            records.Add(record);
        }

        return records;
    }

    private RecordData ReadRecordArray(byte[] datas)
    {
        var rec = new RecordData();
        char c =Convert.ToChar( datas[0]);
        bool is_deleted = c != ' ';// Convert.ToBoolean(datas[0]);
       // if (is_deleted)
        //    Debugger.Break();
        int start = 1;
        rec.IsMarkAsDeleted = is_deleted;
        foreach (var field in _header.Fields)
        {
            //if (field.DecimalCount == 0)
            //{
            /*if (Debugger.IsAttached && field.DecimalCount>0)
                Debugger.Break();*/
            //Console.WriteLine(field.Name);
            var data = datas.Skip(start).Take(field.Length).ToArray().ConvertToTheGoodType(field.Type);
            rec[field.Name] = data;
            /*if(field.Name.ToLower()=="codart" && ((string)data).Trim().Length==0)
                Debugger.Break();  */ 
            //}
            /*else
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
            }*/
            start += field.Length;
        }
        return rec;

    }
}
/*
internal class DbfReader
{
    const string FILENAME = @"E:\projets\WeLouxor\Database\cmlign.dbf";


    Header header = new();
    List<RecordData> Records = new();

    public DbfReader(string filename)
    {

    }

    public async Task Read()
    {
        var bytes = await File.ReadAllBytesAsync(FILENAME);

        ReadHeader(bytes);


        int start = 32;
        int step = 32;
        bool end = false;
        while (!end)
        {

            end = (bytes.Skip(start).Take(1).ToArray()[0] == 0x0D);
            if (!end)
            {
                var values = bytes.Skip(start).Take(step).ToArray();
                ReadFieldDescriptorArray(values);
                start += step;
            }
        }
        start = header.NumberOfBytesInHeader;
        int total = (bytes.Length - start) / header.NumberOfBytesInRecords;
        int total1 = header.NumberOfRecord;
        if (total != total1)
            throw new InvalidProgramException($"total record by byte calculation {total} != header Number of Records {header.NumberOfRecord}");
        for (int i = 0; i < total; i++)
        {
            Console.WriteLine($"Read Record {i + 1}/{total}");
            ReadRecordArray(bytes.Skip(start + i * header.NumberOfBytesInRecords).Take(header.NumberOfBytesInRecords).ToArray());
        }
        if (Records.Count != header.NumberOfRecord)
            throw new InvalidProgramException($"Records Count {Records.Count} != Header Record Count {header.NumberOfRecord}");
    }
    private void ReadHeader(byte[] value)
    {
        header.NumberOfRecord = BitConverter.ToInt32(value.Skip(4).Take(7).ToArray(), 0);
        header.NumberOfBytesInHeader = BitConverter.ToInt16(value.Skip(8).Take(2).ToArray(), 0);
        header.NumberOfBytesInRecords = BitConverter.ToInt16(value.Skip(10).Take(2).ToArray(), 0);
    }
    private void ReadFieldDescriptorArray(byte[] datas)
    {
        FieldDescriptor field = new();
        field.Name = Encoding.ASCII.GetString(datas.TakeWhile(x => x != 0).ToArray());
        field.Type = Encoding.ASCII.GetString(datas.Skip(11).Take(1).ToArray());
        field.Length = datas.Skip(16).Take(1).ToArray().ToInt32();
        field.DecimalCount = datas.Skip(17).Take(4).ToArray().ToInt32();
        header.Fields.Add(field);
    }

    private void ReadRecordArray(byte[] datas)
    {
        var rec = new RecordData();
        bool is_deleted = Convert.ToBoolean(datas[0]);
        int start = 1;
        rec.IsMarkAsDeleted = is_deleted;
        foreach (var field in header.Fields)
        {
            if (field.DecimalCount == 0)
            {
                var data = datas.Skip(start).Take(field.Length).ToArray().ConvertToTheGoodType(field.Type);
                rec[field.Name] = data;
            }
            start += field.Length;
        }
        Records.Add(rec);

    }
}*/

internal static class BitconverterExtensions
{
    internal static int ToInt32(this byte[] value)
    {
        Array.Resize(ref value, 4);
        return BitConverter.ToInt32(value, 0);
    }
    internal static double ToDouble(this byte[] value)
    => BitConverter.ToDouble(value, 0);

    internal static double ToDouble(this string value)
    => string.IsNullOrEmpty(value.Trim()) ? 0 : double.Parse(value.Trim(), CultureInfo.InvariantCulture);
    internal static int ToInt32(this string value)
    => string.IsNullOrEmpty(value.Trim()) ? 0 : Int32.Parse(value);
    internal static DateOnly ToDate(this int value)
    {

        var y = (int)value / 10000;
        var m = (value / 100) - (y * 100);
        var d = value - (y * 10000 + m * 100);
        //var m = Int32.Parse(value.Substring(3, 2));
        //var d = Int32.Parse(value.Substring(6, 2));
        //return new DateOnly(Int32.Parse(value.Substring(0, 4)), Int32.Parse(value.Substring(3, 2)), Int32.Parse(value.Substring(6, 2)));
        try
        {
            return new(y, m, d);
        }
        catch (ArgumentOutOfRangeException e)
        {
            return new();
        }

    }

    internal static bool ToBoolean(this string value)
    =>
        value.Trim().ToLower() switch
        {
            "t" or "yes" => true,
            "f" or "no" or "" => false,
            _ => throw new NotSupportedException(value)
        };


    internal static object ConvertToTheGoodType(this byte[] value, string type)
    => type.ToLower() switch
    {
        "c" => Encoding.ASCII.GetString(value.TakeWhile(x => x != 0).ToArray()),
        "n" => Encoding.ASCII.GetString(value.ToArray()).ToDouble(), // value.TakeWhile(x=>x!=0).ToArray().ToDouble(),
        "d" => Encoding.ASCII.GetString(value.TakeWhile(x => x != 0).ToArray()).Trim().ToInt32().ToDate(),
        "l" => Encoding.ASCII.GetString(value).ToBoolean(),
        "m" => string.Empty,
        _ => throw new NotSupportedException(type),
    };
}
public class Header
{
    public int FileType { get; internal set; }
    public int NumberOfRecord { get; internal set; }
    public short NumberOfBytesInHeader { get; internal set; }
    public short NumberOfBytesInRecords { get; internal set; }

    public List<FieldDescriptor> Fields { get; } = new List<FieldDescriptor>();
}

[DebuggerDisplay("{Name}-{Type}-{Length}-{DecimalCount}")]
public class FieldDescriptor
{
    public string Name { get; internal set; } = string.Empty;
    public string Type { get; internal set; } = string.Empty;
    public int Length { get; internal set; }
    public int DecimalCount { get; internal set; }
}

public class RecordData
{
    Dictionary<string, object> datas = new();
    public bool IsMarkAsDeleted { get; set; }
    public object this[string name]
    {
        get => datas[name.ToLower()];
        set => datas[name.ToLower()] = value;
    }
}
