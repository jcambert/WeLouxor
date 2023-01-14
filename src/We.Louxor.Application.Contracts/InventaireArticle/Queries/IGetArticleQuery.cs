using System;
using System.Collections.Generic;
using System.Text;

namespace We.Louxor.InventaireArticle.Queries;

public interface IGetArticleQuery:IInventaireQuery<GetArticleResponse>
{
    string Code { get; set; }

    string Designation { get; set; }
}

public sealed record GetArticleResponse(IArticle Article):InventaireResponse;
