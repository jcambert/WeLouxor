using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class AddLigneInventaireHandler : BaseHandler<AddLigneInventaireQuery, AddLigneInventaireResponse>
{
    public AddLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<AddLigneInventaireResponse> Handle(AddLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
