using We.Louxor.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace We.Louxor;

[DependsOn(typeof(LouxorEntityFrameworkCoreTestModule))]
public class LouxorDomainTestModule : AbpModule { }
