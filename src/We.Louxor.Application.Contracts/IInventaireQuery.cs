using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace We.Louxor;

public interface IBaseInventaireQuery
{
}

public interface IInventaireQuery<TResponse> : IBaseInventaireQuery, IRequest<TResponse>
    where TResponse : class
{
}

public abstract record InventaireResponse
{
    public bool FromDatabase { get; set; }
    public bool FromCache { get; set; }
}
