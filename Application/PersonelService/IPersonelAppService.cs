using Application.PersonelService.DTO;
using Core.Model.Request;
using Core.Model.Response;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.PersonelService
{
    public interface IPersonelAppService
    {
        List<PersonelListResponse> PersonellerList();
        PersonelDuzenleResponse PersonelDuzenle(PersonelKullaniciAdiRequest personelKullaniciAdiRequest);
        string PersonelSil(PersonelKullaniciAdiRequest personelKullaniciAdiRequest);
        string PersonelEkle(PersonelCreateRequest personelCreateRequest);
        BaseResponse YoneticiLogin(Login login);
        BaseResponse GenlBilgiGuncelle(Personeller personeller);
    }
}
