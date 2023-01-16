

namespace We.Louxor.InventaireArticle;

public class LigneDeCommande : AggregateRoot<Guid>, ILigneDeCommande
{
    public int NumeroDocument { get; set; }
    public int NumeroEntete 
       =>((int) NumeroDocument / 1000);


    public int NumeroLigne
        => NumeroDocument - (NumeroEntete*1000);

    public string CodeArticle { get; set; }
    public double PrixUnitaire { get; set; }
    public double QuantiteCommande { get; set; }
    public DateOnly DelaiDemande { get; set; }
}

