using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrlAddress.Core.Contracts.Services;
using ShortUrlAddress.Core.Entities.Dtos.UserInfo.InputDtos;

namespace ShortUrlAddress.EndPoints.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShorUrlController : ControllerBase
    {
        private readonly IShortUrlAddressService shortUrlservice;

        public ShorUrlController(IShortUrlAddressService shortUrlservice)
        {
            this.shortUrlservice = shortUrlservice;
        }

        [HttpGet]
        [Route("RedirectToUrl")]
        public async Task<IActionResult> RedirectToUrl(int? shortcode)
        {
            if(!shortcode.HasValue)
                return StatusCode(404);

            var urladdress = await shortUrlservice.GetCompleteAddress(shortcode.Value);

            if (urladdress != null && urladdress.Trim().Length > 0)                            
                return RedirectPermanent(urladdress);
            else
                return StatusCode(404);
        }

        [HttpPost]
        [Route("ConvertToShortUrl")]
        public async Task<IActionResult> ConverToShortUrl(AddShortUrlDto model)
        {
            var Result = await shortUrlservice.ConvertUrlToShortUrl(model);
            if (!Result.IsSuccess)
                return StatusCode(404, new { Message = Result.ErrorMessage });

            return StatusCode(200, new { Result.ShortUrlCode });
        }
    }
}