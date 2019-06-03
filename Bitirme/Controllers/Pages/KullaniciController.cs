using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme.Controllers.Pages
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult BlogPaylasimlar()
        {
         //   string deger = HttpContext.Session.GetString("KullaniciGiris");
           
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
            {
                ViewData["deneeme"] = deger;
                return View();
            }
           
             
        }

        public IActionResult BlogPaylasimlarIncele()
        {
           
            return View();

        }
        public IActionResult BagisMakaleIncele()
        {
           
            return View();

        }

        public IActionResult BlogPaylasimlarEkle()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
            {
                ViewData["deneeme"] = deger;
                return View();
            }

        }

        public IActionResult ReklamVer()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
            {
                ViewData["deneeme"] = deger;
                return View();
            }

        }

        public IActionResult GenelBilgi()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
            {
                ViewData["deneeme"] = deger;
                return View();
            }

        }

        public IActionResult OdemeAl()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
            {
                ViewData["deneeme"] = deger;
                return View();
            }

        }
        public IActionResult GenelBakiye()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
            if (deger == null)
                return RedirectToAction("YetersizYetki", "Home");
            else
            {
                ViewData["deneeme"] = deger;
                return View();
            }

        }

        public IActionResult YapilanBagis()
        {
            string deger = HttpContext.Session.GetString("KullaniciGiris");
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