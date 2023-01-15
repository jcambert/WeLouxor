using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class GetLigneInventaireHandler : BaseHandler<GetLigneInventaireQuery, GetLigneInventaireResponse>
{
    public GetLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<GetLigneInventaireResponse> Handle(GetLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
