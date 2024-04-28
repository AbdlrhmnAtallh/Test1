using AspNetCoreHero.ToastNotification;
using BrainBox.Models;
using BrainBox.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;

namespace BrainBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IToyLayer, ToyLayer>();
            builder.Services.AddScoped<IOrderLayer, OrderLayer>();
            
            //Notifications ##
            builder.Services.AddNotyf(config => { config.DurationInSeconds = 10;
                config.IsDismissable = true;
                config.Position = NotyfPosition.BottomRight; });
            // End Notifications Configrations 

            // Connect With Database ##
            builder.Services.AddDbContext<BrainBoxDbContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-4EKG6BP\SQL2022;
                    Initial Catalog=BrainBoxApplication;
                    Integrated Security=SSPI;
                    TrustServerCertificate=True;"));
            // End Conection string ##

            // Authentication
            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", config =>
                {
                    config.Cookie.Name = "MyApp.Cookie";
                    config.LoginPath = "/Account/Login";
                    config.AccessDeniedPath = "/Account/AccessDenied";
                });

            // Authorization
            builder.Services.AddAuthorization(config =>
            {
                config.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));
                config.AddPolicy("Client", policy => policy.RequireClaim("Role", "Client"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Make sure authentication middleware is used before authorization
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
