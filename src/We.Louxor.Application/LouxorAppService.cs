using MediatR;
using Volo.Abp.Application.Services;
using We.Louxor.Localization;

namespace We.Louxor;

/* Inherit your application services from this class.
 */
public abstract class LouxorAppService : ApplicationService
{
    protected IMediator Mediator => LazyServiceProvider.LazyGetRequiredService<IMediator>();

    protected LouxorAppService()
    {
        LocalizationResource = typeof(LouxorResource);
    }
}
