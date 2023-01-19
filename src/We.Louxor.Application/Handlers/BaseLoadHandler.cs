using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.VirtualFileSystem;
using We.Dbf;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public abstract class BaseLoadHandler<TQuery, TResponse,TEntity,TKey> : BaseHandler<TQuery, TResponse>
     where TQuery : ILoadBaseQuery, IRequest<TResponse>
    where TEntity : class, IEntityLouxor, IEntity<TKey>
    where TResponse:new()
{
    IServiceProvider _serviceProvider => LazyServiceProvider.GetRequiredService<IServiceProvider>();
    IRepository<TEntity,TKey> Repository => LazyServiceProvider.GetRequiredService<IRepository<TEntity, TKey>>();
    protected BaseLoadHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
    public override async Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
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
                    Logger.LogDebug($"{Path.GetFileNameWithoutExtension(request.Filename)} All records Loaded successfully".FormatColor());
                });
                Dbf.RecordsLoaded.Subscribe(records =>
                {
                    Logger.LogDebug($"{records.Count} where loaded".FormatColor());
                    List<TEntity> lignes = ObjectMapper.Map<List<RecordData>, List<TEntity>>(records);
                    if (request.TestForDuplicate)
                    {
                        if (!CheckForDuplicate(lignes))
                        {
                            Logger.LogWarning("It seem there are duplicates values!!".FormatWarning());
                        }
                    }
                    else
                    {

                        lignes = Filter(lignes,true);
                        counter += lignes.Count;
                        Task.Run(async () =>
                        {
                            await Repository.InsertManyAsync(lignes, true, cancellationToken);
                            Logger.LogDebug($"{lignes.Count} lines were inserted in database. Total:{counter}/{Dbf.TotalRecord}".FormatColor());
                        }).GetAwaiter().GetResult();
                        Task.Delay(500).GetAwaiter().GetResult();
                    }
                });
                await Dbf.LoadAsync(bytes, request.Filename, request.LoadRecordStep,request.From, request.To, cancellationToken);
            }



        }
        return GetResponse();
    }

    protected virtual bool CheckForDuplicate(List<TEntity> lignes)
    => true;

    protected virtual TResponse GetResponse() 
        => new();

    protected virtual List<TEntity> Filter(List<TEntity> records,bool removeDuplicates=false) => records;
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