using System.Threading.Tasks;
using Abp.Application.Services;
using PelourinhoPOS.Sessions.Dto;

namespace PelourinhoPOS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
