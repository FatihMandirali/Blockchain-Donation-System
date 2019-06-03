using System;
using System.Collections.Generic;
using System.Text;

namespace Application.GenelService
{
   public class GenelAppService : IGenelAppService
    {

        //private readonly IPersonelRepository _personelRepository;
        //private readonly IMapper _mapper;
        //public GenelAppService(IPersonelRepository personelRepository, IMapper mapper)
        //{
        //    _personelRepository = personelRepository;
        //    _mapper = mapper;
        //} 
        DateTime now;
        public GenelAppService()
        {
            
        }
        public int Tarih(int gelen)
        {

            // int dateYear = DateTime.Now.Year;
            // int dateMonth = DateTime.Now.Month;
            //int dateDay = DateTime.Now.Day;
            if (gelen == 10)
            {
                now = DateTime.Now.AddDays(7);
            }
            else if (gelen == 20)
            {
                now = DateTime.Now.AddMonths(1);
            }
            else
                now = DateTime.Now;

            string yil = now.Year.ToString();
            string hafta = now.Month.ToString();
            if (hafta.Length == 1)
                hafta = "0" + hafta;
            string gun= now.Day.ToString();
            if (gun.Length == 1)
                gun = "0" + gun;
            int tarihInt = Convert.ToInt32(yil+hafta+gun);
            return tarihInt;
        }
        public string IsimKisalt(string yazi)
        {
            int uz = yazi.Length;
            string ilk = yazi.Substring(0, 1);
            string son = yazi.Substring(uz - 1, 1);
            string sonuc = ilk + "... ..." + son;
            return sonuc;
        }
        public string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public string GetImageResimResponse(string name)
        {
            DateTime dateTime = DateTime.Now;
            string tarih = dateTime.Year.ToString() + dateTime.Month.ToString() + dateTime.Day.ToString() + dateTime.Hour.ToString() + dateTime.Minute.ToString() + dateTime.Millisecond.ToString() + name;
            return tarih;
        }

        public string KarakterCevir(string kelime)
        {
            string mesaj = kelime;
            char[] oldValue = new char[] { 'ö', 'Ö', 'O', 'ü', 'Ü', 'U', 'ç', 'Ç', 'C', 'İ', 'ı', 'I', 'Ğ', 'ğ', 'G', 'Ş', 'ş', 'S', ' ' };
            char[] newValue = new char[] { 'o', 'o', 'o', 'u', 'u', 'u', 'c', 'c', 'c', 'i', 'i', 'i', 'g', 'g', 'g', 's', 's', 's', '-' };
            for (int sayac = 0; sayac < oldValue.Length; sayac++)
            {
                mesaj = mesaj.Replace(oldValue[sayac], newValue[sayac]).ToLower();
            }
            return mesaj;
        }
    }
}
