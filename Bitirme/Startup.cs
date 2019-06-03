using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.PersonelService;
using Core.DataBaseContext;
using Core.Repositories.PersonellerR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Application.KonularService;
using Core.Repositories.KonularR;
using Application.GenelService;
using Application.KullanicilarService;
using Core.Repositories.KullanicilarR;
using Application.KullaniciMakalelerService;
using Core.Repositories.MakalelerR;
using Application.YorumlarService;
using Core.Repositories.YorumlarR;
using Application.ReklamlarService;
using Core.Repositories.ReklamlarR;
using Core.Model.AppSettingModel;
using Core.Repositories.BegenilerR;

namespace Bitirme
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<BitirmeContext>(
              options => options.UseSqlServer(
                  Configuration.GetConnectionString("BitirmeConnectionString")
                  )
              );

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5000/");
                });
            });
            services.AddSession(options =>
            {
                // 10 dakikalı Redis Timeout Süresi.
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.CookieHttpOnly = true;
            });


            services.Configure<List<ReklamTariler>>(Configuration.GetSection("ReklamTariler"));

            services.AddTransient<IPersonelAppService, PersonelAppService>();
            services.AddTransient(typeof(IPersonelRepository), typeof(PersonelRepository));
            services.AddTransient<IReklamlarAppService, ReklamlarAppService>();
            services.AddTransient(typeof(IReklamlarRepository), typeof(ReklamlarRepository));
            services.AddTransient<IYorumlarAppService, YorumlarAppService>();
            services.AddTransient(typeof(IYorumlarRepository), typeof(YorumlarRepository));
            services.AddTransient<IKullaniciMakalelerAppService,KullaniciMakalelerAppService>();
            services.AddTransient(typeof(IMakalelerRepository), typeof(MakalelerRepository));
            services.AddTransient<IKullanicilarAppService, KullanicilarAppService>();
            services.AddTransient(typeof(IKullanicilarRepository), typeof(KullanicilarRepository));
            services.AddTransient<IKonularAppService, KonularAppService>(); 
            services.AddTransient<IGenelAppService, GenelAppService>();
            services.AddTransient(typeof(IKonularRepository), typeof(KonularRepository));
            services.AddTransient(typeof(IBegenilerRepository), typeof(BegenilerRepository));
            services.AddCors();
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors(MyAllowSpecificOrigins);
            // app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod());
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
