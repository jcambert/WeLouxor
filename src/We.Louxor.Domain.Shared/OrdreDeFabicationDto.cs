using Volo.Abp.Application.Dtos;

namespace We.Louxor;

public class OrdreDeFabicationDto : EntityDto
{
    public string Societe { get; set; } = string.Empty;
    public int Numero { get; set; }
    public int CodeOperation { get; set; }
    public int NumeroAR { get; set; }
    public string CodeClient { get; set; } = string.Empty;
    public string CodeArticle { get; set; } = string.Empty;
    public double Quantite { get; set; }
    public bool IsDeleted { get; }
}
