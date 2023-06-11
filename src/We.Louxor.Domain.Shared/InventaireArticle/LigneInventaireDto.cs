using Volo.Abp.Application.Dtos;

namespace We.Louxor.InventaireArticle;

public class LigneInventaireDto : EntityDto<Guid>
{
    public int Page { get; set; }
    public int OrdreDeFabication { get; set; }
    public int CodeOperationFinie { get; set; }
    public int NumeroCommandeClient { get; set; }
    public Guid ArticleId { get; set; }
    public string Article { get; set; } = string.Empty;
    public Guid ArticleDeTeteId { get; set; }
    public string Client { get; set; } = string.Empty;
    public string ArticleDeTete { get; set; } = string.Empty;
    public double Quantite { get; set; }
    public double PvArticleDeTete { get; set; }
    public double PuGamme { get; set; }
    public double PuNomenclature { get; set; }
    public double CtRevient => PuGamme + PuNomenclature;
    public double ValoFinale => CtRevient * Quantite;
    public string Type => Article == ArticleDeTete ? "PF" : "SF";
    public string Societe { get; set; } = string.Empty;
}
