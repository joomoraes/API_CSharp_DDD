using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDepenciesRepository(IServiceCollection serviceColletion) 
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceColletion.AddScoped<IUserRepository, UserImplementation>();

            serviceColletion.AddDbContext<MyContext> (
                options => options.UseMySql ("Server=127.0.0.1;Port=3306;Database=dbAPI;Uid=root;Pwd=")
            );
        }
    }
}
