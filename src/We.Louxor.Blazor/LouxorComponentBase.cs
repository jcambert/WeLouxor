using We.Louxor.Localization;
using Volo.Abp.AspNetCore.Components;

namespace We.Louxor.Blazor;

public abstract class LouxorComponentBase : AbpComponentBase
{
    protected LouxorComponentBase()
    {
        LocalizationResource = typeof(LouxorResource);
    }
}
