using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class ClearCommandeClientHandler
    : ClearBaseHandler<
          ClearCommandeClientQuery,
          ClearCommandeClientResponse,
          LigneDeCommande,
          LigneDeCommandeDto
      >
{
    public ClearCommandeClientHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override ClearCommandeClientResponse GetResponse() =>
        new ClearCommandeClientResponse();
}
