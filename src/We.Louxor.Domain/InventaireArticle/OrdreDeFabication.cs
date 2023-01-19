namespace We.Louxor.InventaireArticle;

public class OrdreDeFabication:AggregateRoot<Guid>, IOrdreDeFabication
{
    public string Societe { get; set; }
    public int Numero{ get; set; }
    public int CodeOperation { get; set; }
    public int NumeroAR { get; set; }
    public string CodeClient { get; set; }
    public string CodeArticle { get; set; }
    public double Quantite { get; set; }
}
