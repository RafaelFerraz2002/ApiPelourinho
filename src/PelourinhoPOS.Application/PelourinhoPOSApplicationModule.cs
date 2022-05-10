using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PelourinhoPOS.Authorization;

namespace PelourinhoPOS
{
    [DependsOn(
        typeof(PelourinhoPOSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PelourinhoPOSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PelourinhoPOSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PelourinhoPOSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
