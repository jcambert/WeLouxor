namespace We.Louxor.InventaireArticle.Queries;

public interface IPrintQuery: IInventaireQuery<PrintResponse>
{
    string Societe { get; set; }
    string SheetName { get; set; }
}

public sealed record PrintResponse(byte[] Content,string ContentType,string Filename);