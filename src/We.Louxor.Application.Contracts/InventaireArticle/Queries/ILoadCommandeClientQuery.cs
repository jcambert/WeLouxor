namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadCommandeClientQuery:IInventaireQuery<LoadCommandeClientResponse>
{
    string Filename { get; set; }
}
public sealed record LoadCommandeClientResponse();