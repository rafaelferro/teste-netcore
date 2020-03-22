using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.Services;
using ImagineBeyond.Domain;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Repository.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ImagineBeyond.UI.Web
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
            services.AddTransient<ICustomerAppService, CustomerAppService>();
            services.AddTransient<ICustomerRepository, CustumerRepository>();

            string mySqlConnectionStringcm = Configuration.GetValue<string>("ConnectionString:ImagineBeyond");
            services.AddDbContext<ImagineBeyondContext>(options => options.UseMySql(mySqlConnectionStringcm));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
