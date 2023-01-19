namespace We.Louxor.InventaireArticle;

public class Client : AggregateRoot<Guid>, IClient
{
    public string Code { get; set; }
    public string Libelle { get; set; }
    public string Societe { get; set; }
}
