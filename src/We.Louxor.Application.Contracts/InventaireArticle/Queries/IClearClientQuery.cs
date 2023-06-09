namespace We.Louxor.InventaireArticle.Queries;

public interface IClearClientQuery : IClearBaseQuery, IInventaireQuery<ClearClientResponse> { }

public sealed record ClearClientResponse();
