using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.InventaireArticle;

public interface IPrintAppService : IApplicationService
{
    Task<PrintResponse> PrintAsync(PrintQuery query);
}
