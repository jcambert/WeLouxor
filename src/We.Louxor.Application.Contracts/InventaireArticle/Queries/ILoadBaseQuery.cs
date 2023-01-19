namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadBaseQuery
{
    string Filename { get; set; }
    int From { get; set; }
    int? To { get; set; }
    int LoadRecordStep { get; set; }
    bool TestForDuplicate { get; set; }
}
