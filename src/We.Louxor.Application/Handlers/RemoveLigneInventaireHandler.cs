using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class RemoveLigneInventaireHandler : BaseHandler<RemoveLigneInventaireQuery, RemoveLigneInventaireResponse>
{
    public RemoveLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<RemoveLigneInventaireResponse> Handle(RemoveLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}
