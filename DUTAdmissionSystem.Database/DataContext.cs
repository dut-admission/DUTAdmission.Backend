namespace DUTAdmissionSystem.Database
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using DUTAdmissionSystem.Database.Schema.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Web;
    using Z.EntityFramework.Plus;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base(@"data source=103.95.197.121;initial catalog=DUTAdmission;User Id=sa;Password=Server2019@)!(;")
        {
        }

        public virtual DbSet<AuditEntry> AuditEntries { get; set; }
        public virtual DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<AchievementLevel> AchievementLevels { get; set; }
        public virtual DbSet<AchievementPrize> AchievementPrizes { get; set; }
        public virtual DbSet<AchievementType> AchievementTypes { get; set; }
        public virtual DbSet<AdmissionNews> AdmissionNews { get; set; }
        public virtual DbSet<BirthInfo> BirthInfoes { get; set; }
        public virtual DbSet<CareerType> CareerTypes { get; set; }
        public virtual DbSet<CircumstanceType> CircumstanceTypes { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ConductType> ConductTypes { get; set; }
        public virtual DbSet<Confiuration> Confiurations { get; set; }
        public virtual DbSet<ContactInfo> ContactInfoes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<ElectionType> ElectionTypes { get; set; }
        public virtual DbSet<EnrollmentArea> EnrollmentAreas { get; set; }
        public virtual DbSet<ErrorMsg> ErrorMsgs { get; set; }
        public virtual DbSet<Ethnic> Ethnics { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<FunctionInScreen> FunctionInScreens { get; set; }
        public virtual DbSet<HighSchoolResult> HighSchoolResults { get; set; }
        public virtual DbSet<HightSchoolPosition> HightSchoolPositions { get; set; }
        public virtual DbSet<HightSchoolYear> HightSchoolYears { get; set; }
        public virtual DbSet<IdentityInfo> IdentityInfoes { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<InsuranceDuration> InsuranceDurations { get; set; }
        public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }
        public virtual DbSet<LearningAbility> LearningAbilities { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PersonalInfo> PersonalInfoes { get; set; }
        public virtual DbSet<PositionType> PositionTypes { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<RelationType> RelationTypes { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Talent> Talents { get; set; }
        public virtual DbSet<TalentType> TalentTypes { get; set; }
        public virtual DbSet<UniversityExamResult> UniversityExamResults { get; set; }
        public virtual DbSet<UniversityInfo> UniversityInfoes { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }




        public override int SaveChanges()
        {
            try
            {
                if (ChangeTracker.HasChanges())
                {
                    foreach (var entry
                        in ChangeTracker.Entries())
                    {
                        try
                        {
                            var root = (Table)entry.Entity;
                            var now = DateTime.Now;
                            switch (entry.State)
                            {
                                case EntityState.Added:
                                    {
                                        root.CreatedAt = now;
                                        root.CreatedBy = GetIdAccount();
                                        root.UpdatedAt = null;
                                        root.UpdatedBy = null;
                                        root.DelFlag = false;
                                        break;
                                    }
                                case EntityState.Modified:
                                    {
                                        root.UpdatedAt = now;
                                        root.UpdatedBy = GetIdAccount();
                                        break;
                                    }
                                case EntityState.Deleted:
                                    {
                                        root.UpdatedAt = now;
                                        root.UpdatedBy = GetIdAccount();
                                        break;
                                    }
                            }
                        }
                        catch
                        {
                        }
                    }

                    var audit = new Audit();
                    audit.PreSaveChanges(this);
                    var rowAffecteds = base.SaveChanges();
                    audit.PostSaveChanges();

                    if (audit.Configuration.AutoSavePreAction != null)
                    {
                        audit.Configuration.AutoSavePreAction(this, audit);
                    }

                    return base.SaveChanges();
                }

                return 0;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirthInfo>()
                .Property(e => e.DateOfBirth)
                .HasPrecision(0);

            modelBuilder.Entity<CareerType>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.CareerType)
                .HasForeignKey(e => e.CareerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CircumstanceType>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.CircumstanceType)
                .HasForeignKey(e => e.CircumstanceId)
                .WillCascadeOnDelete(false); ;

            modelBuilder.Entity<ContactInfo>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.ContactInfo)
                .HasForeignKey(e => e.ContactId)
                .WillCascadeOnDelete(false); ;

            modelBuilder.Entity<ContactInfo>()
                .HasMany(e => e.UserInfoes)
                .WithRequired(e => e.ContactInfo)
                .HasForeignKey(e => e.ContactId)
                .WillCascadeOnDelete(false); 

            modelBuilder.Entity<ElectionType>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.ElectionType)
                .HasForeignKey(e => e.ElectionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FamilyMember>()
                .HasMany(e => e.Families)
                .WithRequired(e => e.FamilyMember)
                .HasForeignKey(e => e.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityInfo>()
                .Property(e => e.DateOfIssue)
                .HasPrecision(0);

            modelBuilder.Entity<IdentityInfo>()
                .HasMany(e => e.UserInfoes)
                .WithRequired(e => e.IdentityInfo)
                .HasForeignKey(e => e.IdentityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceDuration>()
                .HasMany(e => e.InsuranceTypes)
                .WithRequired(e => e.InsuranceDuration)
                .HasForeignKey(e => e.DurationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonalInfo>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.PersonalInfo1)
                .HasForeignKey(e => e.PersonalInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RelationType>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.RelationType)
                .HasForeignKey(e => e.RelationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.DateOfJoiningYouthGroup)
                .HasPrecision(0);
        }

        /// <summary>
        /// Get IdAccount đang login
        /// Author       :   AnTM - 12/10/2018 - create
        /// </summary>
        /// <returns>
        /// IdAccount nếu tồn tại, trả về 0 nếu không tồn tại
        /// </returns>
        public static int GetIdAccount()
        {
            try
            {
                var cookieToken = HttpContext.Current.Request.Cookies["token"];
                if (cookieToken == null)
                {
                    return 0;
                }
                var base64EncodedBytes = System.Convert.FromBase64String(HttpUtility.UrlDecode(cookieToken.Value));
                string token = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                DataContext context = new DataContext();
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}