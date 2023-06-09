using Volo.Abp;

namespace We.Louxor;

public interface ISociete
{
    string Societe { get; set; }
}

public interface IEntityLouxor : ISociete, ISoftDelete { }
