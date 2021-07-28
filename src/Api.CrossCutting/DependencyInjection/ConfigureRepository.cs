using Api.Data.Context;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDepenciesRepository(IServiceCollection serviceColletion) 
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

             serviceColletion.AddDbContext<MyContext> (
                options => options.UseMySql ("Server=127.0.0.1;Port=3306;Database=dbAPI;Uid=root;Pwd=")
             );
        }
    }
}
