using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class RemoveLigneInventaireHandler : BaseHandler<RemoveLigneInventaireQuery, RemoveLigneInventaireResponse>
{
    protected IRepository<LigneInventaire, Guid> repository => LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();
    public RemoveLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<RemoveLigneInventaireResponse> Handle(RemoveLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        await repository.HardDeleteAsync(x=>x.Id== request.Id, true, cancellationToken);
        return new();
    }
}

public class RemoveAllLigneInventaireHandler : BaseHandler<RemoveAllLigneInventaireQuery, RemoveLigneInventaireResponse>
{
    protected IRepository<LigneInventaire, Guid> repository => LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();
    public RemoveAllLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<RemoveLigneInventaireResponse> Handle(RemoveAllLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        await repository.HardDeleteAsync(x => x.Societe == request.Societe, true, cancellationToken);
        return new();
    }
}