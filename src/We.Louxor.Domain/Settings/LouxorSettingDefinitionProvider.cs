using Volo.Abp.Settings;

namespace We.Louxor.Settings;

public class LouxorSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LouxorSettings.MySetting1));
    }
}
