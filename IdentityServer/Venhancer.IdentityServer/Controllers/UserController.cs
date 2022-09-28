using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venhancer.IdentityServer.Dtos;
using Venhancer.IdentityServer.Models;
using Venhancer.Shared.Dtos;
using static IdentityServer4.IdentityServerConstants;

namespace Venhancer.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]  
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDto.UserName,
                Email = signUpDto.Email
            };

            var result = await _userManager.CreateAsync(user, signUpDto.Password);

            if (!result.Succeeded) return BadRequest(Response<NoContent>.Fail(new ErrorDto { Errors = result.Errors.Select(x => x.Description).ToList() }, 400));

            return Ok(Response<NoContent>.Success(200));
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null) return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null) return BadRequest();

            return Ok(new {Id = user.Id,UserName = user.UserName,Email = user.Email});
        }
    }
}
