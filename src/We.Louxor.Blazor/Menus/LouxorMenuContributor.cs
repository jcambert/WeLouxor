using System.Threading.Tasks;
using We.Louxor.Localization;
using We.Louxor.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace We.Louxor.Blazor.Menus;

public class LouxorMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<LouxorResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                LouxorMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );
        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                LouxorMenus.InventaireSaisie,
                l["Menu:Swagger"],
                "/swagger",
                icon: "fas fa-list",
                order: 1
            )
        );
        context.Menu.Items.Insert(
            2,
            new ApplicationMenuItem(
                LouxorMenus.InventaireSaisie,
                l["Menu:Inventaire:Saisie"],
                "/inventaire/saisie",
                icon: "fas fa-pen-nib",
                order: 2
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
