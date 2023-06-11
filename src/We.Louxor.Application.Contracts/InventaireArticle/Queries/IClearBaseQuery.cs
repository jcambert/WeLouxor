using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface IClearBaseQuery<TResponse> : ISociete, IQuery<TResponse>
    where TResponse : Response { }
