using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Controllers;

[Area("Inventaire")]
//[RemoteService(IsEnabled = false, IsMetadataEnabled = false, Name = AccountRemoteServiceConsts.RemoteServiceName)]
[Route("api/inventaire/extraction")]
public class InventaireExtractLouxorController
    : LouxorController,
      IInventaireExtractLouxorAppService
{
    IInventaireExtractLouxorAppService Service =>
        LazyServiceProvider.GetRequiredService<IInventaireExtractLouxorAppService>();

    [HttpGet, Route("LoadCommandeClient")]
    public Task<Result<LoadCommandeClientResponse>> Load(LoadCommandeClientQuery query) =>
        Service.Load(query);

    [HttpGet, Route("LoadArticle")]
    public Task<Result<LoadArticleResponse>> Load(LoadArticleQuery query) => Service.Load(query);

    [HttpGet, Route("LoadOrdresDeFabrication")]
    public Task<Result<LoadOrdreDeFabricationResponse>> Load(LoadOrdreDeFabricationQuery query) =>
        Service.Load(query);

    [HttpGet, Route("LoadClient")]
    public Task<Result<LoadClientResponse>> Load(LoadClientQuery query) => Service.Load(query);

    [HttpDelete, Route("ClearArticle")]
    public Task<Result<ClearArticleResponse>> Clear(ClearArticleQuery query) =>
        Service.Clear(query);

    [HttpDelete, Route("ClearCommandeClient")]
    public Task<Result<ClearCommandeClientResponse>> Clear(ClearCommandeClientQuery query) =>
        Service.Clear(query);

    [HttpDelete, Route("ClearOrdresDeFabrication")]
    public Task<Result<ClearOrdreDeFabricationResponse>> Clear(
        ClearOrdreDeFabricationQuery query
    ) => Service.Clear(query);

    [HttpDelete, Route("ClearClient")]
    public Task<Result<ClearClientResponse>> Clear(ClearClientQuery query) => Service.Clear(query);
}
