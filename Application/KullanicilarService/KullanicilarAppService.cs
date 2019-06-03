using Application.GenelService;
using Application.KullanicilarService.DTO;
using AutoMapper;
using Core.Blockchain;
using Core.Model.Request;
using Core.Model.Response;
using Core.Repositories.KullanicilarR;
using Core.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace Application.KullanicilarService
{
    public class KullanicilarAppService : IKullanicilarAppService
    {
        float kullaniciBlogBagisToplam;
        float yoneticiBlogBagisToplam;
        private readonly IKullanicilarRepository _kullanicilarRepository;
        private readonly IMapper _mapper;
        private readonly IGenelAppService _genelAppService;
        public KullanicilarAppService(IKullanicilarRepository kullanicilarRepository, IMapper mapper, IGenelAppService genelAppService)
        {
            _kullanicilarRepository = kullanicilarRepository;
            _mapper = mapper;
            _genelAppService = genelAppService;
        }

        public GenelFinansResponse GenelFinans(GenelFinansRequest genelFinansRequest)
        {

            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.KullaniciAdi == genelFinansRequest.KullaniciAdi);
            StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json");
            string json2 = rr.ReadToEnd();
            rr.Close();
            GenelChainList sorular = JsonConvert.DeserializeObject<GenelChainList>(json2);
            //  var aa=  sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2].Substring(a.receiver.Length-1,1)=="fm")).ToList();
            //  int result1 = sorular.chain.SelectMany(x => x.transactions.Where(yx => yx.receiver == item.Slug)).Sum(x => x.amount);

            foreach (var item in sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2] == kullanicilar.KullaniciAdi)).ToList())
            {
                kullaniciBlogBagisToplam += item.amount;
            }


            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://api.coinbase.com/v2/prices/");
            HttpResponseMessage responseMessage2 = client2.GetAsync("spot?currency=USD").Result;
            responseMessage2.EnsureSuccessStatusCode();
            var responseBody = responseMessage2.Content.ReadAsStringAsync();
            CoinKurAll emp = responseMessage2.Content.ReadAsAsync<CoinKurAll>().Result;


            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            string USD_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            //int dolarInt=conv
            float dolarKur = float.Parse(USD_Alis, CultureInfo.InvariantCulture.NumberFormat);
            GenelFinansResponse genelFinansResponse = new GenelFinansResponse();
            Kullanicilar kullanicilar1 = _kullanicilarRepository.Find(x => x.KullaniciAdi == genelFinansRequest.KullaniciAdi);

            float toplamBagis = (float)Math.Round(kullaniciBlogBagisToplam, 4);
            genelFinansResponse.bBitcoin =toplamBagis;
            genelFinansResponse.bTl = (float)Math.Round((emp.data.amount * toplamBagis) * dolarKur,4);
            genelFinansResponse.bDolar = (float)Math.Round(emp.data.amount * toplamBagis,4);

            genelFinansResponse.Bitcoin = (float)Math.Round(kullanicilar1.Bakiye,4);
            genelFinansResponse.Dolar = (float)Math.Round(emp.data.amount * kullanicilar1.Bakiye,4);
            genelFinansResponse.Tl = (float)Math.Round((emp.data.amount * kullanicilar1.Bakiye) * dolarKur,4);

            genelFinansResponse.sBitcoin = (float)Math.Round(genelFinansResponse.bBitcoin+ genelFinansResponse.Bitcoin,4);
            genelFinansResponse.sDolar = (float)Math.Round(genelFinansResponse.bDolar + genelFinansResponse.Dolar, 4);
            genelFinansResponse.sTl = (float)Math.Round(genelFinansResponse.bTl + genelFinansResponse.Tl, 4);


            return genelFinansResponse;
        }

        public Kullanicilar KullaniciBul(KullaniciAdRequest kullaniciAdRequest)
        {
            return _kullanicilarRepository.Find(x => x.KullaniciAdi == kullaniciAdRequest.KullaniciAdi);
        }

        public BaseResponse KullaniciCreate(KullaniciCreateRequest kullaniciCreateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            Kullanicilar kullanicilar1 = _kullanicilarRepository.Find(x => x.KullaniciAdi == kullaniciCreateRequest.KullaniciAdi);
            if (kullanicilar1 == null)
            {
                Kullanicilar kullanicilar = new Kullanicilar();
                kullanicilar.Ad = kullaniciCreateRequest.Ad;
                kullanicilar.KullaniciAdi = kullaniciCreateRequest.KullaniciAdi;
                kullanicilar.Email = kullaniciCreateRequest.Email;
                kullanicilar.Sifre = kullaniciCreateRequest.Sifre;
                kullanicilar.Soyad = kullaniciCreateRequest.Soyad;
                kullanicilar.Telefon = kullaniciCreateRequest.Telefon;
                kullanicilar.Biyografi = kullaniciCreateRequest.Biyografi;

                if (kullaniciCreateRequest.Resim == "bos")
                {
                    string imagePath = @"D:\Programlama\C#_Uygulamalari\PROJELERİM\Bitirme\Bitirme\Bitirme\Bitirme\wwwroot\Belgeler\Image\bos.png";
                    string imge = _genelAppService.GetBase64StringForImage(imagePath);
                    byte[] img = Convert.FromBase64String(imge);
                    string resimad = _genelAppService.GetImageResimResponse(kullanicilar.KullaniciAdi) + ".jpg";
                    System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                    kullanicilar.Resim = resimad;
                }
                else
                {
                    string imagePath = @"C:\Users\fatih\Desktop\BitirmeResim\Kullanici_Resim/" + kullaniciCreateRequest.Resim;
                    string imge = _genelAppService.GetBase64StringForImage(imagePath);
                    byte[] img = Convert.FromBase64String(imge);
                    string resimad = _genelAppService.GetImageResimResponse(kullanicilar.KullaniciAdi) + ".jpg";
                    System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                    kullanicilar.Resim = resimad;
                }

                _kullanicilarRepository.Insert(kullanicilar);


                baseResponse.durum = true;
                baseResponse.mesaj = "Eklenme Başarılı";
            }
            else
            {
                baseResponse.durum = false;
                baseResponse.mesaj = "Böyle Kullanıcı Adına Sahip Kullanıcı Zaten Bulunmakta";
            }
            return baseResponse;

        }

        public Kullanicilar KullaniciDuzenle(KullaniciIdRequest kullaniciIdRequest)
        {
            return _kullanicilarRepository.Find(x => x.Id == kullaniciIdRequest.Id);

        }

        public BaseResponse KullaniciGuncelle(Kullanicilar kullanicilar)
        {
            Kullanicilar kullanicilar1 = _kullanicilarRepository.Find(x => x.Id == kullanicilar.Id);
            kullanicilar1.KullaniciAdi = kullanicilar.KullaniciAdi;
            kullanicilar1.Sifre = kullanicilar.Sifre;
            kullanicilar1.Soyad = kullanicilar.Soyad;
            kullanicilar1.Telefon = kullanicilar.Telefon;
            kullanicilar1.Ad = kullanicilar.Ad;
            kullanicilar1.Bakiye = kullanicilar.Bakiye;
            kullanicilar1.Biyografi = kullanicilar.Biyografi;
            kullanicilar1.Email = kullanicilar.Email;
            if (kullanicilar.Resim == "bos")
            {
                string imagePath = @"D:\Programlama\C#_Uygulamalari\PROJELERİM\Bitirme\Bitirme\Bitirme\Bitirme\wwwroot\Belgeler\Image\bos.png";
                string imge = _genelAppService.GetBase64StringForImage(imagePath);
                byte[] img = Convert.FromBase64String(imge);
                string resimad = _genelAppService.GetImageResimResponse(kullanicilar.KullaniciAdi) + ".jpg";
                System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                kullanicilar.Resim = resimad;
            }
            else
            {
                string imagePath = @"C:\Users\fatih\Desktop\BitirmeResim\Kullanici_Resim" + kullanicilar.Resim;
                string imge = _genelAppService.GetBase64StringForImage(imagePath);
                byte[] img = Convert.FromBase64String(imge);
                string resimad = _genelAppService.GetImageResimResponse(kullanicilar.KullaniciAdi) + ".jpg";
                System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                kullanicilar.Resim = resimad;
            }
            _kullanicilarRepository.Update(kullanicilar1);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Güncelleme İşlemi Başarılı";
            return baseResponse;
        }

        public List<Kullanicilar> KullaniciList()
        {
            return _kullanicilarRepository.List().OrderByDescending(x => x.Id).ToList();

        }

        public BaseResponse KullaniciLogin(Login login)
        {
            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.KullaniciAdi == login.KullaniciAdi && x.Sifre == login.Sifre);
            BaseResponse baseResponse = new BaseResponse();
            if (kullanicilar == null)
                baseResponse.durum = false;
            else
            {
                baseResponse.mesaj = kullanicilar.KullaniciAdi;
                baseResponse.durum = true;
            }
            return baseResponse;
        }

        public BaseResponse KullaniciOdemeAl(OdemeAlRequest odemeAlRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            if (odemeAlRequest.Tl <= 9)
            {
                baseResponse.durum = false;
                baseResponse.mesaj = "Lütfen Ödeme Almak İçin En Az 10 ₺ Tutarını Girin";
                return baseResponse;
            }
            else
            {

                Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.KullaniciAdi == odemeAlRequest.KullaniciAdi);
                kullanicilar.Bakiye += odemeAlRequest.GelenPara;
                _kullanicilarRepository.Update(kullanicilar);

                baseResponse.durum = true;
                baseResponse.mesaj = "Ödemeniz Coin Cinsinden Alındı.Alınan Coin Tutarı : " + odemeAlRequest.GelenPara;
                return baseResponse;
            }
        }

        public BaseResponse KullaniciSil(KullaniciIdRequest kullaniciIdRequest)
        {
            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.Id == kullaniciIdRequest.Id);
            _kullanicilarRepository.Delete(kullanicilar);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Silme İşlemi Başarılı";
            return baseResponse;
        }

        public GenelFinansResponse PesronelGenelFinans()
        {

             StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json");
            string json2 = rr.ReadToEnd();
            rr.Close();
            GenelChainList sorular = JsonConvert.DeserializeObject<GenelChainList>(json2);
            //  var aa=  sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2].Substring(a.receiver.Length-1,1)=="fm")).ToList();
            //  int result1 = sorular.chain.SelectMany(x => x.transactions.Where(yx => yx.receiver == item.Slug)).Sum(x => x.amount);

            foreach (var item in sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2] != "546154")).ToList())
            {
                yoneticiBlogBagisToplam += item.amount;
            }


            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://api.coinbase.com/v2/prices/");
            HttpResponseMessage responseMessage2 = client2.GetAsync("spot?currency=USD").Result;
            responseMessage2.EnsureSuccessStatusCode();
            var responseBody = responseMessage2.Content.ReadAsStringAsync();
            CoinKurAll emp = responseMessage2.Content.ReadAsAsync<CoinKurAll>().Result;


            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            string USD_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            //int dolarInt=conv
            float dolarKur = float.Parse(USD_Alis, CultureInfo.InvariantCulture.NumberFormat);
            GenelFinansResponse genelFinansResponse = new GenelFinansResponse();
            float TCoin = _kullanicilarRepository.List().Sum(x => x.Bakiye);

         

            float toplamBagis = (float)Math.Round(yoneticiBlogBagisToplam, 4);
            genelFinansResponse.bBitcoin = toplamBagis;
            genelFinansResponse.bTl = (float)Math.Round((emp.data.amount * toplamBagis) * dolarKur, 4);
            genelFinansResponse.bDolar = (float)Math.Round(emp.data.amount * toplamBagis, 4);

            genelFinansResponse.Bitcoin = (float)Math.Round(TCoin, 4);
            genelFinansResponse.Dolar = (float)Math.Round(emp.data.amount * TCoin, 4);
            genelFinansResponse.Tl = (float)Math.Round((emp.data.amount * TCoin) * dolarKur, 4);

            genelFinansResponse.sBitcoin = (float)Math.Round(genelFinansResponse.bBitcoin + genelFinansResponse.Bitcoin, 4);
            genelFinansResponse.sDolar = (float)Math.Round(genelFinansResponse.bDolar + genelFinansResponse.Dolar, 4);
            genelFinansResponse.sTl = (float)Math.Round(genelFinansResponse.bTl + genelFinansResponse.Tl, 4);


            return genelFinansResponse;
        }
    }
}
