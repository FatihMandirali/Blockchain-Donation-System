using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ReklamlarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReklamlarController : ControllerBase
    {
        private readonly IReklamlarAppService _reklamlarAppService;

        public ReklamlarController(IReklamlarAppService reklamlarAppService)
        {
            _reklamlarAppService = reklamlarAppService;
        }

        [HttpGet]
        public IActionResult GetReklamTarilerList()
        {
            var personellers = _reklamlarAppService.ReklamTarilerList();

            return Ok(personellers);

        }
    }
}