using DSU21.Data;
using DSU21.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU21
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
            string connection = Configuration["ConnectionString:Default"];
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            options.Cookie.Name="Cookie");
            //connection = Configuration["ConnectionString:Develop"];
            services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(connection,
                options => options.SetPostgresVersion(new Version(9, 5))));

            services.AddDbContext<LoginDbContext>(
                options => options.UseNpgsql(connection,
                options => options.SetPostgresVersion(new Version(9, 5))));

            //services.AddDbContext<AppDbContext>(
            //    options => options.UseSqlite(connection));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<LoginDbContext>(); ;
            services.AddScoped<IDbRepository, DbRepository>();
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.AccessDeniedPath = "/Account/AccessDenied";
            //    options.Cookie.Name = "Cookie";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
            //    options.LoginPath = "/Account/Login";
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;
            //});
            services.AddAuthorization(o =>
            {
                o.AddPolicy("CaptainsOnly", policy => policy.RequireClaim("Level","5"));
            });
            
            services.AddControllersWithViews();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
