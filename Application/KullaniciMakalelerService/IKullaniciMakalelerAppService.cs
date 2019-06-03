using Application.KullaniciMakalelerService.DTO;
using Core.Blockchain;
using Core.Model.Response;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.KullaniciMakalelerService
{
   public interface IKullaniciMakalelerAppService
    {
        List<BlogPaylasimResponse> PaylasilanBlogList(KullaniciAdRequest kullaniciAdRequest);
        List<BlogListResponse> BlogList();
        BaseResponse PaylasilanBlogSil(MakaleIdRequest makaleIdRequest);
        BaseResponse ReklamOnayla(MakaleIdRequest makaleIdRequest);
        BaseResponse ReklamSil(MakaleIdRequest makaleIdRequest);

        BaseResponse Begen(BegenRequest begenRequest);


        BlogPaylasimResponse PaylasilanBlogDuzenle(MakaleIdRequest makaleIdRequest);
        BlogPaylasimResponse BagisYapilanBlogDuzenle(KullaniciAdRequest kullaniciAdRequest);
        BaseResponse PaylasilanBlogGuncelle(BlogPaylasimResponse blogPaylasimResponse);
        BaseResponse PaylasilanBlogEkle(MakaleCreateRequest makaleCreateRequest);

        BaseResponse ReklamVer(ReklamVerRequest reklamVerRequest);


        List<BlogListResponse> KategoriBlogList(KategoriAdListRequest kategoriAdListRequest);

        List<YoneticiAdminBlogListResponse> BlogOnayBekleyenList();
        YoneticiAdminBlogListResponse BlogOnayBekleyenIncele(MakaleIdRequest makaleIdRequest);
        BaseResponse BlogOnayBekleyenOnayla(MakaleIdRequest makaleIdRequest);
        BaseResponse BlogOnayBekleyenSil(MakaleIdRequest makaleIdRequest);

        BaseResponse BagisYap(BagisYapRequest bagisYapRequest);

        List<Transactions> BagisList(KullaniciAdRequest kullaniciAdRequest);
        List<Transactions> YoneticiBagisList();
        CoinGenelResponse CoinGenel(KullaniciAdRequest kullaniciAdRequest);
        CoinGenelResponse YoneticiCoinGenel();
        CoinKur CoinKur();

        List<YoneticiAdminBlogListResponse> BlogOnaylananList();

        List<BlogAdListResponse> BlogAdList(KullaniciAdRequest kullaniciAdRequest);
        List<Reklamlar> ReklamlarList();
        List<Reklamlar> ReklamlarOnaylananList();

        IndexBlogInceleResponse IndexBlogIncele(IndexSlugRequest indexSlugRequest);
    }
}
