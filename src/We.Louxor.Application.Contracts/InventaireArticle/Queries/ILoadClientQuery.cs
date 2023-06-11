using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadClientQuery : ILoadBaseQuery<LoadClientResponse>, IInventaireQuery<LoadClientResponse> { }

public sealed record LoadClientResponse():Response;
