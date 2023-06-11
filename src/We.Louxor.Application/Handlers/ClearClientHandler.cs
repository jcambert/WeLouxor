using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class ClearClientHandler
    : ClearBaseHandler<ClearClientQuery, ClearClientResponse, Client, ClientDto>
{
    public ClearClientHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override ClearClientResponse GetResponse() => new ClearClientResponse();
}
