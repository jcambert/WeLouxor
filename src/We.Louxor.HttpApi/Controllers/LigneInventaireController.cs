using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Controllers;

public class LigneInventaireController : LouxorController, ILigneInventaireAppService
{

    ILigneInventaireAppService Service => LazyServiceProvider.GetRequiredService<ILigneInventaireAppService>();

    [HttpPost(),Route("add")]

    public Task<AddLigneInventaireResponse> AddAsync([FromQuery] IAddLigneInventaireQuery query)
    =>Service.AddAsync(query);

    [HttpGet(),Route("get")]
    public Task<GetLigneInventaireResponse> GetAsync([FromQuery] IGetLigneInventaireQuery query)
    =>Service.GetAsync(query);

    [HttpGet(), Route("getall")]
    public Task<List<GetLigneInventaireResponse>> GetListAsync()
    => Service.GetListAsync();

    [HttpDelete(),Route("delete")]
    public Task<RemoveLigneInventaireResponse> RemoveAsync( [FromQuery] IRemoveLigneInventaireQuery query)
    => Service.RemoveAsync(query);

    [HttpPut(), Route("update")]
    public Task<UpdateLigneInventaireResponse> UpdateAsync([FromQuery] IUpdateLigneInventaireQuery query)
    => Service.UpdateAsync(query);
}
