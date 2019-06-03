using Application.KonularService.DTO;
using Core.Model.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KonularService
{
    public interface IKonularAppService
    {
        List<KonularListResponse> KonularList();
        KonuResponse KonuDuzenle(KonuIdRequest konuIdRequest);
        KonuResponse KonuGuncelle(KonuResponse konuResponse);
        BaseResponse KonuEkle(KonuResponse konuResponse);
        void KonuSil(KonuIdRequest konuIdRequest);
    }
}
