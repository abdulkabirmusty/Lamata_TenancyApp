using Microsoft.EntityFrameworkCore;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Models.Domains.Icons;
using Tenant_App.Models.Domains.EmailTemplate;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tenant_App.Models.Domains.ErrorLog;
using Microsoft.AspNetCore.Identity;
using Tenant_App.Models.Domains.Settings;
using System;
using Tenant_App.Models.Domains.EmployeeProfile;
using Tenant_App.Models.Domains.File;
using Tenant_App.Models.Domains.ContractTypeDomain;
using Tenant_App.Models.Domains.CooperateTenantDomain;
using Tenant_App.Models.Domains.TenantDocument;
using Tenant_App.Models.Domains.IndividualTenantDomain;
using Tenant_App.Models.Domains.PropertyDomain;
using Tenant_App.Models.Domains.Payment;
using Tenant_App.Models.Domains.SubscriptionDomain;
using Tenant_App.Models.Domains.AgentTenantRegistrationDomain;
using Tenant_App.Models.Domains.DamagesDomain;
using Tenant_App.Models.Domains.BankDomain;
using Tenant_App.Models.Domains.ServiceType;

namespace Tenant_App.Models.Data
{
    public class AppDbContext : IdentityDbContext<User,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connect = config.GetSection("ConnectionStrings").Get<List<string>>().FirstOrDefault();
            optionsBuilder.UseSqlServer(connect);


        }

        public virtual DbSet<Icon> Icon { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFile> userFiles { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<UserPasswordHistory> UserPasswordHistories { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<EmailAttachment> EmailAttachments { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<SystemSetting> SystemSetting { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<TenantDocument> TenantDocuments { get; set; }
        public DbSet<TenantDocumentType> TenantDocumentTypes { get; set; }
        public DbSet<CooperateTenant> CooperateTenants { get; set; }
        public DbSet<IndividualTenant> IndividualTenants { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RentalHistory> RentalHistories { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PropertyTenant> PropertyTenants { get; set; }
        public DbSet<NextOfKin> NextOfKin { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<AgentTenantRegistration> AgentTenantRegistrations { get; set; }
        public DbSet<Damage> Damages { get; set; }
        public DbSet<Banks> Banks { get; set; }
		public DbSet<Frequency> Frequencies { get; set; }
		public DbSet<ServiceCharge> ServiceCharges { get; set; }
		public DbSet<ServiceChargePayment> serviceChargePayments { get; set; }
		public DbSet<ServiceType> serviceTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IdentityUserLogin<string>>();
            base.OnModelCreating(modelBuilder);


        }

    }
}