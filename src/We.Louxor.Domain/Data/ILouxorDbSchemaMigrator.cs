using System.Threading.Tasks;

namespace We.Louxor.Data;

public interface ILouxorDbSchemaMigrator
{
    Task MigrateAsync();
}
