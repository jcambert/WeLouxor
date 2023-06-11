using Volo.Abp.Application.Dtos;

namespace We.Louxor;

public class LigneDeCommandeDto : EntityDto
{
    public int NumeroDocument { get; set; }
    public int NumeroEntete => ((int)NumeroDocument / 1000);

    public int NumeroLigne => NumeroDocument - (NumeroEntete * 1000);

    /// <summary>
    /// codart
    /// </summary>
    public string CodeArticle { get; set; } = string.Empty;

    /// <summary>
    /// tprixun
    /// </summary>
    public double PrixUnitaire { get; set; }

    /// <summary>
    /// quanti
    /// </summary>
    public double QuantiteCommande { get; set; }

    /// <summary>
    /// datdem
    /// </summary>
    public DateOnly DelaiDemande { get; set; }

    /// <summary>
    /// sigsoc
    /// </summary>
    public string Societe { get; set; } = string.Empty;

    /// <summary>
    /// codcli
    /// </summary>
    public string CodeClient { get; set; } = string.Empty;
    public bool IsDeleted { get; }
}
