namespace DUTAdmissionSystem.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
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
                .ForeignKey("dbo.AccountGroup", t => t.AccountGroupId, cascadeDelete: true)
                .ForeignKey("dbo.UserInfo", t => t.UserInfoId, cascadeDelete: true)
                .Index(t => t.AccountGroupId)
                .Index(t => t.UserInfoId);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        Avatar = c.String(maxLength: 255),
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
                        DateOfBirth = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        PlaceOfBirth = c.String(maxLength: 255),
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
                        PhoneNumber = c.String(maxLength: 15),
                        Email = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
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
                        PersonalInfo = c.Int(nullable: false),
                        YearOfBirth = c.Int(nullable: false),
                        CareerId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CareerType", t => t.CareerId)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfo)
                .ForeignKey("dbo.RelationType", t => t.RelationId)
                .ForeignKey("dbo.ContactInfo", t => t.ContactId)
                .Index(t => t.RelationId)
                .Index(t => t.PersonalInfo)
                .Index(t => t.CareerId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.CareerType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Family",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.FamilyMember", t => t.MemberId)
                .Index(t => t.StudentId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentificationNumber = c.String(maxLength: 50),
                        UserInfoId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        PersonalInfoId = c.Int(nullable: false),
                        CircumstanceId = c.Int(nullable: false),
                        EnrollmentAreaId = c.Int(nullable: false),
                        ElectionId = c.Int(nullable: false),
                        DateOfJoiningYouthGroup = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        PlaceOfJoinYouthGroup = c.String(maxLength: 255),
                        HavingBooksOfYouthGroup = c.Boolean(nullable: false),
                        HavingCardsOfYouthGroup = c.Boolean(nullable: false),
                        HightSchoolName = c.String(maxLength: 100),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CircumstanceType", t => t.CircumstanceId)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.ElectionType", t => t.ElectionId)
                .ForeignKey("dbo.EnrollmentArea", t => t.EnrollmentAreaId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalInfo", t => t.PersonalInfoId, cascadeDelete: true)
                .ForeignKey("dbo.UserInfo", t => t.UserInfoId, cascadeDelete: true)
                .Index(t => t.UserInfoId)
                .Index(t => t.ClassId)
                .Index(t => t.PersonalInfoId)
                .Index(t => t.CircumstanceId)
                .Index(t => t.EnrollmentAreaId)
                .Index(t => t.ElectionId);
            
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
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AchievementTypeId)
                .Index(t => t.AchievementLevelId)
                .Index(t => t.AchievementPrizeId);
            
            CreateTable(
                "dbo.AchievementLevel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Program", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        FacultyId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculty", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
                        Url = c.String(maxLength: 255),
                        IsValid = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentType", t => t.DocumentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.DocumentTypeId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.DocumentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
                        BonusingPoint = c.Double(),
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
                .ForeignKey("dbo.ConductType", t => t.ConductTypeId, cascadeDelete: true)
                .ForeignKey("dbo.HightSchoolYear", t => t.HightSchoolYearId, cascadeDelete: true)
                .ForeignKey("dbo.LearningAbility", t => t.LearningAbilityId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.HightSchoolYearId)
                .Index(t => t.ConductTypeId)
                .Index(t => t.LearningAbilityId);
            
            CreateTable(
                "dbo.ConductType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(maxLength: 50),
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
                        Level = c.String(maxLength: 50),
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
                .ForeignKey("dbo.PositionType", t => t.PositionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.PositionTypeId);
            
            CreateTable(
                "dbo.PositionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                .ForeignKey("dbo.InsuranceType", t => t.InsuranceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.InsuranceTypeId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.InsuranceType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
                        Fees = c.Double(nullable: false),
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
                        PermanentResidence = c.String(maxLength: 255),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ethnic", t => t.EthnicId, cascadeDelete: true)
                .ForeignKey("dbo.Nationality", t => t.NationalityId, cascadeDelete: true)
                .ForeignKey("dbo.Religion", t => t.ReligionId, cascadeDelete: true)
                .Index(t => t.EthnicId)
                .Index(t => t.ReligionId)
                .Index(t => t.NationalityId);
            
            CreateTable(
                "dbo.Ethnic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.TalentType", t => t.TalentTypeId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TalentTypeId);
            
            CreateTable(
                "dbo.TalentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                        Name = c.String(maxLength: 50),
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
                        Identitynumber = c.String(maxLength: 1),
                        DateOfIssue = c.DateTime(precision: 0, storeType: "datetime2"),
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
                .ForeignKey("dbo.FunctionInScreen", t => t.FunctionInScreenId, cascadeDelete: true)
                .Index(t => t.AccountGroupId)
                .Index(t => t.FunctionInScreenId);
            
            CreateTable(
                "dbo.FunctionInScreen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ScreenId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        Area = c.String(maxLength: 50),
                        ControllerName = c.String(maxLength: 50),
                        ActionName = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.Int(),
                        DelFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Screen", t => t.ScreenId, cascadeDelete: true)
                .Index(t => t.ScreenId);
            
            CreateTable(
                "dbo.Screen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                        Title = c.String(maxLength: 200),
                        ImageUrl = c.String(maxLength: 255),
                        Summary = c.String(maxLength: 200),
                        Content = c.String(),
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
                "dbo.Confiuration",
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
                        Message = c.String(),
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
                        ImageUrl = c.String(maxLength: 255),
                        Title = c.String(maxLength: 200),
                        Content = c.String(),
                        IsShowing = c.Boolean(nullable: false),
                        Url = c.String(maxLength: 255),
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
                        UniversityName = c.String(maxLength: 200),
                        Address = c.String(maxLength: 200),
                        PhoneNumber = c.String(maxLength: 15),
                        Fax = c.String(maxLength: 30),
                        Email = c.String(maxLength: 50),
                        Summary = c.String(),
                        Website = c.String(maxLength: 255),
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
            DropForeignKey("dbo.UserInfo", "IdentityId", "dbo.IdentityInfo");
            DropForeignKey("dbo.UserInfo", "ContactId", "dbo.ContactInfo");
            DropForeignKey("dbo.FamilyMember", "ContactId", "dbo.ContactInfo");
            DropForeignKey("dbo.FamilyMember", "RelationId", "dbo.RelationType");
            DropForeignKey("dbo.Family", "MemberId", "dbo.FamilyMember");
            DropForeignKey("dbo.Student", "UserInfoId", "dbo.UserInfo");
            DropForeignKey("dbo.UniversityExamResult", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.UniversityExamResult", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Talent", "TalentTypeId", "dbo.TalentType");
            DropForeignKey("dbo.Talent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "PersonalInfoId", "dbo.PersonalInfo");
            DropForeignKey("dbo.PersonalInfo", "ReligionId", "dbo.Religion");
            DropForeignKey("dbo.PersonalInfo", "NationalityId", "dbo.Nationality");
            DropForeignKey("dbo.FamilyMember", "PersonalInfo", "dbo.PersonalInfo");
            DropForeignKey("dbo.PersonalInfo", "EthnicId", "dbo.Ethnic");
            DropForeignKey("dbo.Insurance", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Insurance", "InsuranceTypeId", "dbo.InsuranceType");
            DropForeignKey("dbo.InsuranceType", "DurationId", "dbo.InsuranceDuration");
            DropForeignKey("dbo.HightSchoolPosition", "StudentId", "dbo.Student");
            DropForeignKey("dbo.HightSchoolPosition", "PositionTypeId", "dbo.PositionType");
            DropForeignKey("dbo.HighSchoolResult", "StudentId", "dbo.Student");
            DropForeignKey("dbo.HighSchoolResult", "LearningAbilityId", "dbo.LearningAbility");
            DropForeignKey("dbo.HighSchoolResult", "HightSchoolYearId", "dbo.HightSchoolYear");
            DropForeignKey("dbo.HighSchoolResult", "ConductTypeId", "dbo.ConductType");
            DropForeignKey("dbo.Family", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "EnrollmentAreaId", "dbo.EnrollmentArea");
            DropForeignKey("dbo.Student", "ElectionId", "dbo.ElectionType");
            DropForeignKey("dbo.Document", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Document", "DocumentTypeId", "dbo.DocumentType");
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Class", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.Department", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Class", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Student", "CircumstanceId", "dbo.CircumstanceType");
            DropForeignKey("dbo.Achievement", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Achievement", "AchievementTypeId", "dbo.AchievementType");
            DropForeignKey("dbo.Achievement", "AchievementPrizeId", "dbo.AchievementPrize");
            DropForeignKey("dbo.Achievement", "AchievementLevelId", "dbo.AchievementLevel");
            DropForeignKey("dbo.FamilyMember", "CareerId", "dbo.CareerType");
            DropForeignKey("dbo.UserInfo", "BirthInfoId", "dbo.BirthInfo");
            DropForeignKey("dbo.Account", "UserInfoId", "dbo.UserInfo");
            DropForeignKey("dbo.Account", "AccountGroupId", "dbo.AccountGroup");
            DropIndex("dbo.AuditEntryProperties", new[] { "AuditEntryID" });
            DropIndex("dbo.FunctionInScreen", new[] { "ScreenId" });
            DropIndex("dbo.Permission", new[] { "FunctionInScreenId" });
            DropIndex("dbo.Permission", new[] { "AccountGroupId" });
            DropIndex("dbo.UniversityExamResult", new[] { "SubjectId" });
            DropIndex("dbo.UniversityExamResult", new[] { "StudentId" });
            DropIndex("dbo.Talent", new[] { "TalentTypeId" });
            DropIndex("dbo.Talent", new[] { "StudentId" });
            DropIndex("dbo.PersonalInfo", new[] { "NationalityId" });
            DropIndex("dbo.PersonalInfo", new[] { "ReligionId" });
            DropIndex("dbo.PersonalInfo", new[] { "EthnicId" });
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
            DropIndex("dbo.Student", new[] { "ElectionId" });
            DropIndex("dbo.Student", new[] { "EnrollmentAreaId" });
            DropIndex("dbo.Student", new[] { "CircumstanceId" });
            DropIndex("dbo.Student", new[] { "PersonalInfoId" });
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropIndex("dbo.Student", new[] { "UserInfoId" });
            DropIndex("dbo.Family", new[] { "MemberId" });
            DropIndex("dbo.Family", new[] { "StudentId" });
            DropIndex("dbo.FamilyMember", new[] { "ContactId" });
            DropIndex("dbo.FamilyMember", new[] { "CareerId" });
            DropIndex("dbo.FamilyMember", new[] { "PersonalInfo" });
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
            DropTable("dbo.Confiuration");
            DropTable("dbo.AuditEntryProperties");
            DropTable("dbo.AuditEntries");
            DropTable("dbo.AdmissionNews");
            DropTable("dbo.Screen");
            DropTable("dbo.FunctionInScreen");
            DropTable("dbo.Permission");
            DropTable("dbo.IdentityInfo");
            DropTable("dbo.RelationType");
            DropTable("dbo.Subject");
            DropTable("dbo.UniversityExamResult");
            DropTable("dbo.TalentType");
            DropTable("dbo.Talent");
            DropTable("dbo.Religion");
            DropTable("dbo.Nationality");
            DropTable("dbo.Ethnic");
            DropTable("dbo.PersonalInfo");
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
            DropTable("dbo.Family");
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
