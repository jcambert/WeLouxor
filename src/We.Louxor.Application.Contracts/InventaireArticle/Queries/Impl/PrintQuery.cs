namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IPrintQuery))]
public class PrintQuery: IPrintQuery
{
    public const string DEFAULT_FILENAME = "inventaire.xlsx";
    public string Societe { get; set; } = "001";
    public string Filename { get; set; } = DEFAULT_FILENAME;
    public string SheetName { get; set; } = "inventaire";
}
