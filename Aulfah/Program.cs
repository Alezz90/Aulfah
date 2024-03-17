using Aulfah.BLL.Interfaces;
using Aulfah.DAL;
using Aulfah.DataContex;
using Aulfah.PL.ModelProfile;
using Aulfah.PL.ModelsVM;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Aulfah.Utility;
using Aulfah.DAL.Model;

namespace Aulfah
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
              builder.Services.AddDbContext<ApplicationDBContext>(
                option => option.UseSqlServer(
                    builder.Configuration.GetConnectionString("Aulfah")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();

            builder.Services.ConfigureApplicationCookie(options => {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IUnitofWork, UnitOfWork>();
            builder.Services.AddAutoMapper(m => m.AddProfile(new ProductProfile()));

            builder.Services.AddScoped<IEmailSender, EmailSender>();

            builder.Services.AddAutoMapper(m => m.AddProfile(new ArtistProfile()));


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

            app.UseAuthentication();;

            app.UseAuthorization();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}