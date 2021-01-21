using Identity.ApplicationCore;
using Identity.Infrastructure;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Web
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private IFlowUserService userService;

        public ResourceOwnerPasswordValidator(IFlowUserService _userService)
        {
            this.userService = _userService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //由于运维有三种登录方式，如果是admin或super模式不走数据库校验
            string[] name = context.UserName.Split(',');
            string[] pwd = context.Password.Split(',');
            string type = pwd[1];

            Flow_Users user = null;
            if (type != "password")
            {
                user = userService.GetUserByTypeId(name[0], type);
            }
            else if (name.Length == 1 || name[1] != "admin" && name[1] != "super")
            {
                user = userService.GetUser(name[0], pwd[0]);
            }
            else
            {
                user = new Flow_Users();
            }

            if (user == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, "Invalid client credential");
            }
            else
            {
                context.Result = new GrantValidationResult(
                    subject: name[0],
                    authenticationMethod: "custom",
                    claims: new Claim[] {
                            new Claim("Name", name[0]),
                            new Claim("Token", user.TOKEN ?? "")
                    }
                );
            }
            return Task.CompletedTask;
        }
    }
}
