using KampusLearn.Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KampusLearn.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)// IConfiguration is a inbuilt interface and already Microsoft has a support for DI.
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //The DBContext class is a Dependency class 
            // Any Dependency we have within the application that should be resgitered 
            services.AddDbContext<KampusLearnDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KampusLearn_CS")));
            services.AddCors();// Service registration for CORS
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
          //  Uinsg this middleware we are enabling the Cross-origin Requests.
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();

            }); // AllowAny Origin will allow the request from anywhere.
            app.UseRouting();
          
            app.UseAuthorization();
          


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
