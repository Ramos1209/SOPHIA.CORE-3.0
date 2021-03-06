﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace SOPHIA_WebApiCore.Identidade
{
    public static class JwTokemConfig
    {
        public static void  AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            //JWT
            var appsettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appsettingsSection);

            var appsettings = appsettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appsettings.Secret);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(barerOpt =>
            {
                barerOpt.RequireHttpsMetadata = false;
                barerOpt.SaveToken = true;
                barerOpt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appsettings.ValidoEm,
                    ValidIssuer = appsettings.Emissor
                };
            });

        }
        public static void UseAuthConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

    }
}
