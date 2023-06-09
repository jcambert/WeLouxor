using MediatR;

namespace We.Louxor;

public interface IBaseInventaireQuery { }

public interface IInventaireQuery<TResponse> : IBaseInventaireQuery, IRequest<TResponse>
    where TResponse : class { }

public abstract record InventaireResponse
{
    public bool FromDatabase { get; set; }
    public bool FromCache { get; set; }
}
