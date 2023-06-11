using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Linq;
using Volo.Abp.ObjectMapping;
using We.AbpExtensions;
using We.Mediatr;

namespace We.Louxor.Handlers;

public abstract class BaseHandler<TQuery, TResponse> : AbpHandler.With<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : Response
{
    protected BaseHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider) { }
}
