using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public abstract class ClearBaseQuery<TResponse> : IClearBaseQuery<TResponse>
    where TResponse : Response
{
    public string Societe { get; set; } = string.Empty;
}
