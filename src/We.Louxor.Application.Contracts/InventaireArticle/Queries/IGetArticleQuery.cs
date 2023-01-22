namespace We.Louxor.InventaireArticle.Queries;

public interface IGetArticleQuery:IInventaireQuery<GetArticleResponse>,ISociete
{
    string Code { get; set; }

    string Designation { get; set; }
}

public sealed record GetArticleResponse(IArticle Article):InventaireResponse;
