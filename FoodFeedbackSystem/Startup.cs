using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFeedbackSystem.Models;
using FoodFeedbackSystem.Services;
using FoodFeedbackSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FoodFeedbackSystem
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
            services.AddTransient<ILoginService, Loginservice>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<IAddFeedbackService, AddFeedbackService>();
            services.AddTransient<IViewRatingService, ViewRatingService>();
            services.AddDbContext<FoodfeedbackDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:FoodfeedbackDB"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



            string secretKey = Configuration.GetSection("JWTParameter:SecretKey").Value;



            var jettokenparams = new TokenValidationParameters()

            {

                ValidateIssuer = true,

                ValidateAudience = true,

                ValidateLifetime = true,

                ValidIssuer = Configuration.GetSection("JWTParameter:Issuer").Value,

                ValidAudience = Configuration.GetSection("JWTParameter:Audience").Value,

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

            };



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                .AddJwtBearer(jwtconfig =>

                    jwtconfig.TokenValidationParameters = jettokenparams);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
