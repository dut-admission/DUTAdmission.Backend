namespace DUTAdmissionSystem.Database.Migrations
{
    using DUTAdmissionSystem.Database.Schema.Entity;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DUTAdmissionSystem.Database.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DUTAdmissionSystem.Database.DataContext context)
        {
            context.AccountGroups.AddOrUpdate(x => x.Name,
                new AccountGroup() { Name = "Admin" },
                new AccountGroup() { Name = "Employee" }
                );

            context.ElectionTypes.AddOrUpdate(x => x.Name,
                new ElectionType() { Name = "Tuyển thẳng" },
                new ElectionType() { Name = "Thi tuyển" }
                );

            context.AchievementLevels.AddOrUpdate(x => x.Name,
                new AchievementLevel() { Name = "Cấp tỉnh/thành phố" },
                new AchievementLevel() { Name = "Cấp huyện/quận" },
                new AchievementLevel() { Name = "Cấp xã/phường" }
                );
            context.AchievementPrizes.AddOrUpdate(x => x.Name,
                new AchievementPrize() { Name = "Giải nhì" },
                new AchievementPrize() { Name = "Giải ba" },
                new AchievementPrize() { Name = "Giải khuyến khích" }
                );
            context.AchievementTypes.AddOrUpdate(x => x.Name,
                new AchievementType() { Name = "Điền kinh" },
                new AchievementType() { Name = "Học sinh giỏi" },
                new AchievementType() { Name = "Văn nghệ" }
                );
            context.CircumstanceTypes.AddOrUpdate(x => x.Name,
                new CircumstanceType() { Name = "Hộ giàu" },
                new CircumstanceType() { Name = "Hộ nghèo" },
                new CircumstanceType() { Name = "Hộ cận nghèo" },
                new CircumstanceType() { Name = "Diện khác" }
                );
            context.Ethnics.AddOrUpdate(x => x.Name,
                new Ethnic() { Name = "Ede" },
                new Ethnic() { Name = "Thái" },
                new Ethnic() { Name = "Mường" },
                new Ethnic() { Name = "Khác" }
                );
            context.Religions.AddOrUpdate(x => x.Name,
                new Religion() { Name = "Thiên cháu giáo" },
                new Religion() { Name = "Phật giáo" },
                new Religion() { Name = "Khác" }
                );
            context.Nationalities.AddOrUpdate(x => x.Name,
                new Nationality() { Name = "Hoa" },
                new Nationality() { Name = "Thái" },
                new Nationality() { Name = "Khác" }
                );
            context.EnrollmentAreas.AddOrUpdate(x => x.Name,
                new EnrollmentArea() { Name = "KV1" },
                new EnrollmentArea() { Name = "KV2-NT" },
                new EnrollmentArea() { Name = "KV2" },
                new EnrollmentArea() { Name = "KV3" }
                );
            context.ConductTypes.AddOrUpdate(x => x.Level,
                new ConductType() { Level = "Tốt" },
                new ConductType() { Level = "Khá" }
                );
            context.HightSchoolYears.AddOrUpdate(x => x.Year,
                new HightSchoolYear() { Year = 10 },
                new HightSchoolYear() { Year = 11 }
                );
            context.LearningAbilities.AddOrUpdate(x => x.Level,
                new LearningAbility() { Level = "Giỏi", StartingPoint = 10, EndingPoint = 8.5 },
                new LearningAbility() { Level = "khá", StartingPoint = 7, EndingPoint = 8.4 }
                );
            context.Subjects.AddOrUpdate(x => x.Name,
                new Subject() { Name = "Lí" },
                new Subject() { Name = "Hóa" }
                );
            context.TalentTypes.AddOrUpdate(x => x.Name,
                new TalentType() { Name = "MC" },
                new TalentType() { Name = "Thể thao" }
                );
            context.PositionTypes.AddOrUpdate(x => x.Name,
                new PositionType() { Name = "Lớp phó" },
                new PositionType() { Name = "Bí thư" }
                );


            var user = new UserInfo()
            {
                FirstName = "An",
                LastName = "Trinh",
                Avatar = "https://png.pngtree.com/svg/20161027/631929649c.svg",
                BirthInfo = new BirthInfo()
                {
                    Sex = true,
                    DateOfBirth = DateTime.Now,
                    PlaceOfBirth = "Da Nang"
                },
                ContactInfo = new ContactInfo()
                {
                    Address = "K82/34, Nguyen Luong Bang, Da Nang.",
                    Email = "trinhminhan1996@gmail.com",
                    PhoneNumber = "0772142887"
                },
                IdentityInfo = new IdentityInfo()
                {
                    IdentityNumber = "205796190",
                    DateOfIssue = DateTime.Now,
                    PlaceOfIssue = "Quang Nam"
                }
            };

            var student = new Student()
            {
                UserInfo = user,
                IdentificationNumber = "BKDN2019",
                HightSchoolName = "THPT Tieu La",
                ElectionType = new ElectionType() { Name = "Đối tượng khác" },
                YouthGroupInfo = null,
                CircumstanceType = new CircumstanceType() { Name = "Hộ bình thường" },
                EnrollmentArea = new EnrollmentArea() { Name = "KV3" },
                PersonalInfo = new PersonalInfo()
                {
                    Ethnic = new Ethnic() { Name = "Kinh" },
                    Nationality = new Nationality() { Name = "Việt Nam" },
                    Religion = new Religion() { Name = "Không" },
                    PermanentResidence = "Tổ 2/7, Bình Tú, Thăng Bình, Quảng Nam"
                },
                Class = new Class()
                {
                    Name = "20T2",
                    SchoolYear = 2020,
                    Department = new Department()
                    {
                        Name = "Công nghệ phần mềm",
                        Faculty = new Faculty()
                        {
                            Name = "Công nghệ thông tin"
                        }
                    },
                    Program = new Program()
                    {
                        Name = "Chương trình tiên tiến"
                    }
                }
            };

            var achievement = new Achievement()
            {
                AchievementLevel = new AchievementLevel() { Name = "Cấp quốc gia" },
                AchievementPrize = new AchievementPrize() { Name = "Giải nhất" },
                AchievementType = new AchievementType() { Name = "Bơi lội" },
                Description = "Đại hội thể dục thể thao lần thứ 20.",
                Student = student
            };

            var highSchoolResult = new HighSchoolResult()
            {
                Student = student,
                GPAScore = 8.5,
                ConductType = new ConductType() { Level = "Trung bình"},
                HightSchoolYear = new HightSchoolYear() { Year = 12},
                LearningAbility = new LearningAbility() { Level = "Trung bình", StartingPoint = 5.5, EndingPoint = 6.9}
            };

            var universityExamResult = new UniversityExamResult()
            {
                Student = student,
                Subject = new Subject() { Name = "Toán" },
                Score = 8
            };

            var talent = new Talent()
            {
                Student = student,
                TalentType = new TalentType() { Name = "Hát" }
            };

            var hightSchoolPosition = new HightSchoolPosition()
            {
                Student = student,
                PositionType = new PositionType() { Name = "Lớp trưởng" }
            };

            var familyMember = new FamilyMember()
            {
                PersonalInfo = new PersonalInfo()
                {
                    Ethnic = new Ethnic() { Name = "Khơ-me" },
                    Nationality = new Nationality() { Name = "Lào" },
                    Religion = new Religion() { Name = "Tin Lành" },
                    PermanentResidence = "Tổ 2/7, Bình Tú, Thăng Bình, Quảng Nam"
                },
                RelationType = new RelationType() { Name = "Cha"},
                CareerType = new CareerType() { Name = "Nông"},
                ContactInfo = new ContactInfo()
                {
                    Address = "Ton Duc Thang, Dong Nai.",
                    Email = "trinhminhlam1970@gmail.com",
                    PhoneNumber = "0934713487"
                },
                YearOfBirth = 1970
            };
            context.Accounts.AddOrUpdate(x => x.UserName,
                new Account()
                {
                    UserInfo = user,
                    AccountGroup = new AccountGroup()
                    {
                        Name = "Student"
                    },
                    Token = "",
                    UserName = "102140055",
                    Password = "password"
                });
            context.HighSchoolResults.AddOrUpdate(x => x.Id, highSchoolResult);
            context.Achievements.AddOrUpdate(x => x.Id, achievement);
            context.UniversityExamResults.AddOrUpdate(x => x.Id, universityExamResult);
            context.Talents.AddOrUpdate(x => x.Id, talent);
            context.HightSchoolPositions.AddOrUpdate(x => x.Id, hightSchoolPosition);
            context.FamilyMembers.AddOrUpdate(x => x.Id, familyMember);
        }
    }
}