namespace We.Louxor.InventaireArticle;

public interface IOrdreDeFabication:IEntityLouxor
{
    int Numero{ get; set; }

    int CodeOperation { get;set; }

    int NumeroAR { get; set; }

    string CodeClient { get; set; }

    string CodeArticle { get; set; }

    double Quantite { get; set; }
}
