using Application.YorumlarService.DTO;
using Core.Model.Response;
using Core.Repositories.KullanicilarR;
using Core.Repositories.MakalelerR;
using Core.Repositories.YorumlarR;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.YorumlarService
{
   public class YorumlarAppService : IYorumlarAppService
    {

        private readonly IYorumlarRepository _yorumlarRepository;
        // private readonly IKullanicilarRepository _kullanicilarRepository;
        private readonly IMakalelerRepository _makalelerRepository;
        //  private readonly IMapper _mapper;
        public YorumlarAppService(IYorumlarRepository yorumlarRepository, IMakalelerRepository makalelerRepository)
        {
            _yorumlarRepository = yorumlarRepository;
            _makalelerRepository = makalelerRepository;
           // _kullanicilarRepository = kullanicilarRepository;
        }

        public BaseResponse YorumYap(YorumRequest yorumRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            int mId = _makalelerRepository.Find(x => x.Slug == yorumRequest.Slug).Id;
            Yorumlar yorumlar = new Yorumlar();
            yorumlar.AdSoyad = yorumRequest.AdSoyad;
            yorumlar.MakalelerIdi = mId;
            yorumlar.Onaylanma = false;
            yorumlar.Email = yorumRequest.Mail;
            yorumlar.YapilanTarih = DateTime.Now.ToString("dd/MM/yyyy");
            yorumlar.YapilanYorum = yorumRequest.Mesaj;
            _yorumlarRepository.Insert(yorumlar);

            baseResponse.durum = true;
            baseResponse.mesaj = "Yorumunuz Başarıyla Yapıldı Yönetici Onayından Sonra Paylaşıma Geçecektir.";
            return baseResponse;
        }
    }
}
