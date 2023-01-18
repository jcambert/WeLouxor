namespace We.Louxor.InventaireArticle;
public class Article : AggregateRoot<Guid>, IArticle
{
    public string Societe { get; set; }
    public string Code { get; set; }
    public string Designation { get; set; }
    public double CoutMatiereDirect { get; set; }
    public double CoutMachineDirect { get; set; }
}
