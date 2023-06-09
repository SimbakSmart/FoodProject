﻿using API.Entities;
using API.Interfaces;
using API.Repository;
using API.Services;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<TokenService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IGenericRepository<Category>,CategoryRepository>();

            return services;
        }
    }
}
