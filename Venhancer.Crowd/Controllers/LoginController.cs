using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Venhancer.Crowd.Configuration;
using Venhancer.Crowd.Dtos;

namespace Venhancer.Crowd.Controllers
{
    public class LoginController : Controller
    {
        private readonly APIOptions _apiOptions;

        public LoginController(IOptions<APIOptions> apiOptions)
        {
            _apiOptions = apiOptions.Value;
        }

        public IActionResult _Login()
        {
            return View();
        }

        public IActionResult _SignOut()
        {
            return Redirect("~/Login");
        }

        [HttpPost]
        public async Task<JsonResult> UserSignIn([FromBody] LoginDto loginDto)
        {
            var createTokenResponse = new CreateTokenDto.Response();
            var createTokenDto = new CreateTokenDto.Request
            {
                 client_id = _apiOptions.CrowdIdentityCreateTokenClientId,
                 client_secret = _apiOptions.CrowdIdentityCreateTokenClientSecret,
                 grant_type = _apiOptions.CrowdIdentityCreateTokenClientGrantType,
                 username = loginDto.Email,
                 password = loginDto.Password,
            };

            try
            {
                createTokenResponse = await Services.CallAPIService.CallTokenAPI(_apiOptions.CrowdIdentityCreateTokenUrl,createTokenDto, _apiOptions.CrowdIdentityAPIBaseUrl);
                //var userDto = JsonConvert.DeserializeObject<Response<UserDto>>(createTokenResponse);
                //if (userDto.IsSuccessful)
                //{
                //    HttpContext.Session.SetString("userDtoData", createTokenResponse);
                //    HttpContext.Session.SetString("UserLoggedIn", "true");
                //}
                return Json(createTokenResponse);
            }
            catch (Exception ex)
            {
                return Json("Login Error.Please Contact with IT Departmant. Error Detail : " + ex.Message);
            }
        }
    }
}
