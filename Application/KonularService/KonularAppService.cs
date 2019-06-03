using Application.GenelService;
using Application.KonularService.DTO;
using AutoMapper;
using Core.Model.Response;
using Core.Repositories.KonularR;
using Core.Tables;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Application.KonularService
{
    public class KonularAppService : IKonularAppService
    {

        private readonly IKonularRepository _konularRepository;
        private readonly IMapper _mapper;
        private readonly IGenelAppService _genelAppService;

      //  private readonly IHostingEnvironment _appEnvironment;
        public KonularAppService(IKonularRepository konularRepository, IMapper mapper, IGenelAppService genelAppService)
        {
            _konularRepository = konularRepository;
            _mapper = mapper;
            _genelAppService = genelAppService;
        }

        public KonuResponse KonuDuzenle(KonuIdRequest konuIdRequest)
        {
            Konular konular = _konularRepository.Find(x => x.Id == konuIdRequest.Id);
            KonuResponse konuResponse = new KonuResponse();
            konuResponse.Hakkinda = konular.Hakkinda;
            konuResponse.Id = konular.Id;
            konuResponse.KonuAdi = konular.KonuAdi;
            konuResponse.Resim = konular.Resim;
            return konuResponse;
        }

        public BaseResponse KonuEkle(KonuResponse konuResponse)
        {
            //eğer böyle bir kategori adı zaten varsa bildirsin ve güncellemeyede ekle
            Konular konular = new Konular();
            konular.Hakkinda = konuResponse.Hakkinda;
            konular.KonuAdi = konuResponse.KonuAdi;
            konular.Slug = _genelAppService.KarakterCevir(konuResponse.KonuAdi);
            if (konuResponse.Resim == "bos")
            {
               // string imagePath = @"D:\Programlama\C#_Uygulamalari\PROJELERİM\Bitirme\Bitirme\Bitirme\Bitirme\wwwroot\Belgeler\Image\bos.png";
                //string imge = _genelAppService.GetBase64StringForImage(imagePath);
                //byte[] img = Convert.FromBase64String(imge);
                //string resimad = _genelAppService.GetImageResimResponse(konuResponse.KonuAdi) + ".jpg";
                //System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                konular.Resim = "bos.png";
            }
            else
            {
                string imagePath = @"C:\Users\fatih\Desktop\BitirmeResim\Konu_Resim\" + konuResponse.Resim;
                string imge = _genelAppService.GetBase64StringForImage(imagePath);
                byte[] img = Convert.FromBase64String(imge);
                string resimad = _genelAppService.GetImageResimResponse(konuResponse.KonuAdi) + ".jpg";
                System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                konular.Resim = resimad;
            }

            _konularRepository.Insert(konular);
            //----
            //var files = HttpContext.Request.Form.Files;
            //foreach (var Image in files)
            //{
            //    if (Image != null && Image.Length > 0)
            //    {
            //        var file = Image;
            //        //There is an error hereD:\Programlama\C#_Uygulamalari\PROJELERİM\Bitirme\Bitirme\Bitirme\Bitirme\wwwroot\Belgeler\Image\20194302147871e.jpg
            //        var uploads = Path.Combine(_appEnvironment.WebRootPath, "D:\\Programlama\\C#_Uygulamalari\\PROJELERİM\\Bitirme\\Bitirme\\Bitirme\\Bitirme\\wwwroot\\Belgeler\\Image");
            //        if (file.Length > 0)
            //        {
            //            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
            //            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
            //            {
            //                file.CopyToAsync(fileStream);
            //                konular.Resim = fileName;
            //                _konularAppService.Insert(konular);
            //            }

            //        }
            //    }
            //}



            BaseResponse baseResponse = new BaseResponse();
            baseResponse.durum = true;
            baseResponse.mesaj = "Başarılı";
            return baseResponse;
        }


        // public string 
        public KonuResponse KonuGuncelle(KonuResponse konuResponse)
        {
            Konular konular = _konularRepository.Find(x => x.Id == konuResponse.Id);
            konular.Hakkinda = konuResponse.Hakkinda;
            konular.KonuAdi = konuResponse.KonuAdi;
            konular.Slug = _genelAppService.KarakterCevir(konuResponse.KonuAdi);
            if (konuResponse.Resim != "bos")
            {
                string imagePath = @"C:\Users\fatih\Desktop\BitirmeResim\Konu_Resim\" + konuResponse.Resim;
                string imge = _genelAppService.GetBase64StringForImage(imagePath);
                byte[] img = Convert.FromBase64String(imge);
                string resimad = _genelAppService.GetImageResimResponse(konuResponse.KonuAdi) + ".jpg";
                System.IO.File.WriteAllBytes(@"wwwroot\Belgeler\Image\" + resimad, img);
                konular.Resim = resimad;
            }



            _konularRepository.Update(konular);

            KonuResponse konuResponse1 = new KonuResponse();
            return _mapper.Map<KonuResponse>(konular);

        }

        public List<KonularListResponse> KonularList()
        {

            return _mapper.Map<List<KonularListResponse>>(_konularRepository.List().OrderByDescending(x => x.Id).ToList());
        }

        public void KonuSil(KonuIdRequest konuIdRequest)
        {
            Konular konular = _konularRepository.Find(x => x.Id == konuIdRequest.Id);
            _konularRepository.Delete(konular);
        }
    }
}
