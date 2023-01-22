using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor;

public class PrintAppService : LouxorAppService, IPrintAppService
{
    public Task<PrintResponse> PrintAsync(PrintQuery query)
    => Mediator.Send(query);
}
