using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class RemoveLigneInventaireHandler
    : BaseHandler<RemoveLigneInventaireQuery, RemoveLigneInventaireResponse>
{
    protected IRepository<LigneInventaire, Guid> repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();

    public RemoveLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override async  Task<Result<RemoveLigneInventaireResponse>> InternalHandle(RemoveLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        await repository.HardDeleteAsync(x => x.Id == request.Id, true, cancellationToken);
        return new RemoveLigneInventaireResponse();
    }
  
}

public class RemoveAllLigneInventaireHandler
    : BaseHandler<RemoveAllLigneInventaireQuery, RemoveLigneInventaireResponse>
{
    protected IRepository<LigneInventaire, Guid> repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();

    public RemoveAllLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override async Task<Result<RemoveLigneInventaireResponse>> InternalHandle(RemoveAllLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        await repository.HardDeleteAsync(
           x => x.Societe == request.Societe,
           true,
           cancellationToken
       );
        return new RemoveLigneInventaireResponse();
    }
   
}
