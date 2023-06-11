using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Mediatr;
using We.Results;

namespace We.Louxor;

public class PrintAppService : LouxorAppService, IPrintAppService
{
    public Task<Result<PrintResponse>> PrintAsync(PrintQuery query) =>
        Mediator.Send(query).AsTaskWrap();
}
