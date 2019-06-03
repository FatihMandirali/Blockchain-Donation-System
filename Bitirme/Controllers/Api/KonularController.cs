using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.KonularService;
using Application.KonularService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KonularController : ControllerBase
    {
        private readonly IKonularAppService _konularAppService;

        public KonularController(IKonularAppService konularAppService)
        {
            _konularAppService = konularAppService;
        }

        [HttpGet]
        public IActionResult GetKonularList()
        {
            var konular = _konularAppService.KonularList();
            return Ok(konular);
        }
        [HttpPost]
        public IActionResult PostKonuDuzenle(KonuIdRequest konuIdRequest)
        {
            var konular = _konularAppService.KonuDuzenle(konuIdRequest);
            return Ok(konular);
        }

        [HttpPost]
        public IActionResult PostKonuSil(KonuIdRequest konuIdRequest)
        {
             _konularAppService.KonuSil(konuIdRequest);
            return Ok();
        }
        [HttpPost]
        public IActionResult PostKonuGuncelle(KonuResponse konuResponse)
        {
            var konular = _konularAppService.KonuGuncelle(konuResponse);
            return Ok(konular);
        }
        [HttpPost]
        public IActionResult PostKonuEkle(KonuResponse konuResponse)
        {
          var baseRes =_konularAppService.KonuEkle(konuResponse);
            return Ok(baseRes);
        }
    }
}