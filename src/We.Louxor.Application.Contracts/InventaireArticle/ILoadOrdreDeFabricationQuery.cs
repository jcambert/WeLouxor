namespace We.Louxor.InventaireArticle;

public interface ILoadOrdreDeFabricationQuery:IInventaireQuery<LoadOrdreDeFabricationResponse>
{
    string Filename { get; set; }
}
public sealed record LoadOrdreDeFabricationResponse();