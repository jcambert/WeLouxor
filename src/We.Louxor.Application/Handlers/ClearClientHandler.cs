using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class ClearClientHandler : ClearBaseHandler<ClearClientQuery, ClearClientResponse, Client, Guid>
{
    public ClearClientHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }


}
