using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using We.Dbf;

namespace We.Louxor;

public sealed class DbfDocumentManager:DomainService
{
    private readonly Subject<List<RecordData>> _onRecordsLoaded = new Subject<List<RecordData>>();
    private readonly Subject<bool> _onAllRecordsloaded = new Subject<bool>();
    private DbfDocument Doc=>LazyServiceProvider.LazyGetRequiredService<DbfDocument>();
    public IObservable<List<RecordData>> RecordsLoaded => _onRecordsLoaded.AsObservable();
    public IObservable<bool> AllRecordsLoaded => _onAllRecordsloaded.AsObservable();
    public async Task LoadAsync(string filename,int loadRecordStep=100,int? limitRecordCountTo=null, CancellationToken cancellationToken=default)
    {
        List<RecordData> _records = new();
        Doc.Filename= filename;
        Doc.LimitRecordCountTo = limitRecordCountTo;
        
        Doc.HeaderLoaded.Subscribe(h => { 
            Logger.LogDebug("Header is loaded"); 
        });
        Doc.FieldsDescriptorLoaded.Subscribe(f => {
            Logger.LogDebug("Field Descriptor loaded");
            Logger.LogDebug($"There is {f.Count} Fields in {Doc.TableName}");
        });

        Doc.AllRecordsLoaded.Subscribe(b => {
            Logger.LogDebug("All records are loaded");
            _onAllRecordsloaded.OnNext(b);


        });
        Doc.RecordsLoaded.Subscribe(records =>
        {
            Logger.LogDebug($"{records.Count} are been loaded");
            _onRecordsLoaded.OnNext(records);

        });
        await Doc.LoadRecords(loadRecordStep,cancellationToken);
        
    }

}
