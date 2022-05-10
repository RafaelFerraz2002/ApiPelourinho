using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PelourinhoPOS.Web.Host.Models
{
    public partial class posfContext : DbContext
    {
        public posfContext()
        {
        }

        public posfContext(DbContextOptions<posfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbpAuditLog> AbpAuditLogs { get; set; }
        public virtual DbSet<AbpBackgroundJob> AbpBackgroundJobs { get; set; }
        public virtual DbSet<AbpDynamicEntityProperty> AbpDynamicEntityProperties { get; set; }
        public virtual DbSet<AbpDynamicEntityPropertyValue> AbpDynamicEntityPropertyValues { get; set; }
        public virtual DbSet<AbpDynamicProperty> AbpDynamicProperties { get; set; }
        public virtual DbSet<AbpDynamicPropertyValue> AbpDynamicPropertyValues { get; set; }
        public virtual DbSet<AbpEdition> AbpEditions { get; set; }
        public virtual DbSet<AbpEntityChange> AbpEntityChanges { get; set; }
        public virtual DbSet<AbpEntityChangeSet> AbpEntityChangeSets { get; set; }
        public virtual DbSet<AbpEntityPropertyChange> AbpEntityPropertyChanges { get; set; }
        public virtual DbSet<AbpFeature> AbpFeatures { get; set; }
        public virtual DbSet<AbpLanguage> AbpLanguages { get; set; }
        public virtual DbSet<AbpLanguageText> AbpLanguageTexts { get; set; }
        public virtual DbSet<AbpNotification> AbpNotifications { get; set; }
        public virtual DbSet<AbpNotificationSubscription> AbpNotificationSubscriptions { get; set; }
        public virtual DbSet<AbpOrganizationUnit> AbpOrganizationUnits { get; set; }
        public virtual DbSet<AbpOrganizationUnitRole> AbpOrganizationUnitRoles { get; set; }
        public virtual DbSet<AbpPermission> AbpPermissions { get; set; }
        public virtual DbSet<AbpRole> AbpRoles { get; set; }
        public virtual DbSet<AbpRoleClaim> AbpRoleClaims { get; set; }
        public virtual DbSet<AbpSetting> AbpSettings { get; set; }
        public virtual DbSet<AbpTenant> AbpTenants { get; set; }
        public virtual DbSet<AbpTenantNotification> AbpTenantNotifications { get; set; }
        public virtual DbSet<AbpUser> AbpUsers { get; set; }
        public virtual DbSet<AbpUserAccount> AbpUserAccounts { get; set; }
        public virtual DbSet<AbpUserClaim> AbpUserClaims { get; set; }
        public virtual DbSet<AbpUserLogin> AbpUserLogins { get; set; }
        public virtual DbSet<AbpUserLoginAttempt> AbpUserLoginAttempts { get; set; }
        public virtual DbSet<AbpUserNotification> AbpUserNotifications { get; set; }
        public virtual DbSet<AbpUserOrganizationUnit> AbpUserOrganizationUnits { get; set; }
        public virtual DbSet<AbpUserRole> AbpUserRoles { get; set; }
        public virtual DbSet<AbpUserToken> AbpUserTokens { get; set; }
        public virtual DbSet<AbpWebhookEvent> AbpWebhookEvents { get; set; }
        public virtual DbSet<AbpWebhookSendAttempt> AbpWebhookSendAttempts { get; set; }
        public virtual DbSet<AbpWebhookSubscription> AbpWebhookSubscriptions { get; set; }
        public virtual DbSet<Access> Accesses { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticlePo> ArticlePos { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<CashRegister> CashRegisters { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CompositeArticle> CompositeArticles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPo> CustomerPos { get; set; }
        public virtual DbSet<DocHeader> DocHeaders { get; set; }
        public virtual DbSet<DocLine> DocLines { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<IvaTax> IvaTaxes { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Po> Pos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersAccessZone> UsersAccessZones { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<ZonesAccessArticle> ZonesAccessArticles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=posf; Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbpAuditLog>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.ExecutionDuration }, "IX_AbpAuditLogs_TenantId_ExecutionDuration");

                entity.HasIndex(e => new { e.TenantId, e.ExecutionTime }, "IX_AbpAuditLogs_TenantId_ExecutionTime");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpAuditLogs_TenantId_UserId");

                entity.Property(e => e.BrowserInfo).HasMaxLength(512);

                entity.Property(e => e.ClientIpAddress).HasMaxLength(64);

                entity.Property(e => e.ClientName).HasMaxLength(128);

                entity.Property(e => e.CustomData).HasMaxLength(2000);

                entity.Property(e => e.Exception).HasMaxLength(2000);

                entity.Property(e => e.ExceptionMessage).HasMaxLength(1024);

                entity.Property(e => e.MethodName).HasMaxLength(256);

                entity.Property(e => e.Parameters).HasMaxLength(1024);

                entity.Property(e => e.ServiceName).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpBackgroundJob>(entity =>
            {
                entity.HasIndex(e => new { e.IsAbandoned, e.NextTryTime }, "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime");

                entity.Property(e => e.JobArgs).IsRequired();

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<AbpDynamicEntityProperty>(entity =>
            {
                entity.HasIndex(e => e.DynamicPropertyId, "IX_AbpDynamicEntityProperties_DynamicPropertyId");

                entity.HasIndex(e => new { e.EntityFullName, e.DynamicPropertyId, e.TenantId }, "IX_AbpDynamicEntityProperties_EntityFullName_DynamicPropertyId_TenantId")
                    .IsUnique()
                    .HasFilter("([EntityFullName] IS NOT NULL AND [TenantId] IS NOT NULL)");

                entity.Property(e => e.EntityFullName).HasMaxLength(256);

                entity.HasOne(d => d.DynamicProperty)
                    .WithMany(p => p.AbpDynamicEntityProperties)
                    .HasForeignKey(d => d.DynamicPropertyId);
            });

            modelBuilder.Entity<AbpDynamicEntityPropertyValue>(entity =>
            {
                entity.HasIndex(e => e.DynamicEntityPropertyId, "IX_AbpDynamicEntityPropertyValues_DynamicEntityPropertyId");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.DynamicEntityProperty)
                    .WithMany(p => p.AbpDynamicEntityPropertyValues)
                    .HasForeignKey(d => d.DynamicEntityPropertyId);
            });

            modelBuilder.Entity<AbpDynamicProperty>(entity =>
            {
                entity.HasIndex(e => new { e.PropertyName, e.TenantId }, "IX_AbpDynamicProperties_PropertyName_TenantId")
                    .IsUnique()
                    .HasFilter("([PropertyName] IS NOT NULL AND [TenantId] IS NOT NULL)");

                entity.Property(e => e.PropertyName).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpDynamicPropertyValue>(entity =>
            {
                entity.HasIndex(e => e.DynamicPropertyId, "IX_AbpDynamicPropertyValues_DynamicPropertyId");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.DynamicProperty)
                    .WithMany(p => p.AbpDynamicPropertyValues)
                    .HasForeignKey(d => d.DynamicPropertyId);
            });

            modelBuilder.Entity<AbpEdition>(entity =>
            {
                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<AbpEntityChange>(entity =>
            {
                entity.HasIndex(e => e.EntityChangeSetId, "IX_AbpEntityChanges_EntityChangeSetId");

                entity.HasIndex(e => new { e.EntityTypeFullName, e.EntityId }, "IX_AbpEntityChanges_EntityTypeFullName_EntityId");

                entity.Property(e => e.EntityId).HasMaxLength(48);

                entity.Property(e => e.EntityTypeFullName).HasMaxLength(192);

                entity.HasOne(d => d.EntityChangeSet)
                    .WithMany(p => p.AbpEntityChanges)
                    .HasForeignKey(d => d.EntityChangeSetId);
            });

            modelBuilder.Entity<AbpEntityChangeSet>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.CreationTime }, "IX_AbpEntityChangeSets_TenantId_CreationTime");

                entity.HasIndex(e => new { e.TenantId, e.Reason }, "IX_AbpEntityChangeSets_TenantId_Reason");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpEntityChangeSets_TenantId_UserId");

                entity.Property(e => e.BrowserInfo).HasMaxLength(512);

                entity.Property(e => e.ClientIpAddress).HasMaxLength(64);

                entity.Property(e => e.ClientName).HasMaxLength(128);

                entity.Property(e => e.Reason).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpEntityPropertyChange>(entity =>
            {
                entity.HasIndex(e => e.EntityChangeId, "IX_AbpEntityPropertyChanges_EntityChangeId");

                entity.Property(e => e.NewValue).HasMaxLength(512);

                entity.Property(e => e.OriginalValue).HasMaxLength(512);

                entity.Property(e => e.PropertyName).HasMaxLength(96);

                entity.Property(e => e.PropertyTypeFullName).HasMaxLength(192);

                entity.HasOne(d => d.EntityChange)
                    .WithMany(p => p.AbpEntityPropertyChanges)
                    .HasForeignKey(d => d.EntityChangeId);
            });

            modelBuilder.Entity<AbpFeature>(entity =>
            {
                entity.HasIndex(e => new { e.EditionId, e.Name }, "IX_AbpFeatures_EditionId_Name");

                entity.HasIndex(e => new { e.TenantId, e.Name }, "IX_AbpFeatures_TenantId_Name");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Edition)
                    .WithMany(p => p.AbpFeatures)
                    .HasForeignKey(d => d.EditionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AbpLanguage>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.Name }, "IX_AbpLanguages_TenantId_Name");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Icon).HasMaxLength(128);

                entity.Property(e => e.IsDisabled)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AbpLanguageText>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.Source, e.LanguageName, e.Key }, "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<AbpNotification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataTypeName).HasMaxLength(512);

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName)
                    .IsRequired()
                    .HasMaxLength(96);
            });

            modelBuilder.Entity<AbpNotificationSubscription>(entity =>
            {
                entity.HasIndex(e => new { e.NotificationName, e.EntityTypeName, e.EntityId, e.UserId }, "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName_EntityId_UserId");

                entity.HasIndex(e => new { e.TenantId, e.NotificationName, e.EntityTypeName, e.EntityId, e.UserId }, "IX_AbpNotificationSubscriptions_TenantId_NotificationName_EntityTypeName_EntityId_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName).HasMaxLength(96);
            });

            modelBuilder.Entity<AbpOrganizationUnit>(entity =>
            {
                entity.HasIndex(e => e.ParentId, "IX_AbpOrganizationUnits_ParentId");

                entity.HasIndex(e => new { e.TenantId, e.Code }, "IX_AbpOrganizationUnits_TenantId_Code");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(95);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<AbpOrganizationUnitRole>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.OrganizationUnitId }, "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId");

                entity.HasIndex(e => new { e.TenantId, e.RoleId }, "IX_AbpOrganizationUnitRoles_TenantId_RoleId");
            });

            modelBuilder.Entity<AbpPermission>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AbpPermissions_RoleId");

                entity.HasIndex(e => new { e.TenantId, e.Name }, "IX_AbpPermissions_TenantId_Name");

                entity.HasIndex(e => e.UserId, "IX_AbpPermissions_UserId");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AbpPermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AbpRole>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId, "IX_AbpRoles_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId, "IX_AbpRoles_DeleterUserId");

                entity.HasIndex(e => e.LastModifierUserId, "IX_AbpRoles_LastModifierUserId");

                entity.HasIndex(e => new { e.TenantId, e.NormalizedName }, "IX_AbpRoles_TenantId_NormalizedName");

                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(128);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.NormalizedName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.AbpRoleCreatorUsers)
                    .HasForeignKey(d => d.CreatorUserId);

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.AbpRoleDeleterUsers)
                    .HasForeignKey(d => d.DeleterUserId);

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.AbpRoleLastModifierUsers)
                    .HasForeignKey(d => d.LastModifierUserId);
            });

            modelBuilder.Entity<AbpRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AbpRoleClaims_RoleId");

                entity.HasIndex(e => new { e.TenantId, e.ClaimType }, "IX_AbpRoleClaims_TenantId_ClaimType");

                entity.Property(e => e.ClaimType).HasMaxLength(256);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AbpRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AbpSetting>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.Name, e.UserId }, "IX_AbpSettings_TenantId_Name_UserId")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_AbpSettings_UserId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpSettings)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpTenant>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId, "IX_AbpTenants_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId, "IX_AbpTenants_DeleterUserId");

                entity.HasIndex(e => e.EditionId, "IX_AbpTenants_EditionId");

                entity.HasIndex(e => e.LastModifierUserId, "IX_AbpTenants_LastModifierUserId");

                entity.HasIndex(e => e.TenancyName, "IX_AbpTenants_TenancyName");

                entity.Property(e => e.ConnectionString).HasMaxLength(1024);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.TenancyName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.AbpTenantCreatorUsers)
                    .HasForeignKey(d => d.CreatorUserId);

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.AbpTenantDeleterUsers)
                    .HasForeignKey(d => d.DeleterUserId);

                entity.HasOne(d => d.Edition)
                    .WithMany(p => p.AbpTenants)
                    .HasForeignKey(d => d.EditionId);

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.AbpTenantLastModifierUsers)
                    .HasForeignKey(d => d.LastModifierUserId);
            });

            modelBuilder.Entity<AbpTenantNotification>(entity =>
            {
                entity.HasIndex(e => e.TenantId, "IX_AbpTenantNotifications_TenantId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataTypeName).HasMaxLength(512);

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName)
                    .IsRequired()
                    .HasMaxLength(96);
            });

            modelBuilder.Entity<AbpUser>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId, "IX_AbpUsers_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId, "IX_AbpUsers_DeleterUserId");

                entity.HasIndex(e => e.LastModifierUserId, "IX_AbpUsers_LastModifierUserId");

                entity.HasIndex(e => new { e.TenantId, e.NormalizedEmailAddress }, "IX_AbpUsers_TenantId_NormalizedEmailAddress");

                entity.HasIndex(e => new { e.TenantId, e.NormalizedUserName }, "IX_AbpUsers_TenantId_NormalizedUserName");

                entity.Property(e => e.AuthenticationSource).HasMaxLength(64);

                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(128);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmailConfirmationCode).HasMaxLength(328);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.NormalizedEmailAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordResetCode).HasMaxLength(328);

                entity.Property(e => e.PhoneNumber).HasMaxLength(32);

                entity.Property(e => e.SecurityStamp).HasMaxLength(128);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.InverseCreatorUser)
                    .HasForeignKey(d => d.CreatorUserId);

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.InverseDeleterUser)
                    .HasForeignKey(d => d.DeleterUserId);

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.InverseLastModifierUser)
                    .HasForeignKey(d => d.LastModifierUserId);
            });

            modelBuilder.Entity<AbpUserAccount>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress, "IX_AbpUserAccounts_EmailAddress");

                entity.HasIndex(e => new { e.TenantId, e.EmailAddress }, "IX_AbpUserAccounts_TenantId_EmailAddress");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserAccounts_TenantId_UserId");

                entity.HasIndex(e => new { e.TenantId, e.UserName }, "IX_AbpUserAccounts_TenantId_UserName");

                entity.HasIndex(e => e.UserName, "IX_AbpUserAccounts_UserName");

                entity.Property(e => e.EmailAddress).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpUserClaim>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.ClaimType }, "IX_AbpUserClaims_TenantId_ClaimType");

                entity.HasIndex(e => e.UserId, "IX_AbpUserClaims_UserId");

                entity.Property(e => e.ClaimType).HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpUserLogin>(entity =>
            {
                entity.HasIndex(e => new { e.ProviderKey, e.TenantId }, "IX_AbpUserLogins_ProviderKey_TenantId")
                    .IsUnique()
                    .HasFilter("([TenantId] IS NOT NULL)");

                entity.HasIndex(e => new { e.TenantId, e.LoginProvider, e.ProviderKey }, "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserLogins_TenantId_UserId");

                entity.HasIndex(e => e.UserId, "IX_AbpUserLogins_UserId");

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpUserLoginAttempt>(entity =>
            {
                entity.HasIndex(e => new { e.TenancyName, e.UserNameOrEmailAddress, e.Result }, "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Result");

                entity.HasIndex(e => new { e.UserId, e.TenantId }, "IX_AbpUserLoginAttempts_UserId_TenantId");

                entity.Property(e => e.BrowserInfo).HasMaxLength(512);

                entity.Property(e => e.ClientIpAddress).HasMaxLength(64);

                entity.Property(e => e.ClientName).HasMaxLength(128);

                entity.Property(e => e.TenancyName).HasMaxLength(64);

                entity.Property(e => e.UserNameOrEmailAddress).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpUserNotification>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.State, e.CreationTime }, "IX_AbpUserNotifications_UserId_State_CreationTime");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AbpUserOrganizationUnit>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.OrganizationUnitId }, "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserOrganizationUnits_TenantId_UserId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<AbpUserRole>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.RoleId }, "IX_AbpUserRoles_TenantId_RoleId");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserRoles_TenantId_UserId");

                entity.HasIndex(e => e.UserId, "IX_AbpUserRoles_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpUserToken>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserTokens_TenantId_UserId");

                entity.HasIndex(e => e.UserId, "IX_AbpUserTokens_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Value).HasMaxLength(512);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpWebhookEvent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.WebhookName).IsRequired();
            });

            modelBuilder.Entity<AbpWebhookSendAttempt>(entity =>
            {
                entity.HasIndex(e => e.WebhookEventId, "IX_AbpWebhookSendAttempts_WebhookEventId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.WebhookEvent)
                    .WithMany(p => p.AbpWebhookSendAttempts)
                    .HasForeignKey(d => d.WebhookEventId);
            });

            modelBuilder.Entity<AbpWebhookSubscription>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Secret).IsRequired();

                entity.Property(e => e.WebhookUri).IsRequired();
            });

            modelBuilder.Entity<Access>(entity =>
            {
                entity.ToTable("access");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Accesses)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_access_level");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AsWeight).HasColumnName("as_weight");

                entity.Property(e => e.AskVal).HasColumnName("ask_val");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ForSale).HasColumnName("for_sale");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.IndexColor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("index_color");

                entity.Property(e => e.IsMenu).HasColumnName("is_menu");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("priority");

                entity.Property(e => e.Unity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unity");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("weight");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_article_sub_family");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Article)
                    .HasForeignKey<Article>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_article_menu");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_article_level");
            });

            modelBuilder.Entity<ArticlePo>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.ToTable("article_pos");

                entity.Property(e => e.ArticleId)
                    .ValueGeneratedNever()
                    .HasColumnName("article_id");

                entity.Property(e => e.BarCode).HasColumnName("bar_code");

                entity.Property(e => e.CompositeArticleId).HasColumnName("composite_article_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Iva).HasColumnName("iva");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.Pvp1)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp1");

                entity.Property(e => e.Pvp10)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp10");

                entity.Property(e => e.Pvp2)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp2");

                entity.Property(e => e.Pvp3)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp3");

                entity.Property(e => e.Pvp4)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp4");

                entity.Property(e => e.Pvp5)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp5");

                entity.Property(e => e.Pvp6)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp6");

                entity.Property(e => e.Pvp7)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp7");

                entity.Property(e => e.Pvp8)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp8");

                entity.Property(e => e.Pvp9)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("pvp9");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.HasOne(d => d.Article)
                    .WithOne(p => p.ArticlePo)
                    .HasForeignKey<ArticlePo>(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_article_pos_article");

                entity.HasOne(d => d.IvaNavigation)
                    .WithMany(p => p.ArticlePos)
                    .HasForeignKey(d => d.Iva)
                    .HasConstraintName("FK_article_pos_iva_tax");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.ArticlePos)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_article_pos_pos");
            });

            modelBuilder.Entity<Board>(entity =>
            {
                entity.ToTable("board");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BoardNumber).HasColumnName("board_number");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.CoordX).HasColumnName("coord_x");

                entity.Property(e => e.CoordY).HasColumnName("coord_y");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.InUse).HasColumnName("in_use");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Boards)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_board_zone");
            });

            modelBuilder.Entity<CashRegister>(entity =>
            {
                entity.ToTable("cash_register");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("date")
                    .HasColumnName("close_date");

                entity.Property(e => e.CloseHour)
                    .HasColumnType("date")
                    .HasColumnName("close_hour");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.DayBilling)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("day_billing");

                entity.Property(e => e.FinalValue)
                    .HasColumnType("decimal(20, 3)")
                    .HasColumnName("final_value");

                entity.Property(e => e.OpenDate)
                    .HasColumnType("date")
                    .HasColumnName("open_date");

                entity.Property(e => e.OpenHour)
                    .HasColumnType("date")
                    .HasColumnName("open_hour");

                entity.Property(e => e.PosName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pos_name");

                entity.Property(e => e.StartValue)
                    .HasColumnType("decimal(20, 3)")
                    .HasColumnName("start_value");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(20, 3)")
                    .HasColumnName("value");

                entity.Property(e => e.ValueTax)
                    .HasColumnType("decimal(20, 3)")
                    .HasColumnName("value_tax");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.InverseCategoryNavigation)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_category_category");
            });

            modelBuilder.Entity<CompositeArticle>(entity =>
            {
                entity.ToTable("composite_article");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.HasOne(d => d.ArticleNavigation)
                    .WithMany(p => p.InverseArticleNavigation)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_composite_article_composite_article");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.BoardId).HasColumnName("board_id");

                entity.Property(e => e.DebtsToPay).HasColumnName("debts_to_pay");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Nif)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("nif");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("FK_customer_board");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customer_customer_pos");
            });

            modelBuilder.Entity<CustomerPo>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("customer_pos");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.BoardId).HasColumnName("board_id");

                entity.Property(e => e.DebtsToPay).HasColumnName("debts_to_pay");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.CustomerPos)
                    .HasForeignKey(d => d.PosId)
                    .HasConstraintName("FK_customer_pos_pos");
            });

            modelBuilder.Entity<DocHeader>(entity =>
            {
                entity.ToTable("doc_header");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BoardId).HasColumnName("board_id");

                entity.Property(e => e.CashRegisterId).HasColumnName("cash_register_id");

                entity.Property(e => e.CostumerId).HasColumnName("costumer_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.DocTypeId).HasColumnName("doc_type_id");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_method");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subtotal");

                entity.Property(e => e.Time)
                    .HasColumnType("date")
                    .HasColumnName("time");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.DocHeaders)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("FK_doc_header_board");

                entity.HasOne(d => d.CashRegister)
                    .WithMany(p => p.DocHeaders)
                    .HasForeignKey(d => d.CashRegisterId)
                    .HasConstraintName("FK_doc_header_cash_register");

                entity.HasOne(d => d.Costumer)
                    .WithMany(p => p.DocHeaders)
                    .HasForeignKey(d => d.CostumerId)
                    .HasConstraintName("FK_doc_header_customer");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.DocHeaders)
                    .HasForeignKey(d => d.DocTypeId)
                    .HasConstraintName("FK_doc_header_doc_type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DocHeaders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_doc_header_user");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.DocHeaders)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_doc_header_zone");
            });

            modelBuilder.Entity<DocLine>(entity =>
            {
                entity.ToTable("doc_lines");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.DocHeaderId).HasColumnName("doc_header_id");

                entity.Property(e => e.IvaTax)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("iva_tax");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SubtotalIva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subtotal_iva");

                entity.Property(e => e.SubtotalNoIva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subtotal_no_iva");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.DocLines)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_doc_lines_article");

                entity.HasOne(d => d.DocHeader)
                    .WithMany(p => p.DocLines)
                    .HasForeignKey(d => d.DocHeaderId)
                    .HasConstraintName("FK_doc_lines_doc_header");
            });

            modelBuilder.Entity<DocType>(entity =>
            {
                entity.ToTable("doc_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Counter).HasColumnName("counter");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Printer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("printer");

                entity.Property(e => e.ValueType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("value_type");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasMany(d => d.Pos)
                    .WithMany(p => p.Grupos)
                    .UsingEntity<Dictionary<string, object>>(
                        "GroupsPo",
                        l => l.HasOne<Po>().WithMany().HasForeignKey("PosId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_groups_pos_pos"),
                        r => r.HasOne<Group>().WithMany().HasForeignKey("GrupoId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_groups_pos_groups"),
                        j =>
                        {
                            j.HasKey("GrupoId", "PosId");

                            j.ToTable("groups_pos");

                            j.IndexerProperty<int>("GrupoId").HasColumnName("grupo_id");

                            j.IndexerProperty<int>("PosId").HasColumnName("pos_id");
                        });
            });

            modelBuilder.Entity<IvaTax>(entity =>
            {
                entity.ToTable("iva_tax");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Tax)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("tax");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("level");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Po>(entity =>
            {
                entity.ToTable("pos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccesLevelId).HasColumnName("acces_level_id");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DocLinesId).HasColumnName("doc_lines_id");

                entity.Property(e => e.Ip)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ip");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Pos)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_pos_article");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Pos)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_pos_customer");

                entity.HasOne(d => d.DocLines)
                    .WithMany(p => p.Pos)
                    .HasForeignKey(d => d.DocLinesId)
                    .HasConstraintName("FK_pos_doc_lines");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Pos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_pos_user");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Pos)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_pos_zone");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.AdminAccess).HasColumnName("admin_access");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NeedLogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("need_login");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.Nif).HasColumnName("nif");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.SessionClosed)
                    .HasColumnType("date")
                    .HasColumnName("session_closed");

                entity.Property(e => e.SessionStarted)
                    .HasColumnType("date")
                    .HasColumnName("session_started");

                entity.Property(e => e.Tlm).HasColumnName("tlm");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");
            });

            modelBuilder.Entity<UsersAccessZone>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users_access_zones");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UsersAccessZone)
                    .HasForeignKey<UsersAccessZone>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_access_zones_user");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.UsersAccessZones)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_access_zones_zone");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("zone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acess).HasColumnName("acess");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");
            });

            modelBuilder.Entity<ZonesAccessArticle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("zones_access_articles");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.Article)
                    .WithMany()
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK_zones_access_articles_article");

                entity.HasOne(d => d.Zone)
                    .WithMany()
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_zones_access_articles_zone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
