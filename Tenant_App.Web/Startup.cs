using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tenant_App.Models;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Services;
using Tenant_App.Services.Handler;
using Tenant_App.Utilities.AuthenticationUtility;
using Hangfire;
using Hangfire.SqlServer;
using Tenant_App.Models.DataObjects.AppSettings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Abp.Extensions;
using Tenant_App.Utilities.ExceptionUtility;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http;
using Tweetinvi.Controllers.Account;
using Tweetinvi.Logic.Model;
using Tenant_App.Models.Data;
using Tenant_App.Models.DefaultRolesAndUserSeeds;
using Microsoft.AspNetCore.Authorization;
using Tenant_App.Models.PermissionPolicyHelper;
using System.Threading;
using Tenant_App.Models.DataObjects.EmailMessaging;
using Tenant_App.Models.Domains.Payment;

namespace Tenant_App.Web
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
             .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                Configuration = builder.Build();
            }

            Configuration = builder.Build();
            //CreateFireBaseCredential(env);
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();



            var connect = config.GetSection("ConnectionStrings").Get<List<string>>().FirstOrDefault();
            

            // this will handle ability to change something in your view and see it reflecting without rebuilding 
            services.AddRazorPages()
            .AddRazorRuntimeCompilation();

            services.AddDbContext<AppDbContext>(options =>
            //This is used in .net core for Skip and Take in .Net Core
            //

            options.UseSqlServer(connect));
            

            services.AddIdentity<User, IdentityRole>(options =>
            {

               // options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 4;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>()
              .AddUserManager<UserManager<User>>()
              .AddRoleManager<RoleManager<IdentityRole>>()
              .AddSignInManager<SignInManager<User>>()
              .AddUserStore<UserStore<User, IdentityRole, AppDbContext, string>>()
              .AddRoleStore<RoleStore<IdentityRole, AppDbContext, string>>()
              .AddDefaultTokenProviders();
            
            //remita payment configuration
			services.Configure<RemitaSettings>(config.GetSection("RemitaSettings"));

			//mail configuration
			services.Configure<MailSettings>(config.GetSection("MailSettings"));

			// Add Hangfire services.
			services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connect, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                }));

            

            // have to add this in order to access HttpContext from our own services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // register ISession into our HttpContext lifecycle
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            });

            //services.AddScoped(provider => provider.GetRequiredService().HttpContext?.Session);

            // Add the processing server as IHostedService
            services.AddHangfireServer();


            var appSettingsSection = Configuration.GetSection("AuthenticationSettings");
            var appSettings = appSettingsSection.Get<AuthenticationSettings>();

            // Document Path
            var documentPath = Configuration.GetSection("DocumentPath");
            services.Configure<DocumentPath>(documentPath);
            //Configure the Secret Key
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Expiration = TimeSpan.FromMinutes(5);
                });
            


            services.Configure<PasswordHasherOptions>(options => options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2);
            services.AddMvcCore().AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/Home/Index", "");

            }).AddNToastNotifyToastr(new ToastrOptions
             {
                 ProgressBar = true,
                 PositionClass = ToastPositions.TopRight,
                 CloseButton = true,
                 TimeOut = 40000,
                 ExtendedTimeOut = 0
             });
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    //options.JsonSerializerOptions.
                });

            services.AddMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
            });

            services.AddCors(
                options => options.AddPolicy(
                    name: _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            Configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/CustomAccount/Login";

			});
            // .NET Native DI Abstraction
            RegisterServices(services);


        }
        private void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);

            
        }
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime,
            ILoggerFactory loggerFactory, AppDbContext dataContext,
            IConfiguration configuration)
     

        {
            loggerFactory.AddLog4Net();

            // migrate any database changes on startup(includes initial db creation)
            //dataContext.Database.Migrate();


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
           // dataContext.Database.Migrate();

            ///hang fire dashboard
            app.UseHangfireDashboard();
            // Recurring job to run every minute


            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {

                IgnoreAntiforgeryToken = true                                 // <--This
            });


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

			app.UseSession();

            app.UseNToastNotify();
            

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapAreaControllerRoute(name: "areas", "areas", pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");



                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });

            // Seed Data
            await SeedInitializer.SeedAsync(app);
            //await AppDbInitializer.SeedAsync(app);
        }
    }
}
