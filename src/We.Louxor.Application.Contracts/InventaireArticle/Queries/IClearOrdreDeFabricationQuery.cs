using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface IClearOrdreDeFabricationQuery
    : IClearBaseQuery<ClearOrdreDeFabricationResponse>,
      IInventaireQuery<ClearOrdreDeFabricationResponse> { }

public sealed record ClearOrdreDeFabricationResponse() : Response;
