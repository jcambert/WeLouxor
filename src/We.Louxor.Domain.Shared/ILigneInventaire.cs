using System;

namespace We.Louxor;

public interface ILigneInventaire: IFullAuditedObject
{
    int Page { get; set; }

    string Of { get; set; }
    string Ar { get; set; }
    Guid Article { get; set; }
    double Quantite { get; set; }
}
