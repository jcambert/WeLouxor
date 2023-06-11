using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public abstract class LoadBaseQuery<TResponse> : ILoadBaseQuery<TResponse>
    where TResponse:Response
{
    public LoadBaseQuery()
    {
        Filename = GetDefaultFilename();
    }

    protected abstract string GetDefaultFilename();
    public virtual string Filename { get; set; }
    public virtual int From { get; set; } = 0;
    public virtual int? To { get; set; } = null;
    public virtual int LoadRecordStep { get; set; } = 100;
    public virtual bool TestForDuplicate { get; set; } = false;
    public virtual string Societe { get; set; } = LouxorAppConsts.LouxorDefaultSociete;
    public virtual bool ProduitVenduSeul { get; set; } = false;
}
