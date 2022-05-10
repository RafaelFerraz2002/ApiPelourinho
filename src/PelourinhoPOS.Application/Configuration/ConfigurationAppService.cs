using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using PelourinhoPOS.Configuration.Dto;

namespace PelourinhoPOS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PelourinhoPOSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
