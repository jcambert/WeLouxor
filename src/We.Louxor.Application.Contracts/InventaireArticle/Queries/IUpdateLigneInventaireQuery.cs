﻿using System;

namespace We.Louxor.InventaireArticle.Queries;

public interface IUpdateLigneInventaireQuery : IInventaireQuery<UpdateLigneInventaireResponse>
{
    Guid Id { get; set; }
    ILigneInventaire Ligne { get; set; }
}
public sealed record UpdateLigneInventaireResponse(ILigneInventaire Ligne):InventaireResponse;

