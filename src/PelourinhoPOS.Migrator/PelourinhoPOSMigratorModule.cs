using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PelourinhoPOS.Configuration;
using PelourinhoPOS.EntityFrameworkCore;
using PelourinhoPOS.Migrator.DependencyInjection;

namespace PelourinhoPOS.Migrator
{
    [DependsOn(typeof(PelourinhoPOSEntityFrameworkModule))]
    public class PelourinhoPOSMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PelourinhoPOSMigratorModule(PelourinhoPOSEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(PelourinhoPOSMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PelourinhoPOSConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PelourinhoPOSMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
