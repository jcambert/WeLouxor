using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace We.Louxor.Blazor;

[Dependency(ReplaceServices = true)]
public class LouxorBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Louxor";
}
