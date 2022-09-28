using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Venhancer.IdentityServer.Models;

namespace Venhancer.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userExxist = await _userManager.FindByEmailAsync(context.UserName);
            if (userExxist == null) 
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email or Password Wrong!!" });
                context.Result.CustomResponse = errors;
                return;
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(userExxist,context.Password);

            if (!passwordCheck) 
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email or Password Wrong!!" });
                context.Result.CustomResponse = errors;
                return;
            }

            context.Result = new GrantValidationResult(userExxist.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
