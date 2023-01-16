using System;

namespace We.Louxor;
public interface IBaseLigneInventaire
{
    int Page { get; set; }
    string Of { get; set; }
    string Ar { get; set; }
    Guid Article { get; set; }
    double Quantite { get; set; }
}
public class BaseLigneInventaire : IBaseLigneInventaire
{
    public int Page { get; set; }
    public string Of { get; set; }
    public string Ar { get; set; }
    public Guid Article { get; set; }
    public double Quantite { get; set; }
}
public interface ILigneInventaire: IFullAuditedObject
{
   
}
