using AdvertApp.Business.Interfaces;
using AdvertApp.Business.Services;
using AdvertApp.Business.ValidationRules;
using AdvertApp.DataAccess.Context;
using AdvertApp.DataAccess.UnitOfWork;
using AdvertApp.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertApp.Business.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IValidator<AboutCreateDto>, AboutCreateDtoValidator>();
            services.AddTransient<IValidator<AboutUpdateDto>, AboutUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<ApplicationCreateDto>, ApplicationCreateDtoValidator>(); 
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>(); 
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>(); 

            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
        }
    }
}
