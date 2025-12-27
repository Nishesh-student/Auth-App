using AuthApp.application.Abstraction;
using AuthApp.application.Services;
using AuthApp.core.Abstraction.Repositories;
using AuthApp.infrastructure.Repositories;

namespace AuthApp.api
{
    public static class Extension
    {
        public static void ConfigureRepositories(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
        }
        public static void ConfigureServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
        }
    }
}
