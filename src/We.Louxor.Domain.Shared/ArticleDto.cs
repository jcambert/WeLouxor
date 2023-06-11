using Volo.Abp.Application.Dtos;

namespace We.Louxor;

public class ArticleDto : EntityDto
{
    public string Societe { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public double CoutMatiereDirect { get; set; }
    public double CoutMachineDirect { get; set; }
    public string Domaine { get; set; } = string.Empty;
    public bool IsDeleted { get; }
}
