﻿using System.Diagnostics;

namespace We.Louxor.InventaireArticle;

[DebuggerDisplay("{Societe}-{Numero}-{CodeOperation}-{NumeroAR}")]
public class OrdreDeFabication : AggregateRoot<Guid>, IOrdreDeFabication
{
    public string Societe { get; set; } = string.Empty;
    public int Numero { get; set; }
    public int CodeOperation { get; set; }
    public int NumeroAR { get; set; }
    public string CodeClient { get; set; } = string.Empty;
    public string CodeArticle { get; set; } = string.Empty;
    public double Quantite { get; set; }
    public bool IsDeleted { get; }
    //public string Repr => $"{Numero}";
    //public string Repr_Autocompletion => $"{Numero}-{CodeArticle}";
}
