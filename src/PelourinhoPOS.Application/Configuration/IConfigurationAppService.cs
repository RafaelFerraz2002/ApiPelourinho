using System.Threading.Tasks;
using PelourinhoPOS.Configuration.Dto;

namespace PelourinhoPOS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
