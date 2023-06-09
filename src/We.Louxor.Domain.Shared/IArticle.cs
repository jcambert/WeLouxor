namespace We.Louxor.InventaireArticle;

public interface IArticle : IEntityLouxor
{
    string Code { get; set; }

    string Designation { get; set; }

    double CoutMatiereDirect { get; set; }

    double CoutMachineDirect { get; set; }
}
