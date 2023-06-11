
using We.Mediatr;

namespace We.Louxor;

public interface IBaseInventaireQuery { }

public interface IInventaireQuery<TResponse> : IBaseInventaireQuery, IQuery<TResponse>
    where TResponse : Response
{ }

public abstract record InventaireResponse:Response
{
    public bool FromDatabase { get; set; }
    public bool FromCache { get; set; }
}
