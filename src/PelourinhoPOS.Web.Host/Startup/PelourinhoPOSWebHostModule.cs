using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PelourinhoPOS.Configuration;

namespace PelourinhoPOS.Web.Host.Startup
{
    [DependsOn(
       typeof(PelourinhoPOSWebCoreModule))]
    public class PelourinhoPOSWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PelourinhoPOSWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PelourinhoPOSWebHostModule).GetAssembly());
        }
    }
}
