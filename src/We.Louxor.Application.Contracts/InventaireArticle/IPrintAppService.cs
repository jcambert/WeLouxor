using Volo.Abp.Application.Services;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.InventaireArticle;

public interface IPrintAppService : IApplicationService
{
    Task<Result<PrintResponse>> PrintAsync(PrintQuery query);
}
