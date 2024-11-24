using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tenant_App.Models.Data;
using Tenant_App.Services.Contract.Account;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Services.Contract.FileStorage;
using Tenant_App.Services.Handler.Account;
using Tenant_App.Services.Handler.EmailMessaging;
using Tenant_App.Services.Handler.ErrorLogger;
using Tenant_App.Services.Handler.FileStorage;
using Tenant_App.Utilities.AuthenticationUtility.AuthUser;
using SubAppNew.Application.Interfaces.Services;
using SubAppNew.Server.Services;
using Tenant_App.Services.Contract.ContractTypeContract;
using Tenant_App.Services.Contract.CooperateTenantContract;
using Tenant_App.Services.Contract.IndividualTenantContract;
using Tenant_App.Services.Handler.ContractTypeHandler;
using Tenant_App.Services.Handler.CooperateTenantHandler;
using Tenant_App.Services.Handler.IndividualTenantHandler;
using Tenant_App.Services.Contract.TenantDocumentContract;
using Tenant_App.Services.Handler.PropertyHandler;
using Tenant_App.Services.Handler.TenantDocumentHandlet;
using Tenant_App.Services.Contract.PropertyContract;
using Tenant_App.Services.Contract.PropertiesContract;
using Tenant_App.Services.Handler.PropertiesHandler;
using Tenant_App.Services.Contract.PaymentContract;
using Tenant_App.Services.Handler.PaymentHandler;
using Tenant_App.Services.Contract.DamagesContract;
using Tenant_App.Services.Handler.DamagesHandler;
using Tenant_App.Services.Contract.Frequency;
using Tenant_App.Services.Contract.ServiceCharge;
using Tenant_App.Services.Handler.Frequenccy;
using Tenant_App.Services.Handler.ServiceChargeService;

namespace Tenant_App.Services
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<DbContext, AppDbContext>();
            services.AddTransient(typeof(DbContextOptions<AppDbContext>));
            services.AddTransient<IErrorLogger, ErrorLoggerService>();
            services.AddScoped<IAuthUser, AuthUser>();
            services.AddTransient<IEmailMessaging, EmailMessagingServices>();
            services.AddScoped<IRole, RoleService>();
            //services.AddScoped<IPermission, PermissionService>();
            services.AddScoped<IFileStorageService, LocalFileStorageService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IIndividualTenant, IndividualTenantService>();
            services.AddScoped<ICooperateTenant, CooperateTenantService>();
            services.AddScoped<IContractType, ContractTypeService>();
            services.AddScoped<ITenantDocument, TenantDocumentService>();
            services.AddScoped<IProperty, PropertyService>();
            services.AddScoped<IProperties, PropertiesService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IDamage, DamageService>();
            services.AddScoped<IServiceChargeService, ServiceChargeService>();
            services.AddScoped<IFrequencyService, FrequencyService>();
            services.AddScoped<IDamage, DamageService>();
        }
    }
}
