﻿using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IRemoveLigneInventaireQuery))]
public class RemoveLigneInventaireQuery : IRemoveLigneInventaireQuery
{
    public Guid Id { get; set; }
}
