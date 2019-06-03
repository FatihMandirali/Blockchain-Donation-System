using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.KullaniciMakalelerService;
using Application.KullaniciMakalelerService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KullaniciMakalelerController : ControllerBase
    {
        private readonly IKullaniciMakalelerAppService _kullaniciMakalelerAppService;

        public KullaniciMakalelerController(IKullaniciMakalelerAppService kullaniciMakalelerAppService)
        {
            _kullaniciMakalelerAppService = kullaniciMakalelerAppService;
        }

        [HttpGet]
        public IActionResult GetBlogList()
        {
            var blogListResponses = _kullaniciMakalelerAppService.BlogList();

            return Ok(blogListResponses);

        }
        [HttpGet]
        public IActionResult GetYoneticiBagisList()
        {
            var transactions = _kullaniciMakalelerAppService.YoneticiBagisList();

            return Ok(transactions);

        }
        [HttpGet]
        public IActionResult GetYoneticiCoinGenel()
        {
            var coinGenelResponse = _kullaniciMakalelerAppService.YoneticiCoinGenel();

            return Ok(coinGenelResponse);

        }
        [HttpGet]
        public IActionResult GetCoinKur()
        {
            var coinKurAll = _kullaniciMakalelerAppService.CoinKur();

            return Ok(coinKurAll);

        }

        [HttpGet]
        public IActionResult GetBlogOnayBekleyenList()
        {
            var yoneticiAdminBlogListResponses = _kullaniciMakalelerAppService.BlogOnayBekleyenList();

            return Ok(yoneticiAdminBlogListResponses);

        }
        [HttpGet]
        public IActionResult GetBlogOnaylananList()
        {
            var yoneticiAdminBlogListResponses = _kullaniciMakalelerAppService.BlogOnaylananList();

            return Ok(yoneticiAdminBlogListResponses);

        }
        [HttpGet]
        public IActionResult GetReklamlarList()
        {
            var reklamlars = _kullaniciMakalelerAppService.ReklamlarList();

            return Ok(reklamlars);

        }
        [HttpGet]
        public IActionResult GetReklamlarOnaylananList()
        {
            var reklamlars = _kullaniciMakalelerAppService.ReklamlarOnaylananList();

            return Ok(reklamlars);

        }
        [HttpPost]
        public IActionResult PostKategoriOzelBlogList(KategoriAdListRequest kategoriAdListRequest)
        {
            var blogListResponses = _kullaniciMakalelerAppService.KategoriBlogList(kategoriAdListRequest);

            return Ok(blogListResponses);

        }
        [HttpPost]
        public IActionResult PostBegen(BegenRequest begenRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.Begen(begenRequest);

            return Ok(baseResponse);

        }
        [HttpPost]
        public IActionResult PostReklamOnayla(MakaleIdRequest makaleIdRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.ReklamOnayla(makaleIdRequest);

            return Ok(baseResponse);

        }
        [HttpPost]
        public IActionResult PostReklamSil(MakaleIdRequest makaleIdRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.ReklamSil(makaleIdRequest);

            return Ok(baseResponse);

        }
        [HttpPost]
        public IActionResult PostBlogAdList(KullaniciAdRequest kullaniciAdRequest)
        {
            var blogAdListResponses = _kullaniciMakalelerAppService.BlogAdList(kullaniciAdRequest);

            return Ok(blogAdListResponses);

        }
        [HttpPost]
        public IActionResult PostReklamVer(ReklamVerRequest reklamVerRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.ReklamVer(reklamVerRequest);

            return Ok(baseResponse);

        }
        [HttpPost]
        public IActionResult PostBagisList(KullaniciAdRequest kullaniciAdRequest)
        {
            var transactions = _kullaniciMakalelerAppService.BagisList(kullaniciAdRequest);

            return Ok(transactions);

        }
        [HttpPost]
        public IActionResult PostBagisYapilanBlogDuzenle(KullaniciAdRequest kullaniciAdRequest)
        {
            var blogPaylasimResponse = _kullaniciMakalelerAppService.BagisYapilanBlogDuzenle(kullaniciAdRequest);

            return Ok(blogPaylasimResponse);

        }
        [HttpPost]
        public IActionResult PostCoinGenel(KullaniciAdRequest kullaniciAdRequest)
        {
            var coinGenelResponse = _kullaniciMakalelerAppService.CoinGenel(kullaniciAdRequest);

            return Ok(coinGenelResponse);

        }
        [HttpPost]
        public IActionResult PostBlogOnaylanmamisIncele(MakaleIdRequest makaleIdRequest)
        {
            var yoneticiAdminBlogListResponses = _kullaniciMakalelerAppService.BlogOnayBekleyenIncele(makaleIdRequest);

            return Ok(yoneticiAdminBlogListResponses);

        }
        [HttpPost]
        public IActionResult PostBagisYap(BagisYapRequest bagisYapRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.BagisYap(bagisYapRequest);

            return Ok(baseResponse);

        }
        [HttpPost]
        public IActionResult PostBlogOnaylanmamisOnayla(MakaleIdRequest makaleIdRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.BlogOnayBekleyenOnayla(makaleIdRequest);

            return Ok(baseResponse);

        }
        [HttpPost]
        public IActionResult PostBlogOnaylanmamisSil(MakaleIdRequest makaleIdRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.BlogOnayBekleyenSil(makaleIdRequest);

            return Ok(baseResponse);

        }

        [HttpPost]
        public IActionResult PostBlogIncele(IndexSlugRequest indexSlugRequest)
        {
            var indexBlogInceleResponse = _kullaniciMakalelerAppService.IndexBlogIncele(indexSlugRequest);

            return Ok(indexBlogInceleResponse);

        }


        #region Admin BackEnd
        [HttpPost]
        public IActionResult PostPaylasilanBlogList(KullaniciAdRequest kullaniciAdRequest)
        {
            var blogPaylasimResponses = _kullaniciMakalelerAppService.PaylasilanBlogList(kullaniciAdRequest);

            return Ok(blogPaylasimResponses);

        }

        [HttpPost]
        public IActionResult PostPaylasilanBlogSil(MakaleIdRequest makaleIdRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.PaylasilanBlogSil(makaleIdRequest);

            return Ok(baseResponse);

        }
        [HttpPost]
        public IActionResult PostPaylasilanBlogDuzenle(MakaleIdRequest makaleIdRequest)
        {
            var blogPaylasimResponse = _kullaniciMakalelerAppService.PaylasilanBlogDuzenle(makaleIdRequest);

            return Ok(blogPaylasimResponse);

        }
        [HttpPost]
        public IActionResult PostPaylasilanBlogGuncelle(BlogPaylasimResponse blogPaylasimResponse)
        {
            var baseResponse = _kullaniciMakalelerAppService.PaylasilanBlogGuncelle(blogPaylasimResponse);

            return Ok(baseResponse);

        }

        [HttpPost]
        public IActionResult PostPaylasilanBlogEkle(MakaleCreateRequest makaleCreateRequest)
        {
            var baseResponse = _kullaniciMakalelerAppService.PaylasilanBlogEkle(makaleCreateRequest);

            return Ok(baseResponse);

        }
        #endregion

    }
}