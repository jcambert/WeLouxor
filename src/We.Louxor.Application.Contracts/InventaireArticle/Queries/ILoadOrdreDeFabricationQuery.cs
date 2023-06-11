using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadOrdreDeFabricationQuery
    : ILoadBaseQuery<LoadOrdreDeFabricationResponse>,
      IInventaireQuery<LoadOrdreDeFabricationResponse> { }

public sealed record LoadOrdreDeFabricationResponse():Response;
