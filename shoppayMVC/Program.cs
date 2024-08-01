using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using shoppayData.Data;
using shoppayData.Implementation;
using shoppayEntieys.Repository;
using Aspose.Cells.Charts;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using shoppayUtilites;
using Microsoft.CodeAnalysis.Options;
using Aspose.Cells.Drawing;
using shoppayEntieys.Models;
using static System.Collections.Specialized.BitVector32;

namespace shoppayMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<ShopDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
					);

            });





            builder.Services.AddIdentity<IdentityUser,IdentityRole>
            (Options=> Options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromDays(5))
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddEntityFrameworkStores<ShopDbcontext>();

            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();


            builder.Services.AddRazorPages();

            // Add authentication and authorization services
            builder.Services.AddAuthentication(options =>
            {
                // Configure authentication options here
            })
            .AddCookie(options =>
            {
                // Configure cookie options here
            });

            builder.Services.AddAuthorization(options =>
            {
             });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

             if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    
            app.UseAuthorization();  

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(

                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Customer",
                    pattern: "{ area = Admin}/{ controller = product}/{ action = Index}/{ id ?}");
            });

            app.Run();
        }
    }
}
