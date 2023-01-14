namespace We.Louxor.InventaireArticle.Queries.Impl;

public class GetArticleQuery : IGetArticleQuery
{
    public string Code { get; set; }
    public string Designation { get; set; }
}
