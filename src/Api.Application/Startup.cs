using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace apllication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            ConfigureService.ConfigureDepenciesService(services);
            ConfigureRepository.ConfigureDepenciesRepository(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "API C#",
                    Description = "API Desenvolvida usando AspNet 3.1 com Arquitetura DDD",
                    Version = "v1",
                    TermsOfService = new Uri("http://suporte.libereli.com.br"),
                    Contact = new OpenApiContact 
                    {
                        Name = "Joao Pedro A",
                        Email = "joao.pedro@liberali.com.br",
                        Url = new Uri("http://suporte.libereli.com.brr")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termos de Licença de Uso",
                        Url = new Uri("http://suporte.libereli.com.br")
                    }
                 });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API com AspNetCore 3.1");
                c.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
