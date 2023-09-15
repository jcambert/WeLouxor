using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OpenIddict.Validation.AspNetCore;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Components.Server.BasicTheme;
using Volo.Abp.AspNetCore.Components.Server.BasicTheme.Bundling;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Blazor.Server;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Blazor.Server;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.Blazor.Server;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using We.Louxor.Blazor.Menus;
using We.Louxor.EntityFrameworkCore;
using We.Louxor.Localization;
using We.Louxor.MultiTenancy;
#if MEDIATR
using MediatR;
#endif
#if MEDIATOR
using Mediator;
#endif
namespace We.Louxor.Blazor;

[DependsOn(
    typeof(LouxorApplicationModule),
    typeof(LouxorEntityFrameworkCoreModule),
    typeof(LouxorHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpAspNetCoreComponentsServerBasicThemeModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(AbpIdentityBlazorServerModule),
    typeof(AbpTenantManagementBlazorServerModule),
    typeof(AbpSettingManagementBlazorServerModule)
)]
public class LouxorBlazorModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(
            options =>
            {
                options.AddAssemblyResource(
                    typeof(LouxorResource),
                    typeof(LouxorDomainModule).Assembly,
                    typeof(LouxorDomainSharedModule).Assembly,
                    typeof(LouxorApplicationModule).Assembly,
                    typeof(LouxorApplicationContractsModule).Assembly,
                    typeof(LouxorBlazorModule).Assembly
                );
            }
        );

        PreConfigure<OpenIddictBuilder>(
            builder =>
            {
                builder.AddValidation(
                    options =>
                    {
                        options.AddAudiences("Louxor");
                        options.UseLocalServer();
                        options.UseAspNetCore();
                    }
                );
            }
        );
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

 

        //ConfigureAuthentication(context);
        ConfigureUrls(configuration);
        ConfigureBundles();
        ConfigureAutoMapper();
        ConfigureVirtualFileSystem(hostingEnvironment);
        ConfigureSwaggerServices(context.Services);
        ConfigureAutoApiControllers();
        ConfigureBlazorise(context);
        ConfigureRouter(context);
        ConfigureMenu(context);
        ConfigureMediator(context);
    }

    private static void ConfigureMediator(ServiceConfigurationContext context)
    {
#if MEDIATOR
        context.Services.AddMediator();
#endif
#if MEDIATR
        context.Services.AddMediatR(
            cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(AbpExtensionsModule).Assembly,
                    typeof(LouxorApplicationModule).Assembly,
                );
            }
        );
#endif

    }
    private void ConfigureAuthentication(ServiceConfigurationContext context)
    {
        context.Services.ForwardIdentityAuthenticationForBearer(
            OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme
        );
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(
            options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
                options.RedirectAllowedUrls.AddRange(
                    configuration["App:RedirectAllowedUrls"].Split(',')
                );
            }
        );
    }

    private void ConfigureBundles()
    {
        Configure<AbpBundlingOptions>(
            options =>
            {
                // MVC UI
                options.StyleBundles.Configure(
                    BasicThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/global-styles.css");
                    }
                );

                //BLAZOR UI
                options.StyleBundles.Configure(
                    BlazorBasicThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/blazor-global-styles.css");
                        //You can remove the following line if you don't use Blazor CSS isolation for components
                        bundle.AddFiles("/We.Louxor.Blazor.styles.css");
                    }
                );

                options.ScriptBundles.Configure(
                    BlazorBasicThemeBundles.Scripts.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/js/app.js");
                    }
                    );
            }
        );
    }

    private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
    {
        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(
                options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<LouxorDomainSharedModule>(
                        Path.Combine(
                            hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}We.Louxor.Domain.Shared"
                        )
                    );
                    options.FileSets.ReplaceEmbeddedByPhysical<LouxorDomainModule>(
                        Path.Combine(
                            hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}We.Louxor.Domain"
                        )
                    );
                    options.FileSets.ReplaceEmbeddedByPhysical<LouxorApplicationContractsModule>(
                        Path.Combine(
                            hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}We.Louxor.Application.Contracts"
                        )
                    );
                    options.FileSets.ReplaceEmbeddedByPhysical<LouxorApplicationModule>(
                        Path.Combine(
                            hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}We.Louxor.Application"
                        )
                    );
                    options.FileSets.ReplaceEmbeddedByPhysical<LouxorBlazorModule>(
                        hostingEnvironment.ContentRootPath
                    );
                }
            );
        }
        Configure<AbpVirtualFileSystemOptions>(
            options =>
            {
                var path = Path.Combine(hostingEnvironment.WebRootPath, "database");
                options.FileSets.AddPhysical(path);
            }
        );
    }

    private void ConfigureSwaggerServices(IServiceCollection services)
    {
        services.AddAbpSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Louxor API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );
    }

    private void ConfigureBlazorise(ServiceConfigurationContext context)
    {
        context.Services.AddBootstrap5Providers().AddFontAwesomeIcons();
    }

    private void ConfigureMenu(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(
            options =>
            {
                options.MenuContributors.Add(new LouxorMenuContributor());
            }
        );
    }

    private void ConfigureRouter(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(
            options =>
            {
                options.AppAssembly = typeof(LouxorBlazorModule).Assembly;
            }
        );
    }

    private void ConfigureAutoApiControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(
            options =>
            {
                // options.ConventionalControllers.Create(typeof(LouxorApplicationModule).Assembly);
            }
        );
    }

    private void ConfigureAutoMapper()
    {
        Configure<AbpAutoMapperOptions>(
            options =>
            {
                options.AddMaps<LouxorBlazorModule>();
            }
        );
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var env = context.GetEnvironment();
        var app = context.GetApplicationBuilder();

        app.UseAbpRequestLocalization();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        //app.UseAuthentication();
        app.UseAbpOpenIddictValidation();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        //app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(
            options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Louxor API");
            }
        );
        app.UseConfiguredEndpoints();
    }
}
