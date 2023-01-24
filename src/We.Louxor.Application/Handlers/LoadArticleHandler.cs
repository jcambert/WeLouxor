using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadArticleHandler : BaseLoadHandler<LoadArticleQuery, LoadArticleResponse, Article, Guid>
{
    List<Article> articles = new();
    public LoadArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
    protected override bool CheckForDuplicate(List<Article> records)
    {
        bool result = true;

        var query = records.GroupBy(x => $"{x.Societe}-{x.Code}")
              .Where(g => g.Count() > 1)
              //.Select(y => y.Key)
              .ToList();
        if (query.Count() > 0)
        {
            foreach (var item in query)
            {
                Logger.LogWarning($"{item} was duplicates in records".FormatWarning());
            }
#if DEBUG
                Debugger.Break();
#endif
            records.RemoveAll(x => records.Any(p => p.Societe == x.Societe && p.Code == x.Code));
            result = false;
        }


        var query1 = articles.Where(c => records.Any(p => c.Societe == p.Societe && c.Code == p.Code));
        if (query1.Count() > 0)
        {
            foreach (var item in query1)
            {
                Logger.LogWarning($"{item.Societe}-{item.Code} was duplicates in results".FormatWarning());
            }

#if DEBUG
            Debugger.Break();
#endif

            records.RemoveAll(x => articles.Any(p => p.Societe == x.Societe && p.Code == x.Code));
            result = false;
        }
        articles.AddRange(records);
       



        return result;
    }
   /* protected override List<Article> Filter(List<Article> records, bool removeDuplicates = false)
    => base.Filter( records.Where(x => !string.IsNullOrEmpty(x.Societe) && !string.IsNullOrEmpty(x.Code)).ToList());*/

    protected override Func<Article, bool> GetPredicateFilter()
    => (Article entity) =>
    {
        var result = true;
        if (Request != null)
        {
            result= entity.Societe == Request.Societe && !string.IsNullOrEmpty(entity.Code);
            if (Request.ProduitVenduSeul)
                result = result && entity.Domaine == "V";
        }
        return result;
    };

}
/*
public class LoadArticleHandler : BaseHandler<LoadArticleQuery, LoadArticleResponse>
{
    public LoadArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<LoadArticleResponse> Handle(LoadArticleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}*/
