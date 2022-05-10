using Abp.Authorization;
using PelourinhoPOS.Authorization.Roles;
using PelourinhoPOS.Authorization.Users;

namespace PelourinhoPOS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
