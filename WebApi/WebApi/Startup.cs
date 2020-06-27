using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.Data;
using WebApi.Models;

namespace WebApi
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
            services.AddDbContext<ApiDbContext>(ops =>
                ops.UseInMemoryDatabase("ApiDatabase"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme, 
                    options => Configuration.Bind("JwtSettings", options))
                .AddCookie(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    options => Configuration.Bind("CookieSettings", options));
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider sp)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var dbContext = sp.GetService<ApiDbContext>())
            {
                dbContext.Database.EnsureCreated();
                if (dbContext.Weather.Count() <= 0)
                {
                    string[] Summaries = new[]
                    {
                        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                    };
                    var rng = new Random();
                    dbContext.Weather.AddRange(
                        Enumerable.Range(1, 500).Select(i =>
                            new Weather
                            {
                                Id = i,
                                Date = DateTime.Now.AddDays(i),
                                Summary = Summaries[rng.Next(Summaries.Length)],
                                TemperatureC = rng.Next(-20, 55),
                            }));
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
