using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeatherAppApi.Models;
using WeatherAppApi.Services;
using Swashbuckle.AspNetCore.Swagger;
//using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Cors.CorsAuthorizationFilterFactory;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using StackExchange.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WeatherAppApi;
using WeatherCore.BO;

namespace WeatherAPI
{
    public class Startup
    {        
        public Startup(IConfiguration configuration,IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                 builder =>
                 {
                     builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                 });
            });

            services.AddSingleton<IWeatherstoreDatabaseSettings>(new WeatherstoreDatabaseSettings()
            {
                ConnectionString = Environment.GetEnvironmentVariable(AppConstant.COSMOS_CONNECTION_STRING),
                DatabaseName= Environment.GetEnvironmentVariable(AppConstant.COSMOS_DATABASE_NAME),
                RedisConnectionString= Environment.GetEnvironmentVariable(AppConstant.REDIS_CONNECTION_STRING),
                WeatherCollectionName= Environment.GetEnvironmentVariable(AppConstant.WEATHER_COLLECTION_NAME)
            });
            
            services.AddSingleton<WeatherService>();
            services.AddSingleton<GetWeatherApiData>();
            services.AddSingleton<WeatherDataAggrigator>(); 
            services.AddSingleton<AverageDataAggrigator>();          

            services.AddMvc()
            .AddJsonOptions(options => options.UseMemberCasing())
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowMyOrigin"));
            });                       
            
            //For Swagger MiddleWare 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "My WeatherApp API",
                    Version = "v1",
                    Description = "A application for comparing weather report from various API",
                    Contact = new Contact
                    {
                        Name = "The Weather Man",
                        Email = string.Empty
                    }
                });               
            });


            //for bearer
            var key = Encoding.UTF8.GetBytes("1234567891234567");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });
            app.UseCors("AllowMyOrigin");
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //For Swaggeer EndPoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Weather Application Api");
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
