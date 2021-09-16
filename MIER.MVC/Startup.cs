using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //Identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                 .AddDefaultUI();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            });

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            // Add the Kendo UI services to the services container.
            services.AddKendo();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider service)
        {
            //Culture
            var supportedCultures = new[] { new CultureInfo("id-ID") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("id-ID"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
                endpoints.MapRazorPages();
            });

            //Roles
            CreateDefaultUsersAndRoles(service).Wait();
        }

        private async Task CreateDefaultUsersAndRoles(IServiceProvider serviceProvider)
        {
            //Params
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleCheck = false;
            AppUser userCheck = new AppUser();
            IdentityResult result;

            //Adding Boss Role  
            roleCheck = await roleManager.RoleExistsAsync("Boss");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                var applicationRole = new AppRole
                {
                    Name = "Boss",
                    NormalizedName = "BOSS",
                    Description = "Full Access."

                };

                result = await roleManager.CreateAsync(applicationRole);
            }

            //Adding Admin Role  
            roleCheck = await roleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                var applicationRole = new AppRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description = "Access to front office area."

                };

                result = await roleManager.CreateAsync(applicationRole);
            }

            //Adding Design Role  
            roleCheck = await roleManager.RoleExistsAsync("Design");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                var applicationRole = new AppRole
                {
                    Name = "Design",
                    NormalizedName = "DESIGN",
                    Description = "Access to design area."

                };

                result = await roleManager.CreateAsync(applicationRole);
            }


            //Adding fsonbay
            userCheck = await userManager.FindByNameAsync("fsonbay");
            if (userCheck == null)
            {
                var applicationUser = new AppUser
                {
                    FirstName = "Fedi",
                    LastName = "Sonbay",
                    UserName = "fsonbay",
                    NormalizedUserName = "FEDISONBAY",
                    Email = "fedi.sonbay@gmail.com",
                    NormalizedEmail = "FEDI.SONBAY@GMAIL.COM",
                    InsertBy = "SYSTEM",
                    InsertTime = DateTime.Now
                };
                result = await userManager.CreateAsync(applicationUser, "welkom@123");
                result = await userManager.AddToRoleAsync(applicationUser, "Boss");
            }

            //Adding ldhanio
            userCheck = await userManager.FindByNameAsync("ldhanio");
            if (userCheck == null)
            {
                var applicationUser = new AppUser
                {
                    FirstName = "Laurentia",
                    LastName = "Dhanio",
                    UserName = "ldhanio",
                    NormalizedUserName = "LAURENTIADHANIO",
                    Email = "laurentia.dhanio@gmail.com",
                    NormalizedEmail = "LAURENTIA.DHANIO@GMAIL.COM",
                    InsertBy = "SYSTEM",
                    InsertTime = DateTime.Now
                };
                result = await userManager.CreateAsync(applicationUser, "welkom@123");
                result = await userManager.AddToRoleAsync(applicationUser, "Boss");
            }

        }
    }
}
