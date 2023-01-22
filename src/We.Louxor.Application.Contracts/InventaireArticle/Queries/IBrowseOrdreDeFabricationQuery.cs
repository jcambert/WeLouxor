namespace We.Louxor.InventaireArticle.Queries;

public interface IBrowseOrdreDeFabricationQuery:IInventaireQuery<BrowseOrdreDeFabricationResponse>,ISociete
{
}

public sealed record BrowseOrdreDeFabricationResponse(List<int> Ofs);
