namespace We.Louxor.InventaireArticle;

public class OrdreDeFabication:AggregateRoot<Guid>, IOrdreDeFabication
{
    public string Societe { get; set; }
    public int Numero{ get; set; }
}
