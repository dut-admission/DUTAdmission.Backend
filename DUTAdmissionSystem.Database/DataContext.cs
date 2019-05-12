namespace DUTAdmissionSystem.Database
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using DUTAdmissionSystem.Database.Schema.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Web;
    using Z.EntityFramework.Plus;
    using Configuration = Schema.Entity.Configuration;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base(@"data source=103.95.197.121;initial catalog=DUTAdmission;User Id=sa;Password=Server2019@)!(;")
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
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
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<ContactInfo> ContactInfoes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<ElectionType> ElectionTypes { get; set; }
        public virtual DbSet<EnrollmentArea> EnrollmentAreas { get; set; }
        public virtual DbSet<ErrorMsg> ErrorMsgs { get; set; }
        public virtual DbSet<Ethnic> Ethnics { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
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
        public virtual DbSet<YouthGroupInfo> YouthGroupInfos { get; set; }

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
            modelBuilder.Entity<AccountGroup>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AccountGroup)
                .HasForeignKey(e => e.AccountGroupId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<AchievementLevel>()
                .HasMany(e => e.Achievements)
                .WithRequired(e => e.AchievementLevel)
                .HasForeignKey(e => e.AchievementLevelId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<AchievementPrize>()
                .HasMany(e => e.Achievements)
                .WithRequired(e => e.AchievementPrize)
                .HasForeignKey(e => e.AchievementPrizeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<AchievementType>()
                .HasMany(e => e.Achievements)
                .WithRequired(e => e.AchievementType)
                .HasForeignKey(e => e.AchievementTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<BirthInfo>()
                .HasMany(e => e.UserInfoes)
                .WithRequired(e => e.BirthInfo)
                .HasForeignKey(e => e.BirthInfoId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CareerType>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.CareerType)
                .HasForeignKey(e => e.CareerTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CircumstanceType>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.CircumstanceType)
                .HasForeignKey(e => e.CircumstanceTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.ClassId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConductType>()
                .HasMany(e => e.HighSchoolResults)
                .WithRequired(e => e.ConductType)
                .HasForeignKey(e => e.ConductTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactInfo>()
                .HasMany(e => e.UserInfoes)
                .WithRequired(e => e.ContactInfo)
                .HasForeignKey(e => e.ContactId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactInfo>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.ContactInfo)
                .HasForeignKey(e => e.ContactId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocumentType>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.DocumentType)
                .HasForeignKey(e => e.DocumentTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ElectionType>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.ElectionType)
                .HasForeignKey(e => e.ElectionTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnrollmentArea>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.EnrollmentArea)
                .HasForeignKey(e => e.EnrollmentAreaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ethnic>()
                .HasMany(e => e.PersonalInfoes)
                .WithRequired(e => e.Ethnic)
                .HasForeignKey(e => e.EthnicId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Faculty)
                .HasForeignKey(e => e.FacultyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FunctionInScreen>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.FunctionInScreen)
                .HasForeignKey(e => e.FunctionInScreenId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HightSchoolYear>()
                .HasMany(e => e.HighSchoolResults)
                .WithRequired(e => e.HightSchoolYear)
                .HasForeignKey(e => e.HightSchoolYearId)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<InsuranceType>()
                .HasMany(e => e.Insurances)
                .WithRequired(e => e.InsuranceType)
                .HasForeignKey(e => e.InsuranceTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LearningAbility>()
                .HasMany(e => e.HighSchoolResults)
                .WithRequired(e => e.LearningAbility)
                .HasForeignKey(e => e.LearningAbilityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nationality>()
                .HasMany(e => e.PersonalInfoes)
                .WithRequired(e => e.Nationality)
                .HasForeignKey(e => e.NationalityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonalInfo>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.PersonalInfo)
                .HasForeignKey(e => e.PersonalInfoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonalInfo>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.PersonalInfo)
                .HasForeignKey(e => e.PersonalInfoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PositionType>()
                .HasMany(e => e.HightSchoolPositions)
                .WithRequired(e => e.PositionType)
                .HasForeignKey(e => e.PositionTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Program>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Program)
                .HasForeignKey(e => e.ProgramId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RelationType>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.RelationType)
                .HasForeignKey(e => e.RelationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Religion>()
                .HasMany(e => e.PersonalInfoes)
                .WithRequired(e => e.Religion)
                .HasForeignKey(e => e.ReligionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Screen>()
                .HasMany(e => e.FunctionInScreens)
                .WithRequired(e => e.Screen)
                .HasForeignKey(e => e.ScreenId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Achievements)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.HighSchoolResults)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.HightSchoolPositions)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Insurances)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Talents)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.UniversityExamResults)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.UniversityExamResults)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.SubjectId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TalentType>()
                .HasMany(e => e.Talents)
                .WithRequired(e => e.TalentType)
                .HasForeignKey(e => e.TalentTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.UserInfo)
                .HasForeignKey(e => e.UserInfoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.UserInfo)
                .HasForeignKey(e => e.UserInfoId)
                .WillCascadeOnDelete(false);
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