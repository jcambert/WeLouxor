using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class UpdateLigneInventaireHandler : BaseHandler<IUpdateLigneInventaireQuery, UpdateLigneInventaireResponse>
{
    public UpdateLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<UpdateLigneInventaireResponse> Handle(IUpdateLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
