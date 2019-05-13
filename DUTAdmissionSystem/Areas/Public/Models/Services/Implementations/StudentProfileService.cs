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

        public bool ForgetPass(ForgetPassword input)
        {

            var taikhoan=context.Accounts.FirstOrDefault(x=> (string.Compare(x.UserName,input.Input)==0 || string.Compare(x.UserInfo.ContactInfo.Email,input.Input)==0)&& !x.DelFlag) ;
            if (taikhoan == null)
            {
                return false;
            }
            else
            {
                string newPass = FunctionCommon.AutoPassword();
                SendMail.Send(taikhoan.UserInfo.ContactInfo.Email, newPass, "[DUTAdmissionSystem] Forget Password");
                taikhoan.Password= FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(newPass));
                context.SaveChanges();
                return true;
            }
            
        }
    }
}