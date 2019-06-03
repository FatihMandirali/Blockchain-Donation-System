using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.YorumlarService;
using Application.YorumlarService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MakalelerController : ControllerBase
    {
        private readonly IYorumlarAppService _yorumlarAppService;

        public MakalelerController(IYorumlarAppService yorumlarAppService)
        {
            _yorumlarAppService = yorumlarAppService;
        }

        [HttpPost]
        public IActionResult PostYorumYap(YorumRequest yorumRequest)
        {
            var baseResponse = _yorumlarAppService.YorumYap(yorumRequest);

            return Ok(baseResponse);

        }
    }
}