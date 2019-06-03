using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.PersonelService;
using Application.PersonelService.DTO;
using Core.Model.Request;
using Core.Model.Response;
using Core.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonellerController : ControllerBase
    {
        private readonly IPersonelAppService _personelAppService;

        public PersonellerController(IPersonelAppService personelAppService)
        {
            _personelAppService = personelAppService;
        }

        [HttpGet]
        public IActionResult GetPersonellerList()
        {
           var personellers = _personelAppService.PersonellerList();
            
            return Ok(personellers);

        }

        [HttpPost]
        public IActionResult PostPersonelDuzenle(PersonelKullaniciAdiRequest personelKullaniciAdiRequest)
        {
            var personellers = _personelAppService.PersonelDuzenle(personelKullaniciAdiRequest);

            return Ok(personellers);

        }
        [HttpPost]
        public IActionResult PostGenelBilgiGuncelle(Personeller personeller)
        {
            var baseResponse = _personelAppService.GenlBilgiGuncelle(personeller);

            return Ok(baseResponse);

        }

        [HttpPost]
        public IActionResult PostPersonelSil(PersonelKullaniciAdiRequest personelKullaniciAdiRequest)
        {
            var personellers = _personelAppService.PersonelSil(personelKullaniciAdiRequest);

            return Ok(personellers);

        }

        [HttpPost]
        public IActionResult PostPersonelEkle( PersonelCreateRequest personelCreateRequest)
        {
            

            var personellers = _personelAppService.PersonelEkle(personelCreateRequest);
           
            return Ok(personellers);

        }

        [HttpPost]
        public IActionResult YoneticiLogin(Login login)
        {
            BaseResponse baseResponse = _personelAppService.YoneticiLogin(login);
            if (baseResponse.durum == true)
                HttpContext.Session.SetString("YoneticiGiris", baseResponse.mesaj);

           // string deger = HttpContext.Session.GetString("YoneticiGiris");
           
            return Ok(baseResponse);
        }

        [HttpGet]
        public IActionResult YoneticiLoginClose()
        {
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Çıkış Yapıldı";
             HttpContext.Session.Clear();
            return Ok(baseResponse);
        }
    }
}