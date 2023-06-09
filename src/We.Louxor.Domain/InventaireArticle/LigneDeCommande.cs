using System.Diagnostics;

namespace We.Louxor.InventaireArticle;

[DebuggerDisplay("{Societe}-{NumeroDocument}-{CodeArticle}")]
public class LigneDeCommande : AggregateRoot<Guid>, ILigneDeCommande
{
    /// <summary>
    /// numdo
    /// </summary>
    public int NumeroDocument { get; set; }
    public int NumeroEntete => ((int)NumeroDocument / 1000);

    public int NumeroLigne => NumeroDocument - (NumeroEntete * 1000);

    /// <summary>
    /// codart
    /// </summary>
    public string CodeArticle { get; set; }

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
    public string Societe { get; set; }

    /// <summary>
    /// codcli
    /// </summary>
    public string CodeClient { get; set; }
    public bool IsDeleted { get; }
}
