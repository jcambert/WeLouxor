using ClosedXML.Excel;
using System.IO;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class PrintHandler : BaseHandler<PrintQuery, PrintResponse>
{
    const string CONTENT_TYPE = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    List<string> HEADER=new List<string>() { "Page", "TYPE", "NUMERO \nOF", "NUM OP.\nTERMINEE", "CLIENT", "ARTICLE", "QUANTITE", "AR \nCOMMANDE", "ARTICLE\nBASE", "P.V \nART. BASE", "P.U\nGamme", "P.U Nomenclat.", "Ct\nrevient", "Valo\nFinale" };
    protected IRepository<LigneInventaire, Guid> _repo => LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();
    public PrintHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<PrintResponse> Handle(PrintQuery request, CancellationToken cancellationToken)
    {

        if (string.IsNullOrEmpty(request.Filename))
            throw new ArgumentException("Le parametre Filename doit etre rempli");
        request.SheetName = string.IsNullOrEmpty(request.SheetName) ? "Inventaire" : request.SheetName;

        var query = await _repo.GetQueryableAsync();
        query = from q in query where q.Societe == request.Societe orderby q.Page, q.Article select q;

        var lignes = await AsyncExecuter.ToListAsync(query, cancellationToken);
        using (var workbook = new XLWorkbook())
        {
            var sheet = workbook.Worksheets.Add($"{request.SheetName}");
            int row = 1;
            int col = 1;
            FillHeader(sheet, row++);
            foreach (var ligne in lignes)
            {
                sheet.Cell(row, col++).Value = ligne.Page;
                sheet.Cell(row, col++).Value = ligne.Type;
                sheet.Cell(row, col++).Value = ligne.OrdreDeFabication;
                sheet.Cell(row, col++).Value = ligne.CodeOperationFinie;
                sheet.Cell(row, col++).Value = ligne.Client;
                sheet.Cell(row, col++).Value = ligne.Article;
                sheet.Cell(row, col++).Value = ligne.Quantite;
                sheet.Cell(row, col++).Value = ligne.NumeroCommandeClient;
                sheet.Cell(row, col++).Value = ligne.ArticleDeTete;
                sheet.Cell(row, col++).Value = ligne.PvArticleDeTete;
                sheet.Cell(row, col++).Value = ligne.PuGamme;
                sheet.Cell(row, col++).Value = ligne.PuNomenclature;
                sheet.Cell(row, col++).Value = ligne.CtRevient;
                sheet.Cell(row, col++).Value = ligne.ValoFinale;
                col = 1;
                row++;
            }
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return new PrintResponse(content, CONTENT_TYPE, request.Filename);
            }
        }
    }

    private void FillHeader(IXLWorksheet sheet, int row)
    {
        int col = 1;
        foreach (var h in HEADER)
        {
            sheet.Cell(row, col++).Value = h;

        }
    }
}
