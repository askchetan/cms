using CMS.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CMS
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
            services.AddDbContext<CMSDbContext>();
            services.AddControllersWithViews();
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options => { options.LoginPath = "/Home/Login"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,CMSDbContext cMSDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "",
                    defaults: new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute(
                  name: "Admin",
                     pattern: "admin/{controller=Pages}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                  name: "Login",
                     pattern: "{controller}/{action}/{returnUrl?}");
                endpoints.MapControllerRoute(
                   name: "cms",
                   pattern: "{pageName}",
                   defaults: new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute(
                  name: "AdminHome",
                  pattern: "admin",
                  defaults: new { controller = "Home", action = "Login" });
            });
            cMSDbContext.Database.Migrate();
        }
    }
}
