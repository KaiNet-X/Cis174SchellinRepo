using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectCentral.Areas.Contacts.Models;
using ProjectCentral.Areas.Movies.Models;
using ProjectCentral.Areas.OlympicGames.Models;
using ProjectCentral.Areas.Ticketing.Models;
using ProjectCentral.Models;

namespace ProjectCentral
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
            services.AddMemoryCache();
            services.AddSession();

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();

            services.AddRouting(
                options => {
                    options.LowercaseUrls = true;
                    options.AppendTrailingSlash = true;
                });

            string serverstring = "Data Source=tcp:projectcentraldatabase.database.windows.net,1433;Initial Catalog=ProjectCentral_db;User Id=Kai@projectcentraldatabase;Password=Ultimatenerd1";

            services.AddDbContext<ContactContextModel>(options =>
            options.UseSqlServer(serverstring));

            services.AddDbContext<MovieContextModel>(options =>
            options.UseSqlServer(serverstring));

            services.AddDbContext<UserContextModel>(options =>
            options.UseSqlServer(serverstring));

            services.AddDbContext<OlympicContext>(options =>
            options.UseSqlServer(serverstring));

            services.AddDbContext<TicketContext>(options =>
            options.UseSqlServer(serverstring));

            services.AddDbContext<UserContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("User")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            options.LoginPath = "/Ticketing/Account/LogIn");
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseDeveloperExceptionPage();

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "custom",
                    pattern: "{controller=Dummy}/{action=CustRoute}/stoopid/dummy/{ree}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller}/{action}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
