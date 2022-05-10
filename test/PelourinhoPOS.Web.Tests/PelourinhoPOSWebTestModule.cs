using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PelourinhoPOS.EntityFrameworkCore;
using PelourinhoPOS.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace PelourinhoPOS.Web.Tests
{
    [DependsOn(
        typeof(PelourinhoPOSWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class PelourinhoPOSWebTestModule : AbpModule
    {
        public PelourinhoPOSWebTestModule(PelourinhoPOSEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PelourinhoPOSWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PelourinhoPOSWebMvcModule).Assembly);
        }
    }
}