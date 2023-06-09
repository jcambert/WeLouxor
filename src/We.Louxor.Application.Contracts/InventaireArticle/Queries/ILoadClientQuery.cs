namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadClientQuery : ILoadBaseQuery, IInventaireQuery<LoadClientResponse> { }

public sealed record LoadClientResponse();
