using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venhancer.IdentityServer.Dtos;
using Venhancer.IdentityServer.Mapping;
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
        public async Task<Response<UserDto>> SignUp([FromBody] SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDto.UserName,
                Email = signUpDto.Email
            };

            var result = await _userManager.CreateAsync(user, signUpDto.Password);

            if (!result.Succeeded) return Response<UserDto>.Fail(new ErrorDto { Errors = result.Errors.Select(x => x.Description).ToList() }, 400);

            return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);
        }

        [HttpGet]
        public async Task<Response<UserDto>> SignIn()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null) return Response<UserDto>.Fail(new ErrorDto("UserName or Password Wrong!", true), 404);


            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null) return Response<UserDto>.Fail(new ErrorDto("UserName or Password Wrong!", true), 404);

            return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);
        }
    }
}
