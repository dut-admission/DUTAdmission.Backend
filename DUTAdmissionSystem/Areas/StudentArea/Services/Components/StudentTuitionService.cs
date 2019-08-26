using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using EntityFramework.Extensions;
using System.Linq;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class StudentInforService : IStudentInforService
    {
        private DataContext context = new DataContext();

        public Profile GetProfile(int userId)
        {
            var Profile = new Profile();
            var student = context.Students.FirstOrDefault(x => !x.DelFlag & x.UserInfoId == userId);
            var universityClass = student.Class;
            var department = universityClass.Department;

            Profile = context.UserInfoes.Where(x => x.Id == userId && !x.DelFlag).Select(x => new Profile
            {
                Id = x.Id,

                Avatar = x.Accounts.FirstOrDefault().Avatar,

                FirstName = x.FirstName,

                LastName = x.LastName,

                Sex = x.Sex,

                DateOfBirth = x.DateOfBirth,

                PlaceOfBirth = x.PlaceOfBirth,

                NationalityId = x.NationalityId,

                ReligionId = x.ReligionId,

                EthnicId = x.EthnicId,

                IdentityNumber = x.IdentityNumber,

                DateOfIssue = x.DateOfIssue,

                PlaceOfIssue = x.PlaceOfIssue,

                CircumstanceTypeId = student.CircumstanceTypeId,

                PermanentResidence = x.PermanentResidence,

                Address = x.Address,

                PhoneNumber = x.PhoneNumber,

                Email = x.Email,

                HighSchoolName = student.HighSchoolName,

                ClassName = universityClass.Name,
                DepartmentName = universityClass.Department.Name,
                ProgramName = department.Program.Name,
                FacultyName = department.Faculty.Name,
                ElectionName = student.ElectionType.Name,
                EnrollmentAreaName = student.EnrollmentArea.Name,

                IsJoinYouthGroup = student.IsJoinYouthGroup,

                DateOfJoiningYouthGroup = student.DateOfJoiningYouthGroup,

                PlaceOfJoinYouthGroup = student.PlaceOfJoinYouthGroup,

                HavingBooksOfYouthGroup = student.HavingBooksOfYouthGroup,
                HavingCardsOfYouthGroup = student.HavingCardsOfYouthGroup

            }).FirstOrDefault();

            return Profile;
        }

        public string UpdateAvatar(Avatar avatar, int id, string host)
        {
            int idStudent = context.Students.FirstOrDefault(x => x.UserInfoId == id && !x.DelFlag).Id;
            string url = FunctionCommon.SaveFileImager(avatar.File, id, avatar.Name);
            string urlFile = context.Accounts.FirstOrDefault(x => x.UserInfoId == id && !x.DelFlag).Avatar;
            string strUrl = host + "/" + url;

            context.Accounts.Where(x => x.UserInfoId == id && !x.DelFlag).Update(x => new NewDatabase.Schema.Entity.Account
            {
                Avatar = strUrl
            });
            context.SaveChanges();
            FunctionCommon.DeleteFile(urlFile.Substring(host.Length, urlFile.Length - host.Length));
            return url;
        }

        public Profile SaveProfile(Profile profile, int id)
        {
            var userInfo = context.UserInfoes.FirstOrDefault(x => x.Id == profile.Id);

            userInfo.Id = profile.Id;
            userInfo.FirstName = profile.FirstName;
            userInfo.LastName = profile.LastName;
            userInfo.Sex = profile.Sex;
            userInfo.DateOfBirth = profile.DateOfBirth;
            userInfo.PlaceOfBirth = profile.PlaceOfBirth;
            userInfo.NationalityId = profile.NationalityId;
            userInfo.ReligionId = profile.ReligionId;
            userInfo.EthnicId = profile.EthnicId;
            userInfo.IdentityNumber = profile.IdentityNumber;
            userInfo.DateOfIssue = profile.DateOfIssue;
            userInfo.PlaceOfIssue = profile.PlaceOfIssue;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).CircumstanceTypeId = profile.CircumstanceTypeId;
            userInfo.PermanentResidence = profile.PermanentResidence;
            userInfo.Address = profile.Address;
            userInfo.PhoneNumber = profile.PhoneNumber;
            userInfo.Email = profile.Email;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).HighSchoolName = profile.HighSchoolName;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).DateOfJoiningYouthGroup = profile.DateOfJoiningYouthGroup;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).PlaceOfJoinYouthGroup = profile.PlaceOfJoinYouthGroup;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).HavingBooksOfYouthGroup = profile.HavingBooksOfYouthGroup;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).HavingCardsOfYouthGroup = profile.HavingCardsOfYouthGroup;

            context.SaveChanges();

            return profile;
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

            librariesOfProFile.HightSchoolYearList = context.HighSchoolYears.Where(x => !x.DelFlag).Select(x => new HightSchoolYear
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

    }
}