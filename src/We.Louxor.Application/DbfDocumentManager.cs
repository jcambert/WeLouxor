﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Services;
using We.Dbf;

namespace We.Louxor;
internal static class LoggerColor {
    const string BACKGROUND_COLOR = @"\x1B[43m";
    const string DEFAULT_COLOR = @"\x1B[39m\x1B[22m";
    public static string FormatColor(this string s)
        => $"{BACKGROUND_COLOR}{s}{DEFAULT_COLOR}";
}
public sealed class DbfDocumentManager:DomainService
{
    private readonly Subject<List<RecordData>> _onRecordsLoaded = new Subject<List<RecordData>>();
    private readonly Subject<bool> _onAllRecordsloaded = new Subject<bool>();
    private DbfDocument Doc=>LazyServiceProvider.LazyGetRequiredService<DbfDocument>();
    public IObservable<List<RecordData>> RecordsLoaded => _onRecordsLoaded.AsObservable();
    public IObservable<bool> AllRecordsLoaded => _onAllRecordsloaded.AsObservable();
    private void Initialize()
    {
        //List<RecordData> _records = new();
        Doc.HeaderLoaded.Subscribe(h => {
            Logger.LogDebug("Header is loaded");
        });
        Doc.FieldsDescriptorLoaded.Subscribe(fields => {
            Logger.LogDebug("Field Descriptor loaded".FormatColor());
            Logger.LogDebug($"There is {fields.Count} Fields in {Doc.TableName}".FormatColor());
            foreach (var field in fields)
            {
                Logger.LogDebug($"{field.Name}-{field.Type}");
            }
        });

        Doc.AllRecordsLoaded.Subscribe(b => {
            Logger.LogDebug("All records are loaded".FormatColor());
            _onAllRecordsloaded.OnNext(b);


        });
        Doc.RecordsLoaded.Subscribe(records =>
        {
            Logger.LogDebug($"{records.Count} are been loaded".FormatColor());
            _onRecordsLoaded.OnNext(records);

        });
    }
    public async Task LoadAsync(string filename,int loadRecordStep=100,int? limitRecordCountTo=null, CancellationToken cancellationToken=default)
    {
       
        Doc.Filename= filename;
        Doc.LimitRecordCountTo = limitRecordCountTo;
        
        Initialize();
        await Doc.LoadRecords(loadRecordStep,cancellationToken);
        
    }

    internal async Task LoadAsync(byte[] bytes, string filename, int loadRecordStep = 100, int? limitRecordCountTo = null, CancellationToken cancellationToken=default)
    {
        Doc.Filename = filename;
        Doc.Datas = bytes;
        Doc.LimitRecordCountTo = limitRecordCountTo;
        Initialize();
        await Doc.LoadRecords(loadRecordStep, cancellationToken);
    }
}
