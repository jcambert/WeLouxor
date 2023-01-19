namespace We.Louxor;

public interface IClient:IEntityLouxor
{
    string Code { get; set; }
    string Libelle { get; set; }
}
