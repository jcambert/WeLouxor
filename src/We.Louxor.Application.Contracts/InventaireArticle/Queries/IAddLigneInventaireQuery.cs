using System;

namespace We.Louxor.InventaireArticle.Queries;

public interface IAddLigneInventaireQuery: IInventaireQuery<AddLigneInventaireResponse>
{
    // BaseLigneInventaire Ligne { get; set; }
    int Page { get; set; }
    int OrdreDeFabication { get; set; }
    int CodeOperationFinie { get; set; }
    int NumeroCommandeClient { get; set; }
    string Article { get; set; }
    double Quantite { get; set; }

    string Client { get; set; }
}

public sealed record AddLigneInventaireResponse(ILigneInventaire Ligne):InventaireResponse;