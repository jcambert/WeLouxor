using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace We.Louxor.InventaireArticle;

public class LigneInventaire :  FullAuditedAggregateRoot<Guid>, IBaseLigneInventaire
{
    public int Page { get; set; }
    public int OrdreDeFabication { get; set; }
    public int CodeOperationFinie { get; set; }
    public int NumeroCommandeClient { get; set; }
    public Guid Article { get; set; }
    public Guid ArticleDeTete { get; set; }
    public double Quantite { get; set; }
    public double CoutMatiereDirect { get; set; }
    public double CoutMachineDirect { get; set; }


}
