using Volo.Abp.Application.Dtos;

namespace We.Louxor;

public class ClientDto : EntityDto
{
    public string Code { get; set; } = string.Empty;
    public string Libelle { get; set; } = string.Empty;
    public string Societe { get; set; } = string.Empty;
    public bool IsDeleted { get; }
}
