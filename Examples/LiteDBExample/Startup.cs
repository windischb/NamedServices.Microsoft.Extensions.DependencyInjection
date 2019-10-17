using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NamedServices.Microsoft.Extensions.DependencyInjection;

namespace LiteDBExample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();

            services.AddNamedSingleton("users", sp => {
                var repo = new LiteRepository("Filename=users.db");
                repo.Database.Mapper.Entity<UserDbModel>().Id(model => model.Username, false);
                return repo;
            });

            services.AddNamedSingleton(LiteDbRepoNames.Clients, sp => {
                var repo = new LiteRepository("Filename=clients.db");
                repo.Database.Mapper.Entity<ClientDbModel>().Id(model => model.Name, false);
                return repo;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
