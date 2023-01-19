using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Controllers;
[Area("Inventaire")]
//[RemoteService(IsEnabled = false, IsMetadataEnabled = false, Name = AccountRemoteServiceConsts.RemoteServiceName)]
[Route("api/inventaire/extraction")]
public class InventaireExtractLouxorController : LouxorController, IInventaireExtractLouxorAppService
{
    IInventaireExtractLouxorAppService Service => LazyServiceProvider.GetRequiredService<IInventaireExtractLouxorAppService>();

    [HttpGet, Route("LoadCommandeClient")]
    public Task<LoadCommandeClientResponse> Load(LoadCommandeClientQuery query)
    => Service.Load(query);

    [HttpGet, Route("LoadArticle")]
    public Task<LoadArticleResponse> Load(LoadArticleQuery query)
    => Service.Load(query);

    [HttpGet, Route("LoadOrdresDeFabrication")]
    public Task<LoadOrdreDeFabricationResponse> Load(LoadOrdreDeFabricationQuery query)
    => Service.Load(query);

    [HttpGet, Route("LoadClient")]
    public Task<LoadClientResponse> Load(LoadClientQuery query)
    => Service.Load(query);

    [HttpDelete, Route("ClearArticle")]
    public Task<ClearArticleResponse> Clear(ClearArticleQuery query)
    => Service.Clear(query);

    [HttpDelete, Route("ClearCommandeClient")]
    public Task<ClearCommandeClientResponse> Clear(ClearCommandeClientQuery query)
    => Service.Clear(query);

    [HttpDelete, Route("ClearOrdresDeFabrication")]
    public Task<ClearOrdreDeFabricationResponse> Clear(ClearOrdreDeFabricationQuery query)
    => Service.Clear(query);

    [HttpDelete, Route("ClearClient")]
    public Task<ClearClientResponse> Clear(ClearClientQuery query)
    => Service.Clear(query);
}
