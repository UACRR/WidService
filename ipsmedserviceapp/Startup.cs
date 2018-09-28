using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Auth;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper.EquivalencyExpression;
using ipsmedserviceapp.DATA;

namespace ipsmedserviceapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // options => options.UseSqlServer(Configuration.GetConnectionString("MediaServiceContext"))
            services.AddDbContext<MediaServiceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MediaServiceContext")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MediaServiceContext")));
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      IssuerSigningKey = TokenAuthOption.Key,

                      ValidAudience = TokenAuthOption.Audience,
                      ValidIssuer = TokenAuthOption.Issuer,
                      // When receiving a token, check that we've signed it.
                      ValidateIssuerSigningKey = true,
                      // When receiving a token, check that it is still valid.
                      ValidateLifetime = true,
                      // This defines the maximum allowable clock skew - i.e. provides a tolerance on the token expiry time 
                      // when validating the lifetime. As we're creating the tokens locally and validating them on the same 
                      // machines which should have synchronised time, this can be set to zero. Where external tokens are
                      // used, some leeway here could be useful.
                      ClockSkew = TimeSpan.FromMinutes(10)
                  };

              });

#if DEBUG
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
#else
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
#endif
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddAutoMapper(cfg =>
            {
                cfg.AddCollectionMappers();
                cfg.CreateMissingTypeMaps = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });


            loggerFactory.AddConsole();
            app.UseAuthentication();

            app.UseRequestLocalization(BuildLocalizationOptions());
            app.UseMvc();
        }

        // Culture
        private RequestLocalizationOptions BuildLocalizationOptions()
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("uk-UA"),
                new CultureInfo("ru-RU")
            };

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            return options;
        }

    }
}
