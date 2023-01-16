namespace We.Louxor.InventaireArticle;

public class OrdreDeFabication:AggregateRoot<Guid>, IOrdreDeFabication
{
    public int Numero{ get; set; }
}

public interface IOrdreDeFabication
{
    int Numero{ get; set; }
}
