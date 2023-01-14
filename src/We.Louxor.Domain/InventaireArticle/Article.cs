using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace We.Louxor.InventaireArticle;

public class Article : FullAuditedAggregateRoot<Guid>, IArticle
{
    public string Code { get; set; }
    public string Designation { get; set; }
    public double CoutMatiereDirect { get; set; }
    public double CoutMachineDirect { get; set; }
}
