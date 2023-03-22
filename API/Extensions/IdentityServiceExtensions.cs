using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {

            var builder = services.AddIdentityCore<User>(
                 opt =>
                 {
                     opt.User.RequireUniqueEmail = true;
                     opt.Password.RequireLowercase = false;
                     opt.Password.RequireUppercase = false;
                     opt.Password.RequireDigit = false;
                     opt.Password.RequireNonAlphanumeric = false;
                 }
            ).AddRoles<Role>()
            .AddEntityFrameworkStores<DbFoodContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(config["JWTSettings:TokenKey"]))
                    };
                });


            return services;
        }
    }
}
