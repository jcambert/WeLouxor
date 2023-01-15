﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Linq;
using Volo.Abp.ObjectMapping;
namespace We.Louxor.Handlers;

public abstract class BaseHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IRequest<TResponse>
{
    protected BaseHandler(IAbpLazyServiceProvider serviceProvider)
    {
        LazyServiceProvider = serviceProvider;
    }
    protected IAbpLazyServiceProvider LazyServiceProvider { get; init; }
    protected IAsyncQueryableExecuter AsyncExecuter => LazyServiceProvider.LazyGetRequiredService<IAsyncQueryableExecuter>();

    protected Type ObjectMapperContext { get; set; }
    protected IObjectMapper ObjectMapper => LazyServiceProvider.LazyGetService<IObjectMapper>(provider =>
        ObjectMapperContext == null
            ? provider.GetRequiredService<IObjectMapper>()
            : (IObjectMapper)provider.GetRequiredService(typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext)));

    
    protected IMediator Mediator => LazyServiceProvider.LazyGetRequiredService<IMediator>();

    protected T GetRequiredService<T>() => LazyServiceProvider.LazyGetRequiredService<T>();

    protected ICachedServiceProvider Cache => GetRequiredService<ICachedServiceProvider>();

    public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}