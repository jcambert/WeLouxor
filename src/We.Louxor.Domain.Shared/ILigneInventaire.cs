﻿using System;

namespace We.Louxor;
public interface IBaseLigneInventaire
{
    int Page { get; set; }
    int OrdreDeFabication { get; set; }
    int CodeOperationFinie { get; set; }
    int NumeroCommandeClient { get; set; }
    Guid Article { get; set; }
    Guid ArticleDeTete { get; set; }
    double Quantite { get; set; }
}
public class BaseLigneInventaire : IBaseLigneInventaire
{
    public int Page { get; set; }
    public int OrdreDeFabication { get; set; }
    public int CodeOperationFinie { get; set; }
    public int NumeroCommandeClient { get; set; }
    public Guid Article { get; set; }
    public Guid ArticleDeTete { get; set; }
    public double Quantite { get; set; }
}
public interface ILigneInventaire: IFullAuditedObject
{
   
}
