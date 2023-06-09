using System;

namespace We.Louxor;

public interface ILigneDeCommande : IEntityLouxor
{
    int NumeroDocument { get; set; }
    int NumeroEntete { get; }
    int NumeroLigne { get; }
    string CodeArticle { get; set; }
    double PrixUnitaire { get; set; }
    double QuantiteCommande { get; set; }
    DateOnly DelaiDemande { get; set; }
}
