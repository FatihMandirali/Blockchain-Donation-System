using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bitirme.Models;
using Core.Model.Request;
using Application.PersonelService;
using Application.KullanicilarService;
using Core.Tables;
using Core.Model.Response;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Bitirme.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonelAppService _personelAppService;
        private readonly IKullanicilarAppService _kullanicilarAppService;
        public HomeController(IPersonelAppService personelAppService, IKullanicilarAppService kullanicilarAppService)
        {
            _personelAppService = personelAppService;
            _kullanicilarAppService = kullanicilarAppService;
        }
        public IActionResult Index()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            ViewData["kullaniciLogin"] = deger;
            return View();
        }

        public IActionResult YetersizYetki()
        {
            return View();
        }

        public IActionResult YoneticiLogin()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            ViewData["kullaniciLogin"] = deger;
            return View();
        }
      

        public IActionResult BlogDetay()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            ViewData["kullaniciLogin"] = deger;
            return View();
        }

        public IActionResult Kategoriler()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            ViewData["kullaniciLogin"] = deger;
            return View();
        }

        public IActionResult KategoriOzel()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            ViewData["kullaniciLogin"] = deger;
            return View();
        }

        //[HttpPost]
        //public IActionResult YoneticiLogin(Login login)
        //{
        //    BaseResponse baseResponse = _personelAppService.YoneticiLogin(login);
        //    if (baseResponse.durum == true)
        //        HttpContext.Session.SetString("YoneticiGiris",baseResponse.mesaj);

        //    string deger = HttpContext.Session.GetString("YoneticiGiris");
        //    return View(baseResponse);
        //}

        public IActionResult KullaniciLogin()
        {
            return View();
        }

        public IActionResult KullaniciKayit()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            ViewData["kullaniciLogin"] = deger;
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //ViewData["Message"] = "Your application description page.";
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
