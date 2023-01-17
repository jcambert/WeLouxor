using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadCommandeClientHandler : BaseHandler<LoadCommandeClientQuery, LoadCommandeClientResponse>
{
    
    IServiceProvider _serviceProvider=>LazyServiceProvider.GetRequiredService<IServiceProvider>();
    
    public LoadCommandeClientHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override  Task<LoadCommandeClientResponse> Handle(LoadCommandeClientQuery request, CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            DbfDocumentManager Dbf= scope.ServiceProvider.GetService<DbfDocumentManager>();
            Dbf.AllRecordsLoaded.Subscribe(b => {
                Logger.LogDebug($"{request.Filename} All records Loaded successfully");
            });
            Dbf.RecordsLoaded.Subscribe(records => {
                Logger.LogDebug($"{records.Count} where loaded");
            });
            //await Dbf.LoadAsync(request.Filename, 100, 180, cancellationToken);
            var input = Observable.Interval(TimeSpan.FromMilliseconds(500));
            input.Select(i => Observable.FromAsync(ct => Dbf.LoadAsync(request.Filename, 100, 180, cancellationToken)))
                .Concat()
                .Do(onNext: x => { }, onError: ex => { }, onCompleted: () => { })
                .Wait();
        }
        return Task.FromResult( new LoadCommandeClientResponse());
    }
}
