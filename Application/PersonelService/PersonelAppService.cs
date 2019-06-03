using Application.PersonelService.DTO;
using AutoMapper;
using Core.Model.Request;
using Core.Model.Response;
using Core.Repositories.PersonellerR;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.PersonelService
{
    public class PersonelAppService : IPersonelAppService
    {

        private readonly IPersonelRepository _personelRepository;
        private readonly IMapper _mapper;
        public PersonelAppService(IPersonelRepository personelRepository, IMapper mapper)
        {
            _personelRepository = personelRepository;
            _mapper = mapper;
        }

        public BaseResponse GenlBilgiGuncelle(Personeller personeller)
        {
            BaseResponse baseResponse = new BaseResponse();
               Personeller personeller1 = _personelRepository.Find(x => x.Id == personeller.Id);
            personeller1.Ad = personeller.Ad;
            personeller1.Email = personeller.Email;
            personeller1.KullaniciAdi = personeller.KullaniciAdi;
            personeller1.Sifre = personeller.Sifre;
            personeller1.Soyad = personeller.Soyad;
            personeller1.Tc = personeller.Tc;
            personeller1.Telefon = personeller.Telefon;
            _personelRepository.Update(personeller1);
            baseResponse.durum = true;
            baseResponse.mesaj = "Güncelleme Başarılı";
            return baseResponse;
        }

        public PersonelDuzenleResponse PersonelDuzenle(PersonelKullaniciAdiRequest personelKullaniciAdiRequest)
        {
            Personeller personeller = _personelRepository.Find(x => x.KullaniciAdi == personelKullaniciAdiRequest.KullaniciAdi);
            return _mapper.Map<PersonelDuzenleResponse>(personeller);
        }

        public string PersonelEkle(PersonelCreateRequest personelCreateRequest)
        {
            Personeller personeller1 = _personelRepository.Find(x => x.KullaniciAdi.ToUpper() == personelCreateRequest.KullaniciAdi.ToUpper());
            if (personeller1 == null)
            {
                Personeller personeller = new Personeller();
                personeller.KullaniciAdi = personelCreateRequest.KullaniciAdi;
                personeller.Ad = personelCreateRequest.Ad;
                personeller.Email = personelCreateRequest.Email;
                personeller.Sifre = personelCreateRequest.Sifre;
                personeller.Soyad = personelCreateRequest.Soyad;
                personeller.Tc = personelCreateRequest.Tc;
                personeller.Telefon = personelCreateRequest.Telefon;
                _personelRepository.Insert(personeller);
                return "Kayıt Başarılı";
            }
            else
            {
                return "Böyle bir kayıt zaten bulunmakta.";
            }

        }

        public List<PersonelListResponse> PersonellerList()
        {
            return _mapper.Map<List<PersonelListResponse>>(_personelRepository.List());
        }

        public string PersonelSil(PersonelKullaniciAdiRequest personelKullaniciAdiRequest)
        {
            Personeller personeller = _personelRepository.Find(x => x.KullaniciAdi == personelKullaniciAdiRequest.KullaniciAdi);
            _personelRepository.Delete(personeller);
            return "Kayıt Başarıyla Silindi";
        }

        public BaseResponse YoneticiLogin(Login login)
        {
            Personeller personeller = _personelRepository.Find(x => x.KullaniciAdi == login.KullaniciAdi && x.Sifre == login.Sifre);
            BaseResponse baseResponse = new BaseResponse();
            if (personeller == null)
                baseResponse.durum = false;
            else
            {
                baseResponse.mesaj = personeller.KullaniciAdi;
                baseResponse.durum = true;
            }
            return baseResponse;
        }
    }
}
