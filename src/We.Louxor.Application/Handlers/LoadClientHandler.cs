﻿using System;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadClientHandler : BaseLoadHandler<LoadClientQuery, LoadClientResponse, Client, Guid>
{
    public LoadClientHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }


}
