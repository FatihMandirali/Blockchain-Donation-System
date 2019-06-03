using Application.KullanicilarService.DTO;
using Core.Model.Request;
using Core.Model.Response;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullanicilarService
{
   public interface IKullanicilarAppService
    {
        BaseResponse KullaniciCreate(KullaniciCreateRequest kullaniciCreateRequest);
        List<Kullanicilar> KullaniciList();
        Kullanicilar KullaniciDuzenle(KullaniciIdRequest kullaniciIdRequest);
        Kullanicilar KullaniciBul(KullaniciAdRequest kullaniciAdRequest);
        BaseResponse KullaniciGuncelle(Kullanicilar kullanicilar);
        BaseResponse KullaniciSil(KullaniciIdRequest kullaniciIdRequest);
        BaseResponse KullaniciLogin(Login login);
        BaseResponse KullaniciOdemeAl(OdemeAlRequest odemeAlRequest);
        GenelFinansResponse GenelFinans(GenelFinansRequest genelFinansRequest);
        GenelFinansResponse PesronelGenelFinans();
    }
}
