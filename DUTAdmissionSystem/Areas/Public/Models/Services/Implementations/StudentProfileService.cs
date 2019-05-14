using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System.Linq;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Implementations
{
    public class StudentProfileService : IStudentProfileService
    {
        private DataContext context = new DataContext();
        public ProfileResponseDto GetStudentProfileByIdAccount(int id)
        {
            var account = context.Accounts.FirstOrDefault(x => x.Id == id && !x.DelFlag);
            if (account == null)
            {
                return null;
            }
            var user = account.UserInfo;
            var student = user.Students.FirstOrDefault();
            var familyMembers = student.FamilyMembers.Select(x => new FamilyMemberResponseDto()
            {
                Address = x.ContactInfo.Address,
                CareerTypeId = x.CareerTypeId,
                Email = x.ContactInfo.Email,
                EthnicId = x.PersonalInfo.EthnicId,
                NationalityId = x.PersonalInfo.NationalityId,
                PhoneNumber = x.ContactInfo.PhoneNumber,
                RelationId = x.RelationId,
                ReligionId = x.PersonalInfo.ReligionId,
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
                ElectionId = student.ElectionTypeId,
                EnrollmentAreaId = student.EnrollmentAreaId,
                UniversityExamResults = student.UniversityExamResults
                .Select(e => new UniversityExamResultResponseDto()
                {
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
                    AchievementLevelId = a.AchievementLevelId,
                    AchievementPrizeId = a.AchievementPrizeId,
                    AchievementTypeId = a.AchievementTypeId,
                    Description = a.Description
                }).ToList(),
                HighSchoolResults = student.HighSchoolResults.Select(h => new HighSchoolResultResponseInfo()
                {
                    ConductTypeId = h.ConductTypeId,
                    GPAScore = h.GPAScore,
                    HightSchoolYearId = h.HightSchoolYearId,
                    LearningAbilityId = h.LearningAbilityId
                }).ToList(),
                Positions = student.HightSchoolPositions.Select(p => p.PositionTypeId).ToList(),
                Talents = student.Talents.Select(t=>t.TalentTypeId).ToList()
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

        public bool UpdatePass(UpdatePassword updatePassword,string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;

            if(string.Compare(FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(updatePassword.OldPassword)), context.Accounts.FirstOrDefault(x=>x.UserInfoId==Id && !x.DelFlag).Password) != 0)
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

            librariesOfProFile.NationlityList = context.Nationalities.Where(x => !x.DelFlag).Select(x => new Nationlity
            {
                Id=x.Id,
                Name=x.Name
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
                Fees=x.Fees
            }).ToList();

            librariesOfProFile.FacultyList= context.Faculties.Where(x => !x.DelFlag).Select(x => new Faculty
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.DepartmentList = context.Departments.Where(x => !x.DelFlag).Select(x => new Department
            {
                Id = x.Id,
                Name = x.Name,
                Faculty = new Faculty { Id=x.Faculty.Id,Name=x.Faculty.Name}
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
                BonusingPoint=x.BonusingPoint
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

            librariesOfProFile.ConductTypeList= context.ConductTypes.Where(x => !x.DelFlag).Select(x => new ConductType
            {
                Id = x.Id,
                Level = x.Level
            }).ToList();

            librariesOfProFile.LearningAbilityList= context.LearningAbilities.Where(x => !x.DelFlag).Select(x => new LearningAbility
            {
                Id = x.Id,
                Level = x.Level,
                StartingPoint=x.StartingPoint,
                EndingPoint=x.EndingPoint
            }).ToList();

            librariesOfProFile.CareerTypeList= context.CareerTypes.Where(x => !x.DelFlag).Select(x => new CareerType
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            librariesOfProFile.RelationTypeList= context.RelationTypes.Where(x => !x.DelFlag).Select(x => new RelationType
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

            librariesOfProFile.InsuranceDurationList = context.InsuranceDurations.Where(x => !x.DelFlag).Select(x => new InsuranceDuration
            {
                Id = x.Id,
                Name = x.Name,
                Fees =x.Fees
            }).ToList();

            librariesOfProFile.InsuranceTypeList = context.InsuranceTypes.Where(x => !x.DelFlag).Select(x => new InsuranceType
            {
                Id = x.Id,
                Name = x.Name,
                InsuranceDuration = new InsuranceDuration { Id=x.InsuranceDuration.Id, Name=x.InsuranceDuration.Name, Fees=x.InsuranceDuration.Fees}
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


    }
}