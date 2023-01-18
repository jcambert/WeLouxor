using System;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadCommandeClientHandler : BaseLoadHandler<LoadCommandeClientQuery, LoadCommandeClientResponse, LigneDeCommande, Guid>
{
    public LoadCommandeClientHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override LoadCommandeClientResponse GetResponse()
    {
        return new LoadCommandeClientResponse();
    }
}
/*
public class LoadCommandeClientHandler : BaseHandler<LoadCommandeClientQuery, LoadCommandeClientResponse>
{

    IServiceProvider _serviceProvider => LazyServiceProvider.GetRequiredService<IServiceProvider>();
    IRepository<LigneDeCommande, Guid> Repository => LazyServiceProvider.GetRequiredService<IRepository<LigneDeCommande, Guid>>();
    public LoadCommandeClientHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<LoadCommandeClientResponse> Handle(LoadCommandeClientQuery request, CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            DbfDocumentManager Dbf = scope.ServiceProvider.GetService<DbfDocumentManager>();
            var vfp = scope.ServiceProvider.GetService<IVirtualFileProvider>();
            var fi = vfp.GetFileInfo(request.Filename);
            if (!fi.Exists)
                throw new ArgumentException($"{request.Filename} does not exist in wwww/database/folder ");
            var stream = fi.CreateReadStream();

            using (var reader = new BinaryReader(stream))
            {
                int counter = 0;
                byte[] bytes = reader.ReadBytes((int)stream.Length);
                Dbf.AllRecordsLoaded.Subscribe(b =>
                {
                    Logger.LogDebug($"\x1B[43m{Path.GetFileNameWithoutExtension( request.Filename)} All records Loaded successfully\x1B[43m");
                });
                Dbf.RecordsLoaded.Subscribe(records =>
                {
                    Logger.LogDebug($"\x1B[43m{records.Count} where loaded\x1B[43m");
                    List<LigneDeCommande> lignes = ObjectMapper.Map<List<RecordData>, List<LigneDeCommande>>(records);
                    counter += records.Count;
                    Task.Run(async() => {
                        await Repository.InsertManyAsync(lignes, true, cancellationToken);
                        Logger.LogDebug($"\x1B[43m{lignes.Count} lines were inserted in database. Total:{counter}/{Dbf.TotalRecord}\x1B[43m");
                    }).GetAwaiter().GetResult();
                    Task.Delay(500).GetAwaiter().GetResult();
                });
                await Dbf.LoadAsync(bytes, request.Filename,request.LoadRecordStep,request.LimitRecordCountTo, cancellationToken);
            }



        }
        return new LoadCommandeClientResponse();
    }
}
*/