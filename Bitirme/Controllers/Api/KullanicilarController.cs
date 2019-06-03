using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.KullanicilarService;
using Application.KullanicilarService.DTO;
using Core.Model.Request;
using Core.Model.Response;
using Core.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KullanicilarController : ControllerBase
    {
        private readonly IKullanicilarAppService _kullanicilarAppService;

        public KullanicilarController(IKullanicilarAppService kullanicilarAppService)
        {
            _kullanicilarAppService = kullanicilarAppService;
        }

        [HttpPost]
        public IActionResult PostKullaniciEkle(KullaniciCreateRequest kullaniciCreateRequest)
        {
           var kullaniciEkle=  _kullanicilarAppService.KullaniciCreate(kullaniciCreateRequest);

            return Ok(kullaniciEkle);

        }
        [HttpPost]
        public IActionResult PostGenelFinans(GenelFinansRequest genelFinansRequest)
        {
           var genelFinansResponse=  _kullanicilarAppService.GenelFinans(genelFinansRequest);

            return Ok(genelFinansResponse);

        }
        [HttpPost]
        public IActionResult PostKullaniciBul(KullaniciAdRequest kullaniciAdRequest)
        {
           var kullanicilar=  _kullanicilarAppService.KullaniciBul(kullaniciAdRequest);

            return Ok(kullanicilar);

        }
    

        [HttpPost]
        public IActionResult PostKullaniciOdemeAl(OdemeAlRequest odemeAlRequest)
        {
            var baseResponse = _kullanicilarAppService.KullaniciOdemeAl(odemeAlRequest);

            return Ok(baseResponse);

        }

        [HttpPost]
        public IActionResult PostKullanicilarSil(KullaniciIdRequest kullaniciIdRequest)
        {
            var kullaniciSil = _kullanicilarAppService.KullaniciSil(kullaniciIdRequest);

            return Ok(kullaniciSil);

        }

        [HttpPost]
        public IActionResult PostKullaniciDuzenle(KullaniciIdRequest kullaniciIdRequest)
        {
            var kullaniciDuzenle = _kullanicilarAppService.KullaniciDuzenle(kullaniciIdRequest);

            return Ok(kullaniciDuzenle);

        }

        [HttpPost]
        public IActionResult PostKullaniciGuncelle(Kullanicilar kullanicilar)
        {
            var kullaniciDuzenle = _kullanicilarAppService.KullaniciGuncelle(kullanicilar);

            return Ok(kullaniciDuzenle);

        }
        

       [HttpGet]
        public IActionResult GetKullaniciList()
        {
            var kullaniciEkle = _kullanicilarAppService.KullaniciList();

            return Ok(kullaniciEkle);

        }
        [HttpGet]
        public IActionResult GetPesronelGenelFinans()
        {
            var kullaniciEkle = _kullanicilarAppService.PesronelGenelFinans();

            return Ok(kullaniciEkle);

        }

        [HttpPost]
        public IActionResult KullaniciLogin(Login login)
        {
            BaseResponse baseResponse = _kullanicilarAppService.KullaniciLogin(login);
            if (baseResponse.durum == true)
            {
                HttpContext.Session.SetString("KullaniciGiris", baseResponse.mesaj);
            }
            
            

            // string deger = HttpContext.Session.GetString("YoneticiGiris");

            return Ok(baseResponse);
        }

        [HttpGet]
        public IActionResult KullaniciLoginClose()
        {
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Çıkış Yapıldı";
            HttpContext.Session.Clear();

            return Ok(baseResponse);
        }
    }
}