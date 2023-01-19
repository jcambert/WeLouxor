namespace We.Louxor.InventaireArticle.Queries;
[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadClientQuery))]
public class LoadClientQuery: ILoadClientQuery
{
    public string Filename { get; set; } = @"ptfour.dbf";
    public int From { get; set; } = 0;
    public int? To { get; set; } = null;
    public int LoadRecordStep { get; set; } = 100;
    public bool TestForDuplicate { get; set; } = false;
}
