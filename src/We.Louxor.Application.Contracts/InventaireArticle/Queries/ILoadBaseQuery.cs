namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadBaseQuery
{
    string Filename { get; set; }
    int? LimitRecordCountTo { get; set; }
    int LoadRecordStep { get; set; }
}
