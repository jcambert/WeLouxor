using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class BrowseOperationPourOrdreDeFabricationHandler
    : BaseHandler<
          BrowseOperationPourOrdreDeFabricationQuery,
          BrowseOperationPourOrdreDeFabricationResponse
      >
{
    IRepository<OrdreDeFabication, Guid> repository =>
        LazyServiceProvider.GetRequiredService<IRepository<OrdreDeFabication, Guid>>();

    public BrowseOperationPourOrdreDeFabricationHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    public override async Task<BrowseOperationPourOrdreDeFabricationResponse> Handle(
        BrowseOperationPourOrdreDeFabricationQuery request,
        CancellationToken cancellationToken
    )
    {
        var query = await repository.GetQueryableAsync();
        //var ok = Int32.TryParse(request.OrdreDeFabrication, out var of);
        //if (!ok)
        //    throw new ArgumentException($"Ordre de fabrication incorret:{request.OrdreDeFabrication}");
        var of = request.OrdreDeFabrication;
        var of1 = of * 1000;
        var of2 = of * 1000 + 999;
        query = from q in query where q.Societe == request.Societe && q.Numero == of select q;

        var list = await AsyncExecuter.ToListAsync(query, cancellationToken);

        var res = list.Select(x => x.CodeOperation).Order().ToList();
        return new BrowseOperationPourOrdreDeFabricationResponse(res);
    }
}
