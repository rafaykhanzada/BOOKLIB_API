using BOOKLIB_API.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BOOKLIB_API.Helpers
{
    public class DependencyRegistration
    {
        public DependencyRegistration(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
