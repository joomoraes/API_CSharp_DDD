using System;
using Api.Domain.Interfaces.Services.Users;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDepenciesService(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<IUserService, UserService> ();
        }


    }
}
