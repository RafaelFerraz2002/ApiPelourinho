using System.Threading.Tasks;
using PelourinhoPOS.Models.TokenAuth;
using PelourinhoPOS.Web.Controllers;
using Shouldly;
using Xunit;

namespace PelourinhoPOS.Web.Tests.Controllers
{
    public class HomeController_Tests: PelourinhoPOSWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}