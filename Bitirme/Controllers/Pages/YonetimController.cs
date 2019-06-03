using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.GenelService;
using Application.KonularService;
using Application.KonularService.DTO;
using Application.KullanicilarService.DTO;
using Core.Repositories.KonularR;
using Core.Repositories.KullanicilarR;
using Core.Tables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme.Controllers.Pages
{
    public class YonetimController : Controller
    {


        private readonly IGenelAppService _genelAppService;
        private readonly IKonularRepository _konularAppService;
        private readonly IKullanicilarRepository _kullanicilarRepository;
        private readonly IHostingEnvironment _appEnvironment;
        public YonetimController(IKullanicilarRepository kullanicilarRepository,IHostingEnvironment appEnvironment, IKonularRepository konularAppService, IGenelAppService genelAppService)
        {
            _appEnvironment = appEnvironment;
            _konularAppService = konularAppService;
            _genelAppService = genelAppService;
            _kullanicilarRepository = kullanicilarRepository;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region Personel Sayfaları

        public IActionResult Personeller()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }

        public IActionResult PersonelDuzenle()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }

        public IActionResult ReklamOnay()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }
        public IActionResult ReklamOnaylananlar()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }

        public IActionResult PersonelEkle()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }

        #endregion

        #region KonuSayfaları

        public IActionResult Konular()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
          
        }

        public IActionResult KonuDuzenle()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }
        public IActionResult KonuEkle()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }
        //[HttpPost]
        //public IActionResult KonuEkle(KonuResponse konuResponse)
        //{
        //    Konular konular = new Konular();
        //    konular.Hakkinda = konuResponse.Hakkinda;
        //    konular.KonuAdi = konuResponse.KonuAdi;
        //    konular.Slug = _genelAppService.KarakterCevir(konuResponse.KonuAdi); ;
        //    var files = HttpContext.Request.Form.Files;
        //    foreach (var Image in files)
        //    {
        //        if (Image != null && Image.Length > 0)
        //        {
        //            var file = Image;
        //            //There is an error hereD:\Programlama\C#_Uygulamalari\PROJELERİM\Bitirme\Bitirme\Bitirme\Bitirme\wwwroot\Belgeler\Image\20194302147871e.jpg
        //            var uploads = Path.Combine(_appEnvironment.WebRootPath, "D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\wwwroot\\Belgeler\\Image");
        //            if (file.Length > 0)
        //            {
        //                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
        //                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
        //                {
        //                    file.CopyToAsync(fileStream);
        //                    konular.Resim = fileName;
        //                    _konularAppService.Insert(konular);
        //                }

        //            }
        //        }
        //    }
        //        return View();
        //}
        #endregion

        #region Kullanıcı Sayfaları

        public IActionResult Kullanicilar()
        {  string deger = HttpContext.Session.GetString("YoneticiGiris");
            if(deger==null)
            return RedirectToAction("YetersizYetki", "Home");
            else
            return View();
        }
        public IActionResult KullaniciEkle()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }
 //       [HttpPost]
 //       public IActionResult KullaniciEkle(KullaniciCreateRequest kullaniciCreateRequest)
 //       {
 //           Kullanicilar kullanicilar1 = _kullanicilarRepository.Find(x => x.KullaniciAdi == kullaniciCreateRequest.KullaniciAdi);
 //           if (kullanicilar1 == null)
 //           {
 //               Kullanicilar kullanicilar = new Kullanicilar();
 //               kullanicilar.Ad = kullaniciCreateRequest.Ad;
 //               kullanicilar.KullaniciAdi = kullaniciCreateRequest.KullaniciAdi;
 //               kullanicilar.Email = kullaniciCreateRequest.Email;
 //               kullanicilar.Sifre = kullaniciCreateRequest.Sifre;
 //               kullanicilar.Soyad = kullaniciCreateRequest.Soyad;
 //               kullanicilar.Telefon = kullaniciCreateRequest.Telefon;
 //               kullanicilar.Biyografi = kullaniciCreateRequest.Biyografi;

 //               var files = HttpContext.Request.Form.Files;
 //               foreach (var Image in files)
 //               {
 //                   if (Image != null && Image.Length > 0)
 //                   {
 //                       var file = Image;
 //                       //There is an error hereD:\Programlama\C#_Uygulamalari\PROJELERİM\Bitirme\Bitirme\Bitirme\Bitirme\wwwroot\Belgeler\Image\20194302147871e.jpg
 //                       var uploads = Path.Combine(_appEnvironment.WebRootPath, "D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\wwwroot\\Belgeler\\Image");
 //                       if (file.Length > 0)
 //                       {
 //                           var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
 //                           using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
 //                           {
 //                               file.CopyToAsync(fileStream);
 //                               kullanicilar.Resim = fileName;
                               
 //                           }

 //                       }
 //                   }
 //               }

 //_kullanicilarRepository.Insert(kullanicilar);


 //            //   baseResponse.durum = true;
 //             //  baseResponse.mesaj = "Eklenme Başarılı";
 //           }
 //           else
 //           {
 //            //   baseResponse.durum = false;
 //            //   baseResponse.mesaj = "Böyle Kullanıcı Adına Sahip Kullanıcı Zaten Bulunmakta";
 //           }
 //           return View();
 //       }





        public IActionResult KullaniciDuzenle()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }


        #endregion

        public IActionResult OnayBekleyenBloglar()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }
        public IActionResult OnaylananBloglar()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }

        public IActionResult OnayBekleyenBlogIncele()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }
        public IActionResult OnaylananBlogIncele()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }


        public IActionResult YapilanBagislar()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }
        public IActionResult GenelBilgiFinans()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
                return View();
        }

        public IActionResult GenelBilgi()
        {
            string deger = HttpContext.Session.GetString("YoneticiGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
            {
                ViewData["deneeme"] = deger;
                return View();
            }
        }

    }
}