using System;

namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IUpdateLigneInventaireQuery))]
public class UpdateLigneInventaireQuery : IUpdateLigneInventaireQuery
{
    public Guid Id { get; set; }
    public BaseLigneInventaire Ligne { get; set; }
    public string Societe { get; set; } = LouxorAppConsts.LouxorDefaultSociete;
}
