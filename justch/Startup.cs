using justch.Models.DAL;
using justch.Models.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace justch
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



            services.AddAntiforgery(o =>
            {
                o.HeaderName = "XSRF-TOKEN";

            });



            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddFlashes().AddMvc();
            services.AddControllersWithViews().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
            option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })

           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hY1YOoglO74S7V325EKjv1wkwfLLBJKS"))
               };
           });
           



            services.AddTransient<AuthentificationServiceImplementation, AuthentificationServiceImplementation>();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");





            }
            app.UseStaticFiles();
            app.Use(async (context, next) =>
            {
                var token = context.Request.Cookies["access_token"];
                if (!string.IsNullOrEmpty(token)) context.Request.Headers.Add("Authorization", "Bearer " + token);

              
                await next();
            });




            app.UseStatusCodePages(async context =>
            {
          
                var response = context.HttpContext.Response;
              

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized || response.StatusCode ==403)
                {
                    var NAME = context.HttpContext.User.Identity.Name;
                    var request = context.HttpContext.Request.Path;
                    DAL_Database_Registre.Add(NAME, "Abscence d'Autorisation pour l'action : " + request, "Systeme");
                   

                    response.Redirect("/");
                }
               

            });
            //app.UseMiddleware<>

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Patient}/{action=Index}/{id?}");
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
