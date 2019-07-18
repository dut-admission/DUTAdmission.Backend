namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 255),
                        Token = c.String(maxLength: 100),
                        AccountGroupId = c.Int(nullable: false),
                        UserInfoId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfo", t => t.UserInfoId)
                .ForeignKey("dbo.AccountGroup", t => t.AccountGroupId, cascadeDelete: true)
                .Index(t => t.AccountGroupId)
                .Index(t => t.UserInfoId);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Avatar = c.String(nullable: false, maxLength: 255),
                        ContactId = c.Int(nullable: false),
                        BirthInfoId = c.Int(nullable: false),
                        IdentityId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BirthInfo", t => t.BirthInfoId, cascadeDelete: true)
                .ForeignKey("dbo.ContactInfo", t => t.ContactId)
                .ForeignKey("dbo.IdentityInfo", t => t.IdentityId)
                .Index(t => t.ContactId)
                .Index(t => t.BirthInfoId)
                .Index(t => t.IdentityId);
            
            CreateTable(
                "dbo.BirthInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfBirth = c.String(nullable: false, maxLength: 255),
                        Sex = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyMember",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationId = c.Int(nullable: false),
                        PersonalInfoId = c.Int(nullable: false),
                        YearOfBirth = c.Int(nullable: false),
                        CareerTypeId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CareerType", t => t.CareerTypeId)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.RelationType", t => t.RelationId)
                .ForeignKey("dbo.ContactInfo", t => t.ContactId)
                .Index(t => t.RelationId)
                .Index(t => t.PersonalInfoId)
                .Index(t => t.CareerTypeId)
                .Index(t => t.ContactId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.CareerType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EthnicId = c.Int(nullable: false),
                        ReligionId = c.Int(nullable: false),
                        NationalityId = c.Int(nullable: false),
                        PermanentResidence = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ethnic", t => t.EthnicId)
                .ForeignKey("dbo.Nationality", t => t.NationalityId)
                .ForeignKey("dbo.Religion", t => t.ReligionId)
                .Index(t => t.EthnicId)
                .Index(t => t.ReligionId)
                .Index(t => t.NationalityId);
            
            CreateTable(
                "dbo.Ethnic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nationality",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Religion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentificationNumber = c.String(nullable: false, maxLength: 50),
                        UserInfoId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        PersonalInfoId = c.Int(nullable: false),
                        CircumstanceTypeId = c.Int(nullable: false),
                        EnrollmentAreaId = c.Int(nullable: false),
                        ElectionTypeId = c.Int(nullable: false),
                        HightSchoolName = c.String(nullable: false, maxLength: 100),
                        YouthGroupInfoId = c.Int(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CircumstanceType", t => t.CircumstanceTypeId)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.ElectionType", t => t.ElectionTypeId)
                .ForeignKey("dbo.EnrollmentArea", t => t.EnrollmentAreaId)
                .ForeignKey("dbo.YouthGroupInfo", t => t.YouthGroupInfoId)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId)
                .ForeignKey("dbo.UserInfo", t => t.UserInfoId)
                .Index(t => t.UserInfoId)
                .Index(t => t.ClassId)
                .Index(t => t.PersonalInfoId)
                .Index(t => t.CircumstanceTypeId)
                .Index(t => t.EnrollmentAreaId)
                .Index(t => t.ElectionTypeId)
                .Index(t => t.YouthGroupInfoId);
            
            CreateTable(
                "dbo.Achievement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        AchievementTypeId = c.Int(nullable: false),
                        AchievementLevelId = c.Int(nullable: false),
                        AchievementPrizeId = c.Int(nullable: false),
                        Description = c.String(maxLength: 255),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AchievementLevel", t => t.AchievementLevelId, cascadeDelete: true)
                .ForeignKey("dbo.AchievementPrize", t => t.AchievementPrizeId, cascadeDelete: true)
                .ForeignKey("dbo.AchievementType", t => t.AchievementTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.AchievementTypeId)
                .Index(t => t.AchievementLevelId)
                .Index(t => t.AchievementPrizeId);
            
            CreateTable(
                "dbo.AchievementLevel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AchievementPrize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AchievementType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CircumstanceType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        SchoolYear = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Program", t => t.ProgramId)
                .Index(t => t.DepartmentId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        FacultyId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Program",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Fees = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentTypeId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false, maxLength: 255),
                        IsValid = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentType", t => t.DocumentTypeId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.DocumentTypeId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.DocumentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ElectionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrollmentArea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        BonusingPoint = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HighSchoolResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        HightSchoolYearId = c.Int(nullable: false),
                        ConductTypeId = c.Int(nullable: false),
                        LearningAbilityId = c.Int(nullable: false),
                        GPAScore = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConductType", t => t.ConductTypeId)
                .ForeignKey("dbo.HightSchoolYear", t => t.HightSchoolYearId)
                .ForeignKey("dbo.LearningAbility", t => t.LearningAbilityId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.HightSchoolYearId)
                .Index(t => t.ConductTypeId)
                .Index(t => t.LearningAbilityId);
            
            CreateTable(
                "dbo.ConductType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HightSchoolYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LearningAbility",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false, maxLength: 50),
                        StartingPoint = c.Double(nullable: false),
                        EndingPoint = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HightSchoolPosition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        PositionTypeId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PositionType", t => t.PositionTypeId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.PositionTypeId);
            
            CreateTable(
                "dbo.PositionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Insurance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsuranceTypeId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InsuranceType", t => t.InsuranceTypeId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.InsuranceTypeId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.InsuranceType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DurationId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InsuranceDuration", t => t.DurationId)
                .Index(t => t.DurationId);
            
            CreateTable(
                "dbo.InsuranceDuration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Fees = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Talent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        TalentTypeId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TalentType", t => t.TalentTypeId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.TalentTypeId);
            
            CreateTable(
                "dbo.TalentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UniversityExamResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.YouthGroupInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfJoiningYouthGroup = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfJoinYouthGroup = c.String(nullable: false, maxLength: 255),
                        HavingBooksOfYouthGroup = c.Boolean(nullable: false),
                        HavingCardsOfYouthGroup = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RelationType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityNumber = c.String(nullable: false, maxLength: 15),
                        DateOfIssue = c.DateTime(precision: 7, storeType: "datetime2"),
                        PlaceOfIssue = c.String(maxLength: 255),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountGroupId = c.Int(nullable: false),
                        FunctionInScreenId = c.Int(nullable: false),
                        IsActived = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountGroup", t => t.AccountGroupId, cascadeDelete: true)
                .ForeignKey("dbo.FunctionInScreen", t => t.FunctionInScreenId)
                .Index(t => t.AccountGroupId)
                .Index(t => t.FunctionInScreenId);
            
            CreateTable(
                "dbo.FunctionInScreen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ScreenId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        Area = c.String(nullable: false, maxLength: 50),
                        ControllerName = c.String(nullable: false, maxLength: 50),
                        ActionName = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Screen", t => t.ScreenId)
                .Index(t => t.ScreenId);
            
            CreateTable(
                "dbo.Screen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdmissionNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        ImageUrl = c.String(nullable: false, maxLength: 255),
                        Summary = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuditEntries",
                c => new
                    {
                        AuditEntryID = c.Int(nullable: false, identity: true),
                        EntitySetName = c.String(maxLength: 255),
                        EntityTypeName = c.String(maxLength: 255),
                        State = c.Int(nullable: false),
                        StateName = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuditEntryID);
            
            CreateTable(
                "dbo.AuditEntryProperties",
                c => new
                    {
                        AuditEntryPropertyID = c.Int(nullable: false, identity: true),
                        AuditEntryID = c.Int(nullable: false),
                        RelationName = c.String(maxLength: 255),
                        PropertyName = c.String(maxLength: 255),
                        OldValue = c.String(),
                        NewValue = c.String(),
                    })
                .PrimaryKey(t => t.AuditEntryPropertyID)
                .ForeignKey("dbo.AuditEntries", t => t.AuditEntryID, cascadeDelete: true)
                .Index(t => t.AuditEntryID);
            
            CreateTable(
                "dbo.Configuration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorMsg",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false, maxLength: 255),
                        Title = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        IsShowing = c.Boolean(nullable: false),
                        Url = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.UniversityInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniversityName = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        Fax = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 50),
                        Summary = c.String(nullable: false),
                        Website = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditEntryProperties", "AuditEntryID", "dbo.AuditEntries");
            DropForeignKey("dbo.FunctionInScreen", "ScreenId", "dbo.Screen");
            DropForeignKey("dbo.Permission", "FunctionInScreenId", "dbo.FunctionInScreen");
            DropForeignKey("dbo.Permission", "AccountGroupId", "dbo.AccountGroup");
            DropForeignKey("dbo.Account", "AccountGroupId", "dbo.AccountGroup");
            DropForeignKey("dbo.Student", "UserInfoId", "dbo.UserInfo");
            DropForeignKey("dbo.UserInfo", "IdentityId", "dbo.IdentityInfo");
            DropForeignKey("dbo.UserInfo", "ContactId", "dbo.ContactInfo");
            DropForeignKey("dbo.FamilyMember", "ContactId", "dbo.ContactInfo");
            DropForeignKey("dbo.FamilyMember", "RelationId", "dbo.RelationType");
            DropForeignKey("dbo.Student", "PersonalInfoId", "dbo.PersonalInfo");
            DropForeignKey("dbo.Student", "YouthGroupInfoId", "dbo.YouthGroupInfo");
            DropForeignKey("dbo.UniversityExamResult", "StudentId", "dbo.Student");
            DropForeignKey("dbo.UniversityExamResult", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Talent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Talent", "TalentTypeId", "dbo.TalentType");
            DropForeignKey("dbo.Insurance", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Insurance", "InsuranceTypeId", "dbo.InsuranceType");
            DropForeignKey("dbo.InsuranceType", "DurationId", "dbo.InsuranceDuration");
            DropForeignKey("dbo.HightSchoolPosition", "StudentId", "dbo.Student");
            DropForeignKey("dbo.HightSchoolPosition", "PositionTypeId", "dbo.PositionType");
            DropForeignKey("dbo.HighSchoolResult", "StudentId", "dbo.Student");
            DropForeignKey("dbo.HighSchoolResult", "LearningAbilityId", "dbo.LearningAbility");
            DropForeignKey("dbo.HighSchoolResult", "HightSchoolYearId", "dbo.HightSchoolYear");
            DropForeignKey("dbo.HighSchoolResult", "ConductTypeId", "dbo.ConductType");
            DropForeignKey("dbo.FamilyMember", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "EnrollmentAreaId", "dbo.EnrollmentArea");
            DropForeignKey("dbo.Student", "ElectionTypeId", "dbo.ElectionType");
            DropForeignKey("dbo.Document", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Document", "DocumentTypeId", "dbo.DocumentType");
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Class", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.Department", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Class", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Student", "CircumstanceTypeId", "dbo.CircumstanceType");
            DropForeignKey("dbo.Achievement", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Achievement", "AchievementTypeId", "dbo.AchievementType");
            DropForeignKey("dbo.Achievement", "AchievementPrizeId", "dbo.AchievementPrize");
            DropForeignKey("dbo.Achievement", "AchievementLevelId", "dbo.AchievementLevel");
            DropForeignKey("dbo.PersonalInfo", "ReligionId", "dbo.Religion");
            DropForeignKey("dbo.PersonalInfo", "NationalityId", "dbo.Nationality");
            DropForeignKey("dbo.FamilyMember", "PersonalInfoId", "dbo.PersonalInfo");
            DropForeignKey("dbo.PersonalInfo", "EthnicId", "dbo.Ethnic");
            DropForeignKey("dbo.FamilyMember", "CareerTypeId", "dbo.CareerType");
            DropForeignKey("dbo.UserInfo", "BirthInfoId", "dbo.BirthInfo");
            DropForeignKey("dbo.Account", "UserInfoId", "dbo.UserInfo");
            DropIndex("dbo.AuditEntryProperties", new[] { "AuditEntryID" });
            DropIndex("dbo.FunctionInScreen", new[] { "ScreenId" });
            DropIndex("dbo.Permission", new[] { "FunctionInScreenId" });
            DropIndex("dbo.Permission", new[] { "AccountGroupId" });
            DropIndex("dbo.UniversityExamResult", new[] { "SubjectId" });
            DropIndex("dbo.UniversityExamResult", new[] { "StudentId" });
            DropIndex("dbo.Talent", new[] { "TalentTypeId" });
            DropIndex("dbo.Talent", new[] { "StudentId" });
            DropIndex("dbo.InsuranceType", new[] { "DurationId" });
            DropIndex("dbo.Insurance", new[] { "StudentId" });
            DropIndex("dbo.Insurance", new[] { "InsuranceTypeId" });
            DropIndex("dbo.HightSchoolPosition", new[] { "PositionTypeId" });
            DropIndex("dbo.HightSchoolPosition", new[] { "StudentId" });
            DropIndex("dbo.HighSchoolResult", new[] { "LearningAbilityId" });
            DropIndex("dbo.HighSchoolResult", new[] { "ConductTypeId" });
            DropIndex("dbo.HighSchoolResult", new[] { "HightSchoolYearId" });
            DropIndex("dbo.HighSchoolResult", new[] { "StudentId" });
            DropIndex("dbo.Document", new[] { "StudentId" });
            DropIndex("dbo.Document", new[] { "DocumentTypeId" });
            DropIndex("dbo.Department", new[] { "FacultyId" });
            DropIndex("dbo.Class", new[] { "ProgramId" });
            DropIndex("dbo.Class", new[] { "DepartmentId" });
            DropIndex("dbo.Achievement", new[] { "AchievementPrizeId" });
            DropIndex("dbo.Achievement", new[] { "AchievementLevelId" });
            DropIndex("dbo.Achievement", new[] { "AchievementTypeId" });
            DropIndex("dbo.Achievement", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "YouthGroupInfoId" });
            DropIndex("dbo.Student", new[] { "ElectionTypeId" });
            DropIndex("dbo.Student", new[] { "EnrollmentAreaId" });
            DropIndex("dbo.Student", new[] { "CircumstanceTypeId" });
            DropIndex("dbo.Student", new[] { "PersonalInfoId" });
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropIndex("dbo.Student", new[] { "UserInfoId" });
            DropIndex("dbo.PersonalInfo", new[] { "NationalityId" });
            DropIndex("dbo.PersonalInfo", new[] { "ReligionId" });
            DropIndex("dbo.PersonalInfo", new[] { "EthnicId" });
            DropIndex("dbo.FamilyMember", new[] { "StudentId" });
            DropIndex("dbo.FamilyMember", new[] { "ContactId" });
            DropIndex("dbo.FamilyMember", new[] { "CareerTypeId" });
            DropIndex("dbo.FamilyMember", new[] { "PersonalInfoId" });
            DropIndex("dbo.FamilyMember", new[] { "RelationId" });
            DropIndex("dbo.UserInfo", new[] { "IdentityId" });
            DropIndex("dbo.UserInfo", new[] { "BirthInfoId" });
            DropIndex("dbo.UserInfo", new[] { "ContactId" });
            DropIndex("dbo.Account", new[] { "UserInfoId" });
            DropIndex("dbo.Account", new[] { "AccountGroupId" });
            DropTable("dbo.UniversityInfo");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Slide");
            DropTable("dbo.ErrorMsg");
            DropTable("dbo.Configuration");
            DropTable("dbo.AuditEntryProperties");
            DropTable("dbo.AuditEntries");
            DropTable("dbo.AdmissionNews");
            DropTable("dbo.Screen");
            DropTable("dbo.FunctionInScreen");
            DropTable("dbo.Permission");
            DropTable("dbo.IdentityInfo");
            DropTable("dbo.RelationType");
            DropTable("dbo.YouthGroupInfo");
            DropTable("dbo.Subject");
            DropTable("dbo.UniversityExamResult");
            DropTable("dbo.TalentType");
            DropTable("dbo.Talent");
            DropTable("dbo.InsuranceDuration");
            DropTable("dbo.InsuranceType");
            DropTable("dbo.Insurance");
            DropTable("dbo.PositionType");
            DropTable("dbo.HightSchoolPosition");
            DropTable("dbo.LearningAbility");
            DropTable("dbo.HightSchoolYear");
            DropTable("dbo.ConductType");
            DropTable("dbo.HighSchoolResult");
            DropTable("dbo.EnrollmentArea");
            DropTable("dbo.ElectionType");
            DropTable("dbo.DocumentType");
            DropTable("dbo.Document");
            DropTable("dbo.Program");
            DropTable("dbo.Faculty");
            DropTable("dbo.Department");
            DropTable("dbo.Class");
            DropTable("dbo.CircumstanceType");
            DropTable("dbo.AchievementType");
            DropTable("dbo.AchievementPrize");
            DropTable("dbo.AchievementLevel");
            DropTable("dbo.Achievement");
            DropTable("dbo.Student");
            DropTable("dbo.Religion");
            DropTable("dbo.Nationality");
            DropTable("dbo.Ethnic");
            DropTable("dbo.PersonalInfo");
            DropTable("dbo.CareerType");
            DropTable("dbo.FamilyMember");
            DropTable("dbo.ContactInfo");
            DropTable("dbo.BirthInfo");
            DropTable("dbo.UserInfo");
            DropTable("dbo.Account");
            DropTable("dbo.AccountGroup");
        }
    }
}
