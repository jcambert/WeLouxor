using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace We.Louxor.InventaireArticle;

public class LigneInventaire : FullAuditedAggregateRoot<Guid>, ILigneInventaire
{
    public int Page { get; set; }
    public string Of { get; set; }
    public string Ar { get; set; }
    public Guid Article { get; set; }
    public double Quantite { get; set; }
}
