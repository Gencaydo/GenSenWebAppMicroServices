﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venhancer.Shared.Dtos;

namespace ECommerceServices.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
