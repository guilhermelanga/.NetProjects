using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PesquisarCodigoPostal_API.Data;

namespace PesquisarCodigoPostal_API_MVC
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PesquisarCodigoPostal_API_MVC", Version = "v1" });
            });

            services.AddDbContext<PesquisarCodigoPostal_APIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PesquisarCodigoPostal_APIContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PesquisarCodigoPostal_APIContext DBContext)
        {
            if (env.IsDevelopment())
            {
                //CRIAÇÃO DA DB "AUTOMÁTICA" CASO AINDA NÃO TENHA SIDO CRIADA NO LOCALHOST
                DBContext.Database.EnsureCreated();
                DBContext.Database.Migrate();


                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PesquisarCodigoPostal_API_MVC v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //DECLARAR ACESSOS A API
            app.UseCors(
                options =>
                {
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                    options.AllowAnyOrigin();
                }
                );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
