using System.Threading.Tasks;
using Abp.Application.Services;
using PelourinhoPOS.Authorization.Accounts.Dto;

namespace PelourinhoPOS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
