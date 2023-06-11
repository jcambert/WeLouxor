using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Controllers;

[Area("Inventaire")]
//[RemoteService(IsEnabled = false, IsMetadataEnabled = false, Name = AccountRemoteServiceConsts.RemoteServiceName)]
[Route("api/printinventaire")]
public class PrintController : LouxorController
{
    IPrintAppService Service => LazyServiceProvider.GetRequiredService<IPrintAppService>();

    [HttpPost(), Route("")]
    public async Task<IActionResult> PrintAsync([FromQuery] PrintQuery query)
    {
        var response = await Service.PrintAsync(query);
        if (response)
        {
            var result = File(
                response.Value.Content,
                response.Value.ContentType,
                response.Value.Filename
            );
            return result;
        }
        return NotFound();
    }
}
