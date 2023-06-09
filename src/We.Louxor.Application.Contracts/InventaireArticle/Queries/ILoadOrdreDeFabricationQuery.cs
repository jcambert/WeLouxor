namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadOrdreDeFabricationQuery
    : ILoadBaseQuery,
      IInventaireQuery<LoadOrdreDeFabricationResponse> { }

public sealed record LoadOrdreDeFabricationResponse();
