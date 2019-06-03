using Application.GenelService;
using Application.KullaniciMakalelerService.DTO;
using AutoMapper;
using Core.Blockchain;
using Core.Model.Response;
using Core.Repositories.BegenilerR;
using Core.Repositories.KonularR;
using Core.Repositories.KullanicilarR;
using Core.Repositories.MakalelerR;
using Core.Repositories.ReklamlarR;
using Core.Repositories.YorumlarR;
using Core.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace Application.KullaniciMakalelerService
{
    public class KullaniciMakalelerAppService : IKullaniciMakalelerAppService
    {

        private readonly IKullanicilarRepository _kullanicilarRepository;
        private readonly IMapper _mapper;
        private readonly IGenelAppService _genelAppService;
        private readonly IMakalelerRepository _makalelerRepository;
        private readonly IKonularRepository _konularRepository;
        private readonly IYorumlarRepository _yorumlarRepository;
        private readonly IReklamlarRepository _reklamlarRepository;
        private readonly IBegenilerRepository _begenilerRepository;
        public KullaniciMakalelerAppService(IBegenilerRepository begenilerRepository,IReklamlarRepository reklamlarRepository,IYorumlarRepository yorumlarRepository, IKonularRepository konularRepository, IMakalelerRepository makalelerRepository, IKullanicilarRepository kullanicilarRepository, IMapper mapper, IGenelAppService genelAppService)
        {
            _kullanicilarRepository = kullanicilarRepository;
            _mapper = mapper;
            _genelAppService = genelAppService;
            _makalelerRepository = makalelerRepository;
            _konularRepository = konularRepository;
            _yorumlarRepository = yorumlarRepository;
            _reklamlarRepository = reklamlarRepository;
            _begenilerRepository = begenilerRepository;
        }
        public List<Transactions> BagisList(KullaniciAdRequest kullaniciAdRequest)
        {
            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.KullaniciAdi == kullaniciAdRequest.KullaniciAdi);
            StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json");
            string json2 = rr.ReadToEnd();
            rr.Close();
            GenelChainList sorular = JsonConvert.DeserializeObject<GenelChainList>(json2);
            //  var aa=  sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2].Substring(a.receiver.Length-1,1)=="fm")).ToList();
            //  int result1 = sorular.chain.SelectMany(x => x.transactions.Where(yx => yx.receiver == item.Slug)).Sum(x => x.amount);
            List<Transactions> transactions = new List<Transactions>();
            foreach (var item in sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2] == kullanicilar.KullaniciAdi)).ToList())
            {
                transactions.Add(new Transactions()
                {
                    amount = item.amount,
                    receiver = item.receiver,
                    sender = _genelAppService.IsimKisalt(item.sender)
                });
            }


            return transactions;
        }

        public BaseResponse BagisYap(BagisYapRequest bagisYapRequest)
        {
            BaseResponse baseResponse = new BaseResponse();

            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.KullaniciAdi == bagisYapRequest.KullaniciAdi);
            Makaleler makaleler = _makalelerRepository.Find(x => x.Slug == bagisYapRequest.YapilanMakale);
            if (makaleler.KullaniciIdi != kullanicilar.Id)
            {
                if (bagisYapRequest.Tl <= 9)
                {
                    baseResponse.durum = true;
                    baseResponse.mesaj = "Lütfen Ödeme Almak İçin En Az 10 ₺ Tutarını Girin.";
                }
                else
                {

                    if (kullanicilar.Bakiye >= bagisYapRequest.BagisTutari)
                    {
                        kullanicilar.Bakiye -= bagisYapRequest.BagisTutari;
                        _kullanicilarRepository.Update(kullanicilar);
                        baseResponse.durum = true;
                        baseResponse.mesaj = "Bağış başarılı bir şekilde yapıldı.Yapılan Coin Bağış : " + bagisYapRequest.BagisTutari;


                        #region Post Transaction

                        List<Transactions> transactions = new List<Transactions>(){new Transactions()
                {

                sender=kullanicilar.Ad+ " "+kullanicilar.Soyad,
                receiver=bagisYapRequest.YapilanMakale,
                amount =bagisYapRequest.BagisTutari
                }
                };
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("http://127.0.0.1:5000/");
                        HttpResponseMessage responseMessage = client.PostAsJsonAsync("add_transaction", transactions[0]).Result;
                        var emp1 = responseMessage.Content.ReadAsAsync<AddTransactionResponse>().Result;

                        #endregion
                        #region Json Listeleme ve Temizleme
                        StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\transactions.json");
                        string json2 = rr.ReadToEnd();
                        dynamic array = JsonConvert.DeserializeObject(json2);
                        List<Transactions> sorular = JsonConvert.DeserializeObject<List<Transactions>>(json2);
                        rr.Close();
                        System.IO.File.WriteAllText("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\transactions.json", string.Empty);


                        #endregion
                        #region Eski Liste İle Tekrar Listeye Dökme

                        if (sorular != null)
                            transactions.AddRange(sorular);

                        string dosya_yolu1 = @"D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\transactions.json";
                        StreamWriter sw1 = File.AppendText(dosya_yolu1);
                        string json1 = JsonConvert.SerializeObject(transactions);
                        sw1.WriteLine(json1);
                        sw1.Flush();
                        sw1.Close();
                        #endregion
                        #region Zinciri Bitirme(mine_block)
                        if (sorular == null)
                        {

                        }
                        else
                        {
                            if (sorular.Count >= 10)
                            {

                                HttpClient client1 = new HttpClient();
                                client1.BaseAddress = new Uri("http://127.0.0.1:5000/");
                                HttpResponseMessage responseMessage1 = client1.GetAsync("mine_block").Result;
                                responseMessage1.EnsureSuccessStatusCode();
                                //    var responseBody = responseMessage1.Content.ReadAsStringAsync();
                                //    var emp = responseMessage1.Content.ReadAsAsync<GenelChainList>().Result;
                                System.IO.File.WriteAllText("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\transactions.json", string.Empty);
                                HttpClient client2 = new HttpClient();
                                client2.BaseAddress = new Uri("http://127.0.0.1:5000/");
                                HttpResponseMessage responseMessage2 = client2.GetAsync("get_chain").Result;
                                responseMessage2.EnsureSuccessStatusCode();
                                var responseBody = responseMessage2.Content.ReadAsStringAsync();
                                GenelChainList emp = responseMessage2.Content.ReadAsAsync<GenelChainList>().Result;



                                System.IO.File.WriteAllText("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json", string.Empty);



                                string dosya_yolu2 = @"D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json";
                                StreamWriter sw2 = File.AppendText(dosya_yolu2);
                                string json3 = JsonConvert.SerializeObject(emp);
                                sw2.WriteLine(json3);
                                sw2.Flush();
                                sw2.Close();


                            }
                        }

                        #endregion
                    }
                    else
                    {
                        baseResponse.durum = true;
                        baseResponse.mesaj = "Girilen tutarda bağış yapamazsınız.Lütfen Bağış Tutarınızı Düşünürünüz.";
                    }
                }
            }
            else
            {
                baseResponse.durum = true;
                baseResponse.mesaj = "Kendinize Bağış Yapamazsınız.";
            }
          
            return baseResponse;
        }

        public BlogPaylasimResponse BagisYapilanBlogDuzenle(KullaniciAdRequest kullaniciAdRequest)
        {
            Makaleler makaleler = _makalelerRepository.Find(x => x.Slug == kullaniciAdRequest.KullaniciAdi);

            BlogPaylasimResponse blogPaylasimResponse = new BlogPaylasimResponse();
            blogPaylasimResponse.AltBaslik = makaleler.AltBaslik;
            blogPaylasimResponse.Baslik = makaleler.Baslik;
            blogPaylasimResponse.Icerik = makaleler.Icerik;
            blogPaylasimResponse.KazanilanPara = makaleler.VerilenPara;
            blogPaylasimResponse.Id = makaleler.Id;
            blogPaylasimResponse.Resim = makaleler.Resim;
            blogPaylasimResponse.Tarih = makaleler.Tarih;
            blogPaylasimResponse.KonuAdi = _konularRepository.Find(x => x.Id == makaleler.KonuIdi).KonuAdi;
            return blogPaylasimResponse;
        }

        public List<BlogListResponse> BlogList()
        {
            List<Makaleler> makalelers = _makalelerRepository.List(x=>x.Paylasilma==true).OrderByDescending(x => x.Id).ToList();
            List<BlogListResponse> blogListResponses = new List<BlogListResponse>();
            foreach (var item in makalelers)
            {
                string makaleAd = _konularRepository.Find(x => x.Id == item.KonuIdi).KonuAdi;
                blogListResponses.Add(new BlogListResponse()
                {
                    AltBaslik = item.AltBaslik,
                    Baslik = item.Baslik,
                    KonuAdi = makaleAd,
                    Id = item.Id,
                    Resim = item.Resim,
                    Slug = item.Slug

                });
            }
            return blogListResponses;
        }

        public YoneticiAdminBlogListResponse BlogOnayBekleyenIncele(MakaleIdRequest makaleIdRequest)
        {
            Makaleler makaleler = _makalelerRepository.Find(x => x.Id == makaleIdRequest.Id);
            YoneticiAdminBlogListResponse yoneticiAdminBlogListResponse = new YoneticiAdminBlogListResponse();
            yoneticiAdminBlogListResponse.AltBaslik = makaleler.AltBaslik;
            yoneticiAdminBlogListResponse.Baslik = makaleler.Baslik;
            yoneticiAdminBlogListResponse.Icerik = makaleler.Icerik;
            yoneticiAdminBlogListResponse.Id = makaleler.Id;
            yoneticiAdminBlogListResponse.KonuAd = _konularRepository.Find(x => x.Id == makaleler.KonuIdi).KonuAdi;
            yoneticiAdminBlogListResponse.KullaniciAdi = _kullanicilarRepository.Find(x => x.Id == makaleler.KullaniciIdi).KullaniciAdi;
            yoneticiAdminBlogListResponse.Resim = makaleler.Resim;
            yoneticiAdminBlogListResponse.Tarih = makaleler.Tarih;
            return yoneticiAdminBlogListResponse;
        }

        public List<YoneticiAdminBlogListResponse> BlogOnayBekleyenList()
        {
            List<Makaleler> makalelers = _makalelerRepository.List(x => x.Paylasilma == false).OrderByDescending(x => x.Id).ToList();
            List<YoneticiAdminBlogListResponse> yoneticiAdminBlogListResponses = new List<YoneticiAdminBlogListResponse>();
            foreach (var item in makalelers)
            {
                string makaleAd = _konularRepository.Find(x => x.Id == item.KonuIdi).KonuAdi;
                yoneticiAdminBlogListResponses.Add(new YoneticiAdminBlogListResponse()
                {
                    AltBaslik = item.AltBaslik,
                    Baslik = item.Baslik,
                    KonuAd = makaleAd,
                    Id = item.Id,
                    Resim = item.Resim,
                    Icerik = item.Icerik,
                    Tarih = item.Tarih,
                    KullaniciAdi = _kullanicilarRepository.Find(x => x.Id == item.KullaniciIdi).KullaniciAdi

                });
            }
            return yoneticiAdminBlogListResponses;
        }

        public BaseResponse BlogOnayBekleyenOnayla(MakaleIdRequest makaleIdRequest)
        {
            Makaleler makaleler = _makalelerRepository.Find(x => x.Id == makaleIdRequest.Id);
            makaleler.Paylasilma = true;
            _makalelerRepository.Update(makaleler);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Blog başarıyla onaylandı";
            return baseResponse;
        }
        public BaseResponse BlogOnayBekleyenSil(MakaleIdRequest makaleIdRequest)
        {
            Makaleler makaleler = _makalelerRepository.Find(x => x.Id == makaleIdRequest.Id);
            _makalelerRepository.Delete(makaleler);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Blog başarıyla silindi";
            return baseResponse;
        }

        public List<YoneticiAdminBlogListResponse> BlogOnaylananList()
        {
            List<Makaleler> makalelers = _makalelerRepository.List(x => x.Paylasilma == true).OrderByDescending(x => x.Id).ToList();
            List<YoneticiAdminBlogListResponse> yoneticiAdminBlogListResponses = new List<YoneticiAdminBlogListResponse>();
            foreach (var item in makalelers)
            {
                string makaleAd = _konularRepository.Find(x => x.Id == item.KonuIdi).KonuAdi;
                yoneticiAdminBlogListResponses.Add(new YoneticiAdminBlogListResponse()
                {
                    AltBaslik = item.AltBaslik,
                    Baslik = item.Baslik,
                    KonuAd = makaleAd,
                    Id = item.Id,
                    Resim = item.Resim,
                    Icerik = item.Icerik,
                    KazandigiPara = item.VerilenPara,
                    Tarih = item.Tarih,
                    KullaniciAdi = _kullanicilarRepository.Find(x => x.Id == item.KullaniciIdi).KullaniciAdi

                });
            }
            return yoneticiAdminBlogListResponses;
        }

        public CoinGenelResponse CoinGenel(KullaniciAdRequest kullaniciAdRequest)
        {
            CoinGenelResponse coinGenelResponse = new CoinGenelResponse();
            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.KullaniciAdi == kullaniciAdRequest.KullaniciAdi);
            StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json");
            string json2 = rr.ReadToEnd();
            rr.Close();
            GenelChainList sorular = JsonConvert.DeserializeObject<GenelChainList>(json2);
            var say = sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2] == kullanicilar.KullaniciAdi)).Count();
            var topla = sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2] == kullanicilar.KullaniciAdi)).Sum(x => x.amount);

            coinGenelResponse.Sayi = say;
            coinGenelResponse.Toplam = topla;
            return coinGenelResponse;

            //  int result1 = sorular.chain.SelectMany(x => x.transactions.Where(yx => yx.receiver == item.Slug)).Sum(x => x.amount);


        }

        public CoinGenelResponse YoneticiCoinGenel()
        {
            CoinGenelResponse coinGenelResponse = new CoinGenelResponse();
            StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json");
            string json2 = rr.ReadToEnd();
            rr.Close();
            GenelChainList sorular = JsonConvert.DeserializeObject<GenelChainList>(json2);
            var say = sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2] != "546154")).Count();
            var topla = sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2] != "546154")).Sum(x => x.amount);

            coinGenelResponse.Sayi = say;
            coinGenelResponse.Toplam = topla;
            return coinGenelResponse;

            //  int result1 = sorular.chain.SelectMany(x => x.transactions.Where(yx => yx.receiver == item.Slug)).Sum(x => x.amount);


        }

        public IndexBlogInceleResponse IndexBlogIncele(IndexSlugRequest indexSlugRequest)
        {
            Makaleler makaleler = _makalelerRepository.Find(x => x.Slug == indexSlugRequest.Slug);
            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.Id == makaleler.KullaniciIdi);
            Konular konular = _konularRepository.Find(x => x.Id == makaleler.KonuIdi);
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("http://127.0.0.1:5000/");
            HttpResponseMessage responseMessage2 = client2.GetAsync("get_chain").Result;
            responseMessage2.EnsureSuccessStatusCode();
            var responseBody = responseMessage2.Content.ReadAsStringAsync();
            GenelChainList emp = responseMessage2.Content.ReadAsAsync<GenelChainList>().Result;

            IndexBlogInceleResponse indexBlogInceleResponse = new IndexBlogInceleResponse();
            indexBlogInceleResponse.AltBaslik = makaleler.AltBaslik;
            indexBlogInceleResponse.Baslik = makaleler.Baslik;
            indexBlogInceleResponse.Biyografi = kullanicilar.Biyografi;
            indexBlogInceleResponse.Icerik = makaleler.Icerik;
            indexBlogInceleResponse.KonuAdi = konular.KonuAdi;
            indexBlogInceleResponse.KullaniciAdi = kullanicilar.KullaniciAdi;
            indexBlogInceleResponse.KullaniciResim = kullanicilar.Resim;
            indexBlogInceleResponse.Tarih = makaleler.Tarih;
            indexBlogInceleResponse.Resim = makaleler.Resim;
            indexBlogInceleResponse.CoinSayisi = emp.chain.SelectMany(x=>x.transactions.Where(a=>a.receiver==indexSlugRequest.Slug)).Sum(a=>a.amount);
            indexBlogInceleResponse.YorumSayisi = _yorumlarRepository.List(x => x.MakalelerIdi == makaleler.Id && x.Onaylanma == true).Count();

            List<YorumlarResponse> yorumlarRes = new List<YorumlarResponse>();

            foreach (var item in _yorumlarRepository.List(x => x.MakalelerIdi == makaleler.Id && x.Onaylanma == true))
            {
                yorumlarRes.Add(new YorumlarResponse() { KullaniciAdi = item.AdSoyad, KullaniciResim = "bos.png", Yorum = item.YapilanYorum, YorumTarihi = item.YapilanTarih });
            };

            indexBlogInceleResponse.liste = yorumlarRes;

            return indexBlogInceleResponse;

        }

        public List<BlogListResponse> KategoriBlogList(KategoriAdListRequest kategoriAdListRequest)
        {
            int konuId = _konularRepository.Find(x => x.Slug == kategoriAdListRequest.KategoriAd).Id;
            List<Makaleler> makalelers = _makalelerRepository.List(x => x.KonuIdi == konuId).OrderByDescending(x => x.Id).ToList();
            List<BlogListResponse> blogListResponses = new List<BlogListResponse>();
            foreach (var item in makalelers)
            {
                string makaleAd = _konularRepository.Find(x => x.Id == item.KonuIdi).KonuAdi;
                blogListResponses.Add(new BlogListResponse()
                {
                    AltBaslik = item.AltBaslik,
                    Baslik = item.Baslik,
                    KonuAdi = makaleAd,
                    Id = item.Id,
                    Resim = item.Resim,
                    Slug = item.Slug

                });
            }
            return blogListResponses;
        }

        public BlogPaylasimResponse PaylasilanBlogDuzenle(MakaleIdRequest makaleIdRequest)
        {
            Makaleler makaleler = _makalelerRepository.Find(x => x.Id == makaleIdRequest.Id);

            BlogPaylasimResponse blogPaylasimResponse = new BlogPaylasimResponse();
            blogPaylasimResponse.AltBaslik = makaleler.AltBaslik;
            blogPaylasimResponse.Baslik = makaleler.Baslik;
            blogPaylasimResponse.Icerik = makaleler.Icerik;
            blogPaylasimResponse.KazanilanPara = makaleler.VerilenPara;
            blogPaylasimResponse.Id = makaleler.Id;
            blogPaylasimResponse.Resim = makaleler.Resim;
            blogPaylasimResponse.Tarih = makaleler.Tarih;
            blogPaylasimResponse.KonuAdi = _konularRepository.Find(x => x.Id == makaleler.KonuIdi).KonuAdi;
            return blogPaylasimResponse;

        }

        public BaseResponse PaylasilanBlogEkle(MakaleCreateRequest makaleCreateRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            if (_makalelerRepository.Find(x => x.Slug == _genelAppService.KarakterCevir(makaleCreateRequest.Baslik + " " + makaleCreateRequest.AltBaslik + " " + makaleCreateRequest.KullaniciAdi)) == null)
            {
                Makaleler makaleler = new Makaleler();
                makaleler.AltBaslik = makaleCreateRequest.AltBaslik;
                makaleler.Baslik = makaleCreateRequest.Baslik;
                makaleler.Icerik = makaleCreateRequest.Icerik;
                makaleler.Tarih = DateTime.Now.ToString("dd/MM/yyyy");
                makaleler.VerilenPara = 0;
                makaleler.KullaniciIdi = _kullanicilarRepository.Find(x => x.KullaniciAdi == makaleCreateRequest.KullaniciAdi).Id;
                makaleler.KonuIdi = makaleCreateRequest.KonuIdi;
                makaleler.Slug = _genelAppService.KarakterCevir(makaleler.Baslik + " " + makaleler.AltBaslik + " " + makaleCreateRequest.KullaniciAdi);
                if (makaleCreateRequest.Resim == "bos")
                {
                    string imagePath = @"D:\Programlama\C#_Uygulamalari\PROJELERİM\Bitirme\Bitirme\Bitirme\Bitirme\wwwroot\Belgeler\Image\bos.png";
                    string imge = _genelAppService.GetBase64StringForImage(imagePath);
                    byte[] img = Convert.FromBase64String(imge);
                    string resimad = _genelAppService.GetImageResimResponse("makale") + ".jpg";
                    System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\bos.png", img);
                    makaleler.Resim = "bos.png";
                }
                else
                {
                    string imagePath = @"C:\Users\fatih\Desktop\BitirmeResim\Makale_Resim\" + makaleCreateRequest.Resim;
                    string imge = _genelAppService.GetBase64StringForImage(imagePath);
                    byte[] img = Convert.FromBase64String(imge);
                    string resimad = _genelAppService.GetImageResimResponse("makale") + ".jpg";
                    System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                    makaleler.Resim = resimad;
                }

                _makalelerRepository.Insert(makaleler);

                baseResponse.durum = true;
                baseResponse.mesaj = "Blog başarıyla eklendi";
            }
            else
            {
                baseResponse.durum = false;
                baseResponse.mesaj = "Böyle bir blog yazınız zaten bulunmaktadır";
            }

            return baseResponse;
        }

        public BaseResponse PaylasilanBlogGuncelle(BlogPaylasimResponse blogPaylasimResponse)
        {
            BaseResponse baseResponse = new BaseResponse();
            Makaleler makaleler = _makalelerRepository.Find(x => x.Id == blogPaylasimResponse.Id);
            if (makaleler.Slug == _genelAppService.KarakterCevir(blogPaylasimResponse.Baslik + " " + blogPaylasimResponse.AltBaslik + " " + _kullanicilarRepository.Find(x => x.Id == makaleler.KullaniciIdi).KullaniciAdi))
            {
                baseResponse.durum = true;
                baseResponse.mesaj = "Bu başlıklı makaleniz zaten var";
            }
            else
            {
                makaleler.AltBaslik = blogPaylasimResponse.AltBaslik;
                makaleler.Baslik = blogPaylasimResponse.Baslik;
                makaleler.Icerik = blogPaylasimResponse.Icerik;
                makaleler.Slug = _genelAppService.KarakterCevir(makaleler.Baslik + " " + makaleler.AltBaslik + " " + _kullanicilarRepository.Find(x => x.Id == makaleler.KullaniciIdi).KullaniciAdi);
                if (makaleler.Resim == "bos")
                {
                    string imagePath = @"D:\Programlama\C#_Uygulamalari\PROJELERİM\Bitirme\Bitirme\Bitirme\Bitirme\wwwroot\Belgeler\Image\bos.png";
                    string imge = _genelAppService.GetBase64StringForImage(imagePath);
                    byte[] img = Convert.FromBase64String(imge);
                    string resimad = _genelAppService.GetImageResimResponse(makaleler.Id.ToString()) + ".jpg";
                    System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                    makaleler.Resim = resimad;
                }
                else
                {
                    string imagePath = @"C:\Users\fatih\Desktop\BitirmeResim\Makale_Resim\" + blogPaylasimResponse.Resim;
                    string imge = _genelAppService.GetBase64StringForImage(imagePath);
                    byte[] img = Convert.FromBase64String(imge);
                    string resimad = _genelAppService.GetImageResimResponse(makaleler.Id.ToString()) + ".jpg";
                    System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                    makaleler.Resim = resimad;
                }
                _makalelerRepository.Update(makaleler);

                baseResponse.durum = true;
                baseResponse.mesaj = "Başarıyla Eklendi";
            }


            return baseResponse;
        }

        public List<BlogPaylasimResponse> PaylasilanBlogList(KullaniciAdRequest kullaniciAdRequest)
        {
            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.KullaniciAdi == kullaniciAdRequest.KullaniciAdi);
            List<Makaleler> makaleler = _makalelerRepository.List(x => x.KullaniciIdi == kullanicilar.Id).OrderByDescending(x => x.Id).ToList();
            List<BlogPaylasimResponse> blogPaylasimResponses = new List<BlogPaylasimResponse>();

            StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json");
            string json2 = rr.ReadToEnd();
            GenelChainList sorular = JsonConvert.DeserializeObject<GenelChainList>(json2);


            foreach (var item in makaleler)
            {



                float result1 = sorular.chain.SelectMany(x => x.transactions.Where(yx => yx.receiver == item.Slug)).Sum(x => x.amount);

                blogPaylasimResponses.Add(new BlogPaylasimResponse()
                {
                    AltBaslik = item.AltBaslik,
                    Baslik = item.Baslik,
                    Icerik = item.Icerik,
                    Id = item.Id,
                    KazanilanPara = result1,
                    KonuAdi = _konularRepository.Find(x => x.Id == item.KonuIdi).KonuAdi,
                    Resim = item.Resim,
                    Tarih = item.Tarih,
                });
            }

            return blogPaylasimResponses;
        }

        public BaseResponse PaylasilanBlogSil(MakaleIdRequest makaleIdRequest)
        {
            Makaleler makaleler = _makalelerRepository.Find(x => x.Id == makaleIdRequest.Id);
            _makalelerRepository.Delete(makaleler);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Başarıyla Silindi";
            return baseResponse;
        }

        public List<Transactions> YoneticiBagisList()
        {
            StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json");
            string json2 = rr.ReadToEnd();
            rr.Close();
            GenelChainList sorular = JsonConvert.DeserializeObject<GenelChainList>(json2);
            //  var aa=  sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2].Substring(a.receiver.Length-1,1)=="fm")).ToList();
            //  int result1 = sorular.chain.SelectMany(x => x.transactions.Where(yx => yx.receiver == item.Slug)).Sum(x => x.amount);
            return _mapper.Map<List<Transactions>>(sorular.chain.SelectMany(x => x.transactions.Where(a => a.receiver.Split("-")[2] != "546154")).ToList());


        }

        public CoinKur CoinKur()
        {
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


            CoinKur coinKur = new CoinKur();
            coinKur.amount = emp.data.amount;
            coinKur.currency = emp.data.currency;
            coinKur.dolar = USD_Alis;
            return coinKur;
        }

        public List<BlogAdListResponse> BlogAdList(KullaniciAdRequest kullaniciAdRequest)
        {
            int kId = _kullanicilarRepository.Find(x => x.KullaniciAdi == kullaniciAdRequest.KullaniciAdi).Id;
            return _mapper.Map<List<BlogAdListResponse>>(_makalelerRepository.List(x=>x.KullaniciIdi==kId));

        }

        public BaseResponse ReklamVer(ReklamVerRequest reklamVerRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
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
            float dolarKur = float.Parse(USD_Alis, CultureInfo.InvariantCulture.NumberFormat);

            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.KullaniciAdi == reklamVerRequest.KullaniciAdi);
            if((emp.data.amount * kullanicilar.Bakiye * dolarKur)< reklamVerRequest.Tarife){
                baseResponse.durum = true;
                baseResponse.mesaj = "Reklam verecek yeter kadar bakiyeniz bulunmamaktadır.";
            }
            else
            {
                kullanicilar.Bakiye -= (float)Math.Round(reklamVerRequest.Tarife / (emp.data.amount * dolarKur),4);
            string blogBaslik = _makalelerRepository.Find(x => x.Id == reklamVerRequest.BlogId).Baslik;
            string blogResim = _makalelerRepository.Find(x => x.Id == reklamVerRequest.BlogId).Resim;
            string blogTarih = _makalelerRepository.Find(x => x.Id == reklamVerRequest.BlogId).Tarih;
            string blogSlug = _makalelerRepository.Find(x => x.Id == reklamVerRequest.BlogId).Slug;
            Reklamlar reklamlar = new Reklamlar();
            reklamlar.AdSoyad = kullanicilar.Ad+" "+kullanicilar.Soyad;
            reklamlar.Baslik = blogBaslik;
            reklamlar.Resim = blogResim;
            reklamlar.Slug = blogSlug;
            reklamlar.Tarih = blogTarih;
            reklamlar.Tur = reklamVerRequest.Tarife;
            reklamlar.YayinOnay = false;
            _reklamlarRepository.Insert(reklamlar);
         
            baseResponse.durum = true;
            baseResponse.mesaj = "Yönetici Onayından Sonra Reklamınız Verilecektir.";
            }
            return baseResponse;
        }

        public List<Reklamlar> ReklamlarList()
        {
            return _mapper.Map<List<Reklamlar>>(_reklamlarRepository.List(x=>x.YayinOnay==false).OrderByDescending(x=>x.Id).ToList());

        }

        public BaseResponse ReklamOnayla(MakaleIdRequest makaleIdRequest)
        {
         //   Makaleler makaleler = _makalelerRepository.Find(x => x.Id == makaleIdRequest.Id);
            Reklamlar reklamlar = _reklamlarRepository.Find(x => x.Id == makaleIdRequest.Id);
            reklamlar.YayinOnay = true;
            reklamlar.YayinKalkisTarih = _genelAppService.Tarih(reklamlar.Tur);
            _reklamlarRepository.Update(reklamlar);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Reklam Onaylandı";
            return baseResponse;
        }

        public BaseResponse ReklamSil(MakaleIdRequest makaleIdRequest)
        {
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


            Reklamlar reklamlar = _reklamlarRepository.Find(x => x.Id == makaleIdRequest.Id);
            Kullanicilar kullanicilar = _kullanicilarRepository.Find(x => x.Ad + " " + x.Soyad == reklamlar.AdSoyad);
            kullanicilar.Bakiye += reklamlar.Tur / (dolarKur * emp.data.amount);
            _kullanicilarRepository.Update(kullanicilar);
            _reklamlarRepository.Delete(reklamlar);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Reklam Başarıyla Silindi";
            return baseResponse;
        }

        public List<Reklamlar> ReklamlarOnaylananList()
        {
            return _mapper.Map<List<Reklamlar>>(_reklamlarRepository.List(x => x.YayinOnay == true && x.YayinKalkisTarih>=_genelAppService.Tarih(0)).OrderByDescending(x => x.Id).ToList());

        }

        public BaseResponse Begen(BegenRequest begenRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            Begeniler begeniler = _begenilerRepository.Find(x => x.KullaniciAdi == begenRequest.KullaniciAdi && x.Slug == begenRequest.Slug);
            if (begeniler != null)
            {
                baseResponse.durum = false;
                baseResponse.mesaj = "Bu Paylaşım Zaten Beğenildi..";
            }
            else
            {
                Begeniler begeniler1 = new Begeniler();
                begeniler1.KullaniciAdi = begenRequest.KullaniciAdi;
                begeniler1.Slug = begenRequest.Slug;
                _begenilerRepository.Insert(begeniler1);
                baseResponse.durum = true;
                baseResponse.mesaj = "Paylaşım Beğenildi.";
                int sayi= _begenilerRepository.List(x=>x.Slug == begenRequest.Slug).Count();
                if (sayi % 2 == 0)
                {
                    #region Post Transaction

                    List<Transactions> transactions = new List<Transactions>(){new Transactions()
                {

                sender="Sistem",
                receiver="Beğeniler",
                amount =0.0500f
                }
                };
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://127.0.0.1:5000/");
                    HttpResponseMessage responseMessage = client.PostAsJsonAsync("add_transaction", transactions[0]).Result;
                    var emp1 = responseMessage.Content.ReadAsAsync<AddTransactionResponse>().Result;

                    #endregion
                    #region Json Listeleme ve Temizleme
                    StreamReader rr = new StreamReader("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\transactions.json");
                    string json2 = rr.ReadToEnd();
                    dynamic array = JsonConvert.DeserializeObject(json2);
                    List<Transactions> sorular = JsonConvert.DeserializeObject<List<Transactions>>(json2);
                    rr.Close();
                    System.IO.File.WriteAllText("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\transactions.json", string.Empty);


                    #endregion
                    #region Eski Liste İle Tekrar Listeye Dökme

                    if (sorular != null)
                        transactions.AddRange(sorular);

                    string dosya_yolu1 = @"D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\transactions.json";
                    StreamWriter sw1 = File.AppendText(dosya_yolu1);
                    string json1 = JsonConvert.SerializeObject(transactions);
                    sw1.WriteLine(json1);
                    sw1.Flush();
                    sw1.Close();
                    #endregion
                    #region Zinciri Bitirme(mine_block)
                    if (sorular == null)
                    {

                    }
                    else
                    {
                        if (sorular.Count >= 10)
                        {

                            HttpClient client1 = new HttpClient();
                            client1.BaseAddress = new Uri("http://127.0.0.1:5000/");
                            HttpResponseMessage responseMessage1 = client1.GetAsync("mine_block").Result;
                            responseMessage1.EnsureSuccessStatusCode();
                            //    var responseBody = responseMessage1.Content.ReadAsStringAsync();
                            //    var emp = responseMessage1.Content.ReadAsAsync<GenelChainList>().Result;
                            System.IO.File.WriteAllText("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\transactions.json", string.Empty);
                            HttpClient client2 = new HttpClient();
                            client2.BaseAddress = new Uri("http://127.0.0.1:5000/");
                            HttpResponseMessage responseMessage2 = client2.GetAsync("get_chain").Result;
                            responseMessage2.EnsureSuccessStatusCode();
                            var responseBody = responseMessage2.Content.ReadAsStringAsync();
                            GenelChainList emp = responseMessage2.Content.ReadAsAsync<GenelChainList>().Result;



                            System.IO.File.WriteAllText("D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json", string.Empty);



                            string dosya_yolu2 = @"D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\Dosyalar\\chain.json";
                            StreamWriter sw2 = File.AppendText(dosya_yolu2);
                            string json3 = JsonConvert.SerializeObject(emp);
                            sw2.WriteLine(json3);
                            sw2.Flush();
                            sw2.Close();


                        }
                    }

                    #endregion
                }
            }
            return baseResponse;
        }
    }
}
