using Microsoft.Extensions.DependencyInjection;
using SignUpSignInAspNetCore.Interfaces;
using SignUpSignInAspNetCore.Models;
using SignUpSignInAspNetCore.Repositories;
using SignUpSignInAspNetCore.Services;

namespace SignUpSignInAspNetCore.Tools
{
    public static class Extension
    {
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<LoginService>();
        }
    }
}
