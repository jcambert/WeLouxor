using Volo.Abp.Domain.Entities;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class AddLigneInventaireHandler
    : BaseHandler<AddLigneInventaireQuery, AddLigneInventaireResponse>
{
    protected IRepository<LigneInventaire, Guid> _inv_repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();
    protected IRepository<Article, Guid> _article_repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<Article, Guid>>();
    protected IRepository<OrdreDeFabication, Guid> _of_repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<OrdreDeFabication, Guid>>();
    protected IRepository<LigneDeCommande, Guid> _commande_repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<LigneDeCommande, Guid>>();
    protected IRepository<Client, Guid> _client_repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<Client, Guid>>();

    public AddLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }


    protected override async Task<Result<AddLigneInventaireResponse>> InternalHandle(AddLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        Article article = null;
        Article articleTete = null;
        LigneDeCommande cde_surcout = null;
        LigneDeCommande cde = null;
        OrdreDeFabication of = null;
        Client client = null;

        Func<string, Task<Article>> FindArticleByCode = async (code) =>
        {
            var query1 = await _article_repository.GetQueryableAsync();
            query1 = from q in query1 where q.Societe == request.Societe && q.Code == code select q;
            return await AsyncExecuter.FirstOrDefaultAsync(query1, cancellationToken);
        };

        Func<int, Task<LigneDeCommande>> FindCommandeByNumero = async (numero) =>
        {
            var query2 = await _commande_repository.GetQueryableAsync();
            query2 =
                from q in query2
                where q.Societe == request.Societe && q.NumeroDocument == numero
                select q;
            return await AsyncExecuter.FirstOrDefaultAsync(query2, cancellationToken);
        };
        Func<int, Task<LigneDeCommande>> FindCommandeSurcout = async (numero) =>
        {
            var query7 = await _commande_repository.GetQueryableAsync();
            query7 =
                from q in query7
                where
                    q.Societe == request.Societe
                    && q.NumeroDocument > (numero * 1000)
                    && q.NumeroDocument < (numero * 1000 + 999)
                    && q.CodeArticle.StartsWith($"{articleTete.Code}SURCOUT")
                select q;
            return await AsyncExecuter.FirstOrDefaultAsync(query7, cancellationToken);
        };
        Func<int, int, string, Task<OrdreDeFabication>> FindOfByNumero = async (
            numero,
            op,
            article
        ) =>
        {
            var query3 = await _of_repository.GetQueryableAsync();
            query3 =
                from q in query3
                where q.Societe == request.Societe && q.Numero == numero && q.CodeOperation == op
                select q;
            if (!string.IsNullOrEmpty(article))
                query3 = from q in query3 where q.CodeArticle == article select q;
            return await AsyncExecuter.FirstOrDefaultAsync(query3, cancellationToken);
        };

        Func<int, string, Task<OrdreDeFabication>> FindOfByNumeroAr = async (ar, article) =>
        {
            var query = await _of_repository.GetQueryableAsync();
            query =
                from q in query
                where q.Societe == request.Societe && q.NumeroAR == ar && q.CodeArticle == article
                select q;
            return await AsyncExecuter.FirstOrDefaultAsync(query, cancellationToken);
        };

        Func<string, Task<Client>> FindClientByCode = async (code) =>
        {
            var query9 = await _client_repository.GetQueryableAsync();
            query9 = from q in query9 where q.Societe == request.Societe && q.Code == code select q;
            return await AsyncExecuter.FirstOrDefaultAsync(query9, cancellationToken);
        };

        Func<int, int, Task<double>> FindCoeficientOperation = async (of, op) =>
        {
            var query8 = await _of_repository.GetQueryableAsync();
            query8 = from q in query8 where q.Societe == request.Societe && q.Numero == of select q;
            var operations = await AsyncExecuter.ToListAsync(query8);
            int total_operation = operations.Count;
            int current_operation = operations.Where(o => o.CodeOperation <= op).Count();
            return (1.0 * current_operation) / (1.0 * total_operation);
        };

        if (string.IsNullOrEmpty(request.Societe))
            throw new ArgumentException($"Societe doit etre affecté");
        if (
            string.IsNullOrEmpty(request.Article)
            && (request.OrdreDeFabication == 0 && request.NumeroCommandeClient == 00)
        )
            throw new ArgumentException(
                "La requete sans article doit avoir soit un N° d'Ar soit  un N° d'Of"
            );
        if (request.OrdreDeFabication > 0 && request.CodeOperationFinie == 0)
            throw new AggregateException(
                "Lorsque le N° d'Of est donné, vous devez indiquer le N° de l'operation"
            );
        if (!string.IsNullOrEmpty(request.Article))
        {
            //Recherche de l'article inventorie
            article = await FindArticleByCode(request.Article);
            /*var query1 = await _article_repository.GetQueryableAsync();
            query1 = from q in query1 where q.Societe == request.Societe && q.Code == request.Article select q;
            article = await AsyncExecuter.FirstOrDefaultAsync(query1, cancellationToken);*/
            if (article == null)
                throw new EntityNotFoundException(
                    $"L'article {request.Societe}-{request.Article} n'existe pas"
                );
        }

        //Recherche de la commande associée
        if (request.NumeroCommandeClient > 0)
        {
            /*var query2 = await _commande_repository.GetQueryableAsync();
            query2 = from q in query2 where q.Societe == request.Societe && q.NumeroDocument == request.NumeroCommandeClient select q;
            cde = await AsyncExecuter.FirstOrDefaultAsync(query2, cancellationToken);*/
            cde = await FindCommandeByNumero(request.NumeroCommandeClient);
            if (cde == null)
                throw new EntityNotFoundException(
                    $"la commande {request.Societe}-{request.NumeroCommandeClient} avec l'article {article.Code} n'existe pas"
                );
            if (article == null)
                //Recherche de l'article inventorie
                article = await FindArticleByCode(cde.CodeArticle);
        }

        //Recherche de l'of associé
        if (request.OrdreDeFabication > 0)
        {
            /*var query3 = await _of_repository.GetQueryableAsync();
            query3 = from q in query3 where q.Societe == request.Societe && q.Numero == request.OrdreDeFabication && q.CodeOperation == request.CodeOperationFinie select q;
            if (!string.IsNullOrEmpty(request.Article))
                query3 = from q in query3 where q.CodeArticle == article.Code select q;
            of = await AsyncExecuter.FirstOrDefaultAsync(query3, cancellationToken);*/
            of = await FindOfByNumero(
                request.OrdreDeFabication,
                request.CodeOperationFinie,
                request.Article
            );
            if (of == null && !string.IsNullOrEmpty(request.Article))
                throw new EntityNotFoundException(
                    $"L'of {request.Societe}-{request.OrdreDeFabication}-{request.CodeOperationFinie} avec l'article {article.Code} n'existe pas"
                );
            else if (of == null)
                throw new EntityNotFoundException(
                    $"L'of {request.Societe}-{request.OrdreDeFabication}-{request.CodeOperationFinie}  n'existe pas"
                );
            if (cde == null)
            {
                /*var query10 = await _commande_repository.GetQueryableAsync();
                query10 = from q in query10 where q.Societe == request.Societe && q.NumeroDocument == of.NumeroAR select q;
                cde = await AsyncExecuter.FirstOrDefaultAsync(query10, cancellationToken);*/
                cde = await FindCommandeByNumero(of.NumeroAR);
                request.NumeroCommandeClient =
                    cde != null ? cde.NumeroDocument : request.NumeroCommandeClient;
            }
            if (article == null)
            {
                /*var query11 = await _article_repository.GetQueryableAsync();
                query11 = from q in query11 where q.Societe == request.Societe && q.Code == of.CodeArticle select q;
                article = await AsyncExecuter.FirstOrDefaultAsync(query11, cancellationToken);*/
                article = await FindArticleByCode(of.CodeArticle);
                if (article == null)
                    throw new EntityNotFoundException(
                        $"L'article {of.CodeArticle} provenant de l'Of {of.Numero} n'existe pas"
                    );
            }
            if (cde != null && string.IsNullOrEmpty(request.Client))
            {
                /* var query9 = await _client_repository.GetQueryableAsync();
                 query9 = from q in query9 where q.Societe == request.Societe && q.Code == of.CodeClient select q;
                 client = await AsyncExecuter.FirstOrDefaultAsync(query9, cancellationToken);*/
                client = await FindClientByCode(of.CodeClient);

                request.Client = client == null ? string.Empty : client.Libelle;
            }
        }

        if (cde != null)
        {
            if (of == null)
            {
                of = await FindOfByNumeroAr(cde.NumeroDocument, article?.Code ?? string.Empty);
                request.OrdreDeFabication = of != null ? of.Numero : request.OrdreDeFabication;
            }
            //Recherche de l'article de tete
            articleTete = await FindArticleByCode(cde.CodeArticle);
            if (articleTete == null)
                throw new EntityNotFoundException(
                    $"L'article de tete {request.Societe}-{cde.CodeArticle} n'existe pas"
                );
            if (client == null)
            {
                //Recherche du client a partir de la commande
                client = await FindClientByCode(cde.CodeClient);
                request.Client = client == null ? string.Empty : client.Libelle;
            }

            //Recherche des surcout
            cde_surcout = await FindCommandeSurcout(cde.NumeroEntete);
        }

        double coef = 1.0;
        if (of != null)
        {
            if (client == null)
            {
                //Recherche du client à partir de l'Of
                client = await FindClientByCode(of.CodeClient);
                request.Client = client == null ? string.Empty : client.Libelle;
            }
            //Recherche de toutes les operations sur l'of
            coef = await FindCoeficientOperation(of.Numero, of.CodeOperation);
        }
        LigneInventaire inventaire =
            new()
            {
                Page = request.Page,
                OrdreDeFabication = request.OrdreDeFabication,
                CodeOperationFinie = request.CodeOperationFinie,
                NumeroCommandeClient = request.NumeroCommandeClient,
                ArticleId = article?.Id ?? Guid.Empty,
                Article = article?.Code ?? string.Empty,
                ArticleDeTeteId = articleTete?.Id ?? Guid.Empty,
                ArticleDeTete = articleTete?.Code ?? string.Empty,
                Quantite = request.Quantite,
                Client = request.Client ?? string.Empty,
                PvArticleDeTete = (cde?.PrixUnitaire ?? 0.0) + (cde_surcout?.PrixUnitaire ?? 0.0),
                PuGamme = article?.CoutMachineDirect * coef ?? 0.0,
                PuNomenclature = article?.CoutMatiereDirect * coef ?? 0.0,
                Societe = request.Societe,
            };
        await _inv_repository.InsertAsync(inventaire);
        LigneInventaireDto res = ObjectMapper.Map<LigneInventaire, LigneInventaireDto>(inventaire);
        return new AddLigneInventaireResponse(res);
    }

}
