using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace PelourinhoPOS.Controllers
{
    public abstract class PelourinhoPOSControllerBase: AbpController
    {
        protected PelourinhoPOSControllerBase()
        {
            LocalizationSourceName = PelourinhoPOSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
