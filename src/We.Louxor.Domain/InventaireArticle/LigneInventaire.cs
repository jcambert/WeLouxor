using System.Diagnostics;
using Volo.Abp.Domain.Entities.Auditing;

namespace We.Louxor.InventaireArticle;

[DebuggerDisplay("{Page}-{Article}-{Quantite}-{CtRevient}-{ValoFinale}")]
public class LigneInventaire : FullAuditedAggregateRoot<Guid>, ILigneInventaire
{
    public int Page { get; set; }
    public int OrdreDeFabication { get; set; }
    public int CodeOperationFinie { get; set; }
    public int NumeroCommandeClient { get; set; }
    public Guid ArticleId { get; set; }
    public string Article { get; set; }
    public Guid ArticleDeTeteId { get; set; }
    public string Client { get; set; }
    public string ArticleDeTete { get; set; }
    public double Quantite { get; set; }
    public double PvArticleDeTete { get; set; }
    public double PuGamme { get; set; }
    public double PuNomenclature { get; set; }
    public double CtRevient => PuGamme + PuNomenclature;
    public double ValoFinale => CtRevient * Quantite;
    public string Type => Article == ArticleDeTete ? "PF" : "SF";
    public string Societe { get; set; }
}
