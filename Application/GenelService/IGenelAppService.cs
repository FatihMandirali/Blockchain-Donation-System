using System;
using System.Collections.Generic;
using System.Text;

namespace Application.GenelService
{
    public interface IGenelAppService
    {
        string GetBase64StringForImage(string imgPath);
        string GetImageResimResponse(string name);
        string KarakterCevir(string kelime);
        string IsimKisalt(string kelime);
        int Tarih(int tarih);

    }
}
