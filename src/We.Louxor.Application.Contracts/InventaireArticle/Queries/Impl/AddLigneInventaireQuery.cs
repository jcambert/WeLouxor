using System;

namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IAddLigneInventaireQuery))]
public class AddLigneInventaireQuery : IAddLigneInventaireQuery
{
    //public BaseLigneInventaire Ligne { get; set; }
    public int Page { get; set; }
    public string Societe { get; set; } = "001";
    public int OrdreDeFabication { get; set; }
    public int CodeOperationFinie { get; set; }
    public int NumeroCommandeClient { get; set; }
    public string Article { get; set; }
    public double Quantite { get; set; }
    public string Client { get; set; }
}
