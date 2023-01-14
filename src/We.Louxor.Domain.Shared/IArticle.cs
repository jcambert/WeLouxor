namespace We.Louxor.InventaireArticle;

public interface IArticle: IFullAuditedObject
{
    string Code { get; set; }

    string Designation { get; set; }

    double CoutMatiereDirect { get; set; }

    double CoutMachineDirect { get; set; }

}
