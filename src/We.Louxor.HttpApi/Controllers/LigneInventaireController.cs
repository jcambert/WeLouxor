using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Controllers;

[Area("Inventaire")]
//[RemoteService(IsEnabled = false, IsMetadataEnabled = false, Name = AccountRemoteServiceConsts.RemoteServiceName)]
[Route("api/ligneinventaire")]
public class LigneInventaireController : LouxorController //, ILigneInventaireAppService
{
    IInventaireAppService Service =>
        LazyServiceProvider.GetRequiredService<IInventaireAppService>();

    [HttpPost(), Route("add")]
    public Task<AddLigneInventaireResponse> AddAsync([FromQuery] AddLigneInventaireQuery query) =>
        Service.AddAsync(query);

    [HttpGet(), Route("get")]
    public Task<GetLigneInventaireResponse> GetAsync([FromQuery] GetLigneInventaireQuery query) =>
        Service.GetAsync(query);

    [HttpGet(), Route("getall")]
    public Task<BrowseLigneInventaireResponse> GetListAsync(
        [FromQuery] BrowseLigneInventaireQuery query
    ) => Service.GetListAsync(query);

    [HttpDelete(), Route("delete")]
    public Task<RemoveLigneInventaireResponse> RemoveAsync(
        [FromQuery] RemoveLigneInventaireQuery query
    ) => Service.RemoveAsync(query);

    [HttpDelete(), Route("deleteall")]
    public Task<RemoveLigneInventaireResponse> RemoveAllAsync(
        [FromQuery] RemoveAllLigneInventaireQuery query
    ) => Service.RemoveAllAsync(query);

    [HttpPut(), Route("update")]
    public Task<UpdateLigneInventaireResponse> UpdateAsync(
        [FromQuery] UpdateLigneInventaireQuery query
    ) => Service.UpdateAsync(query);
}
