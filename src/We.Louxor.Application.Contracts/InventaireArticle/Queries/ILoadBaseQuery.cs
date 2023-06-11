using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadBaseQuery<TResponse>:IQuery<TResponse>
    where TResponse : Response
{
    string Filename { get; set; }
    int From { get; set; }
    int? To { get; set; }
    int LoadRecordStep { get; set; }
    bool TestForDuplicate { get; set; }
    string Societe { get; set; }
    bool ProduitVenduSeul { get; set; }
}
