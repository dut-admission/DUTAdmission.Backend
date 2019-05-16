using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System;
using System.Linq;
using Z.EntityFramework.Plus;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Implementations
{
    public class StudentProfileService : IStudentProfileService
    {
        private DataContext context = new DataContext();

        public ProfileResponseDto GetStudentProfileByIdAccount(string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var account = context.Accounts.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag);
            if (account == null)
            {
                return null;
            }
            var user = account.UserInfo;
            var student = user.Students.FirstOrDefault();
            var familyMembers = student.FamilyMembers.Select(x => new FamilyMemberResponseDto()
            {
                Name = x.Name,
                Address = x.ContactInfo.Address,
                CareerTypeId = x.CareerTypeId,
                CareerTypeName = x.CareerType.Name,
                Email = x.ContactInfo.Email,
                EthnicId = x.PersonalInfo.EthnicId,
                EthnicName = x.PersonalInfo.Ethnic.Name,
                NationalityId = x.PersonalInfo.NationalityId,
                NationalityName = x.PersonalInfo.Nationality.Name,
                PhoneNumber = x.ContactInfo.PhoneNumber,
                RelationId = x.RelationId,
                RelationName = x.RelationType.Name,
                ReligionId = x.PersonalInfo.ReligionId,
                ReligionName = x.PersonalInfo.Religion.Name,
                YearOfBirth = x.YearOfBirth
            }).ToList();
            var personalInfo = new PersonalInfoResponseDto()
            {
                Address = user.ContactInfo.Address,
                DateOfBirth = user.BirthInfo.DateOfBirth,
                DateOfIssue = user.IdentityInfo.DateOfIssue,
                Email = user.ContactInfo.Email,
                EthnicId = student.PersonalInfo.EthnicId,
                NationalityId = student.PersonalInfo.NationalityId,
                PermanentResidence = student.PersonalInfo.PermanentResidence,
                PhoneNumber = user.ContactInfo.PhoneNumber,
                PlaceOfBirth = user.BirthInfo.PlaceOfBirth,
                PlaceOfIssue = user.IdentityInfo.PlaceOfIssue,
                ReligionId = student.PersonalInfo.ReligionId,
                Sex = user.BirthInfo.Sex
            };

            var universityInfo = new UniversityInfoResponseDto()
            {
                ClassName = student.Class.Name,
                DepartmentName = student.Class.Department.Name,
                ProgramName = student.Class.Program.Name,
                FacultyName = student.Class.Department.Faculty.Name,
                ElectionName = student.ElectionType.Name,
                EnrollmentAreaName = student.EnrollmentArea.Name,
                UniversityExamResults = student.UniversityExamResults
                .Select(e => new UniversityExamResultResponseDto()
                {
                    Id = e.Id,
                    Score = e.Score,
                    SubjectName = e.Subject.Name
                }).ToList()
            };

            var hightSchoolInfo = new HightSchoolInfoResponseDto()
            {
                HightSchoolName = student.HightSchoolName,
                YouthGroupInfo = student.YouthGroupInfo != null
                ? new YouthGroupInfoResponseDto()
                {
                    DateOfJoiningYouthGroup = student.YouthGroupInfo.DateOfJoiningYouthGroup,
                    HavingBooksOfYouthGroup = student.YouthGroupInfo.HavingBooksOfYouthGroup,
                    HavingCardsOfYouthGroup = student.YouthGroupInfo.HavingCardsOfYouthGroup,
                    PlaceOfJoinYouthGroup = student.YouthGroupInfo.PlaceOfJoinYouthGroup
                }
                : null,
                Achievements = student.Achievements.Select(a => new AchievementResponseDto()
                {
                    Id = a.Id,
                    AchievementLevelId = a.AchievementLevelId,
                    AchievementLevelName = a.AchievementLevel.Name,
                    AchievementPrizeId = a.AchievementPrizeId,
                    AchievementPrizeName = a.AchievementPrize.Name,
                    AchievementTypeId = a.AchievementTypeId,
                    AchievementTypeName = a.AchievementType.Name,
                    Description = a.Description
                }).ToList(),
                HighSchoolResults = student.HighSchoolResults.Select(h => new HighSchoolResultResponseInfo()
                {
                    Id = h.Id,
                    ConductTypeId = h.ConductTypeId,
                    GPAScore = h.GPAScore,
                    HightSchoolYearId = h.HightSchoolYearId,
                    LearningAbilityId = h.LearningAbilityId,
                    ConductTypeName = h.ConductType.Level,
                    HightSchoolYear = h.HightSchoolYear.Year,
                    LearningAbilityName = h.LearningAbility.Level
                }).ToList(),
                Positions = student.HightSchoolPositions.Select(p => p.PositionTypeId).ToList(),
                Talents = student.Talents.Select(t => t.TalentTypeId).ToList()
            };

            return new ProfileResponseDto()
            {
                Avatar = user.Avatar,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IdentityNumber = user.IdentityInfo.IdentityNumber,
                IdentificationNumber = student.IdentificationNumber,
                CircumstanceTypeId = student.CircumstanceTypeId,
                FamilyMembers = familyMembers,
                PersonalInfo = personalInfo,
                UniversityInfo = universityInfo,
                HightSchoolInfo = hightSchoolInfo
            };
        }

        public bool UpdatePass(UpdatePassword updatePassword, string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;

            if (string.Compare(FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(updatePassword.OldPassword)), context.Accounts.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag).Password) != 0)
            {
                return false;
            }
            else
            {
                var TaiKhoan = context.Accounts.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag);
                TaiKhoan.Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(updatePassword.NewPassword));
                context.SaveChanges();
                return true;
            }
        }

        public LibrariesOfProFile GetLibrariesOfProFile()
        {
            LibrariesOfProFile librariesOfProFile = new LibrariesOfProFile();

            librariesOfProFile.NationalityList = context.Nationalities.Where(x => !x.DelFlag).Select(x => new Nationality
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.ReligionList = context.Religions.Where(x => !x.DelFlag).Select(x => new Religion
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.EthnicList = context.Ethnics.Where(x => !x.DelFlag).Select(x => new Ethnic
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.ProgramList = context.Programs.Where(x => !x.DelFlag).Select(x => new Program
            {
                Id = x.Id,
                Name = x.Name,
                Fees = x.Fees
            }).ToList();

            librariesOfProFile.FacultyList = context.Faculties.Where(x => !x.DelFlag).Select(x => new Faculty
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.DepartmentList = context.Departments.Where(x => !x.DelFlag).Select(x => new Department
            {
                Id = x.Id,
                Name = x.Name,
                Faculty = new Faculty { Id = x.Faculty.Id, Name = x.Faculty.Name }
            }).ToList();

            librariesOfProFile.ElectionTypeList = context.ElectionTypes.Where(x => !x.DelFlag).Select(x => new ElectionType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.EnrollmentAreaList = context.EnrollmentAreas.Where(x => !x.DelFlag).Select(x => new EnrollmentArea
            {
                Id = x.Id,
                Name = x.Name,
                BonusingPoint = x.BonusingPoint
            }).ToList();

            librariesOfProFile.CircumstanceTypeList = context.CircumstanceTypes.Where(x => !x.DelFlag).Select(x => new CircumstanceType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.HightSchoolYearList = context.HightSchoolYears.Where(x => !x.DelFlag).Select(x => new HightSchoolYear
            {
                Id = x.Id,
                Year = x.Year
            }).ToList();

            librariesOfProFile.ConductTypeList = context.ConductTypes.Where(x => !x.DelFlag).Select(x => new ConductType
            {
                Id = x.Id,
                Level = x.Level
            }).ToList();

            librariesOfProFile.LearningAbilityList = context.LearningAbilities.Where(x => !x.DelFlag).Select(x => new LearningAbility
            {
                Id = x.Id,
                Level = x.Level,
                StartingPoint = x.StartingPoint,
                EndingPoint = x.EndingPoint
            }).ToList();

            librariesOfProFile.CareerTypeList = context.CareerTypes.Where(x => !x.DelFlag).Select(x => new CareerType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.RelationTypeList = context.RelationTypes.Where(x => !x.DelFlag).Select(x => new RelationType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.TalentTypeList = context.TalentTypes.Where(x => !x.DelFlag).Select(x => new TalentType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.DocumentTypeList = context.DocumentTypes.Where(x => !x.DelFlag).Select(x => new DocumentType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.InsuranceTypeList = context.InsuranceTypes.Where(x => !x.DelFlag).Select(x => new InsuranceType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.AchievementPrizeList = context.AchievementPrizes.Where(x => !x.DelFlag).Select(x => new AchievementPrize
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.AchievementLevelList = context.AchievementLevels.Where(x => !x.DelFlag).Select(x => new AchievementLevel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.AchievementTypeList = context.AchievementTypes.Where(x => !x.DelFlag).Select(x => new AchievementType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.SubjectList = context.Subjects.Where(x => !x.DelFlag).Select(x => new Subject
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.PositionTypeList = context.PositionTypes.Where(x => !x.DelFlag).Select(x => new PositionType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return librariesOfProFile;
        }

        public void UpdateAddAchievement(Achievement achievement, string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var Student = context.Students.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag);
            if (achievement.Id == 0)
            {
                context.Achievements.Add(new Database.Schema.Entity.Achievement
                {
                    StudentId = Student.Id,
                    AchievementLevelId = achievement.AchievementLevelId,
                    AchievementPrizeId = achievement.AchievementPrizeId,
                    AchievementTypeId = achievement.AchievementTypeId,
                    Description = achievement.Description
                });
            }
            else
            {
                context.Achievements.Where(x => x.StudentId == Student.Id && x.Id == achievement.Id && !x.DelFlag).Update(x => new Database.Schema.Entity.Achievement
                {
                    AchievementLevelId = achievement.AchievementLevelId,
                    AchievementPrizeId = achievement.AchievementPrizeId,
                    AchievementTypeId = achievement.AchievementTypeId,
                    Description = achievement.Description
                });
            }
            context.SaveChanges();
        }

        public void UpdateAddFamilyMember(FamilyMember FamilyMember, string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var Student = context.Students.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag);

            if (FamilyMember.Id == 0)
            {
                var familyMember = context.FamilyMembers.Add(new Database.Schema.Entity.FamilyMember
                {
                    StudentId = Student.Id,
                    Name = FamilyMember.Name,
                    RelationId = FamilyMember.RelationId,
                    YearOfBirth = FamilyMember.YearOfBirth,
                    CareerTypeId = FamilyMember.CareerTypeId,
                });
                context.PersonalInfoes.Add(new Database.Schema.Entity.PersonalInfo
                {
                    Id = familyMember.PersonalInfoId,
                    EthnicId = FamilyMember.EthnicId,
                    ReligionId = FamilyMember.ReligionId,
                    NationalityId = FamilyMember.NationalityId
                });
                context.ContactInfoes.Add(new Database.Schema.Entity.ContactInfo
                {
                    Id = familyMember.ContactId,
                    PhoneNumber = FamilyMember.PhoneNumber,
                    Email = FamilyMember.Email,
                    Address = FamilyMember.Address
                });
            }
            else
            {
                var family = context.FamilyMembers.FirstOrDefault(x => x.Id == FamilyMember.Id && !x.DelFlag);
                context.FamilyMembers.Where(x => x.StudentId == Student.Id && x.Id == FamilyMember.Id && !x.DelFlag).Update(x => new Database.Schema.Entity.FamilyMember
                {
                    Name = FamilyMember.Name,
                    RelationId = FamilyMember.RelationId,
                    YearOfBirth = FamilyMember.YearOfBirth,
                    CareerTypeId = FamilyMember.CareerTypeId
                });

                context.PersonalInfoes.Where(x => x.Id == family.PersonalInfoId && !x.DelFlag).Update(x => new Database.Schema.Entity.PersonalInfo
                {
                    EthnicId = FamilyMember.EthnicId,
                    ReligionId = FamilyMember.ReligionId,
                    NationalityId = FamilyMember.NationalityId
                });
                context.ContactInfoes.Where(x => x.Id == family.ContactId && !x.DelFlag).Update(x => new Database.Schema.Entity.ContactInfo
                {
                    PhoneNumber = FamilyMember.PhoneNumber,
                    Email = FamilyMember.Email,
                    Address = FamilyMember.Address
                });
            }
            context.SaveChanges();
        }

        public void UpdateAddHighSchoolResult(HighSchoolResult HighSchoolResult, string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var Student = context.Students.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag);

            if (HighSchoolResult.Id == 0)
            {
                context.HighSchoolResults.Add(new Database.Schema.Entity.HighSchoolResult
                {
                    StudentId = Student.Id,
                    HightSchoolYearId = HighSchoolResult.HightSchoolYearId,
                    ConductTypeId = HighSchoolResult.ConductTypeId,
                    LearningAbilityId = HighSchoolResult.LearningAbilityId,
                    GPAScore = HighSchoolResult.GPAScore
                });
            }
            else
            {
                context.HighSchoolResults.Where(x => x.StudentId == Student.Id && x.Id == HighSchoolResult.Id && !x.DelFlag).Update(x => new Database.Schema.Entity.HighSchoolResult
                {
                    HightSchoolYearId = HighSchoolResult.HightSchoolYearId,
                    ConductTypeId = HighSchoolResult.ConductTypeId,
                    LearningAbilityId = HighSchoolResult.LearningAbilityId,
                    GPAScore = HighSchoolResult.GPAScore
                });
            }
            context.SaveChanges();
        }

        public bool DeletionObject(DeletionObject deletionObject, string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var Student = context.Students.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag);
            bool result = false;
            switch (deletionObject.ObjectType)
            {
                case 0:
                    {
                        var achievement = context.Achievements.FirstOrDefault(x => x.Id == deletionObject.Id && !x.DelFlag);
                        if (achievement != null)
                        {
                            achievement.DelFlag = true;
                            result = true;
                        }
                        break;
                    }
                case 1:
                    {
                        var familyMembers = context.FamilyMembers.FirstOrDefault(x => x.Id == deletionObject.Id && !x.DelFlag);
                        if (familyMembers != null)
                        {
                            familyMembers.DelFlag = true;
                            familyMembers.ContactInfo.DelFlag = true;
                            familyMembers.PersonalInfo.DelFlag = true;
                            result = true;
                        }
                        break;
                    }
                case 2:
                    {
                        var highSchoolResult = context.HighSchoolResults.FirstOrDefault(x => x.Id == deletionObject.Id && !x.DelFlag);
                        if (highSchoolResult != null)
                        {
                            highSchoolResult.DelFlag = true;
                            result = true;
                        }
                        break;
                    }
            }

            context.SaveChanges();
            return result;
        }

        public void UpdateProfile(Profile profile, string token)
        {
            int id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var student = context.Students.FirstOrDefault(x => x.UserInfoId == id && !x.DelFlag);
            var userInfo = context.UserInfoes.FirstOrDefault(x => x.Id == id);

            student.IdentificationNumber = profile.IdentificationNumber;
            userInfo.IdentityInfo.IdentityNumber = profile.IdentityNumber;
            userInfo.LastName = profile.LastName;
            userInfo.FirstName = profile.FirstName;
            userInfo.Avatar = profile.Avatar;
            student.CircumstanceTypeId = profile.CircumstanceTypeId;

            userInfo.IdentityInfo.DateOfIssue = Convert.ToDateTime(profile.PersonalInfo.DateOfIssue);
            userInfo.IdentityInfo.PlaceOfIssue = profile.PersonalInfo.PlaceOfIssue;
            userInfo.BirthInfo.DateOfBirth = Convert.ToDateTime(profile.PersonalInfo.DateOfBirth);
            userInfo.BirthInfo.PlaceOfBirth = profile.PersonalInfo.PlaceOfBirth;
            userInfo.BirthInfo.Sex = profile.PersonalInfo.Sex;
            userInfo.ContactInfo.PhoneNumber = profile.PersonalInfo.PhoneNumber;
            userInfo.ContactInfo.Email = profile.PersonalInfo.Email;
            userInfo.ContactInfo.Address = profile.PersonalInfo.Address;
            student.PersonalInfo.EthnicId = profile.PersonalInfo.EthnicId;
            student.PersonalInfo.ReligionId = profile.PersonalInfo.ReligionId;
            student.PersonalInfo.NationalityId = profile.PersonalInfo.NationalityId;
            student.PersonalInfo.PermanentResidence = profile.PersonalInfo.PermanentResidence;

            student.Class.Name = profile.UniversityInfo.ClassName;
            student.Class.Department.Name = profile.UniversityInfo.DepartmentName;
            student.Class.Department.Faculty.Name = profile.UniversityInfo.FacultyName;
            student.Class.Program.Name = profile.UniversityInfo.ProgramName;
            student.EnrollmentArea.Name = profile.UniversityInfo.EnrollmentAreaName;
            student.ElectionType.Name = profile.UniversityInfo.ElectionName;

            student.HightSchoolName = profile.HightSchoolInfo.HightSchoolName;
            if (student.YouthGroupInfoId != null)
            {
                student.YouthGroupInfo.DateOfJoiningYouthGroup = Convert.ToDateTime(profile.HightSchoolInfo.YouthGroupInfo.DateOfJoiningYouthGroup);
                student.YouthGroupInfo.PlaceOfJoinYouthGroup = profile.HightSchoolInfo.YouthGroupInfo.PlaceOfJoinYouthGroup;
                student.YouthGroupInfo.HavingBooksOfYouthGroup = profile.HightSchoolInfo.YouthGroupInfo.HavingBooksOfYouthGroup;
                student.YouthGroupInfo.HavingCardsOfYouthGroup = profile.HightSchoolInfo.YouthGroupInfo.HavingCardsOfYouthGroup;
            }
            context.SaveChanges();
        }

       

    }
}