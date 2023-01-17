using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.VirtualFileSystem;
using We.Dbf;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

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
                byte[] bytes = reader.ReadBytes((int)stream.Length);
                Dbf.AllRecordsLoaded.Subscribe(b =>
                {
                    Logger.LogDebug($"\x1B[43m{Path.GetFileNameWithoutExtension( request.Filename)} All records Loaded successfully\x1B[43m");
                });
                Dbf.RecordsLoaded.Subscribe(records =>
                {
                    Logger.LogDebug($"{records.Count} where loaded");
                    List<LigneDeCommande> lignes = ObjectMapper.Map<List<RecordData>, List<LigneDeCommande>>(records);
                    Task.Run(async() => {
                        await Repository.InsertManyAsync(lignes, true, cancellationToken);
                    });
                    
                });
                await Dbf.LoadAsync(bytes, request.Filename, 100, 180, cancellationToken);
            }



        }
        return new LoadCommandeClientResponse();
    }
}
