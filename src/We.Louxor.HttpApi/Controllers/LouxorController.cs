using We.Louxor.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace We.Louxor.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LouxorController : AbpControllerBase
{
    protected LouxorController()
    {
        LocalizationResource = typeof(LouxorResource);
    }
}
