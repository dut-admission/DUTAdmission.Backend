using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using System.Linq;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class StudentTuitionService : IStudentTuitionService
    {
        private DataContext context = new DataContext();

        public TuitionDetail GetTuitionDetail(string token)
        {
            int id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var classOfStudent = context.Students.FirstOrDefault(x => x.UserInfoId == id && !x.DelFlag).Class;
            TuitionDetail tuitionDetail = new TuitionDetail();
            tuitionDetail.TuitionTypes = context.TuitionTypes.Where(x => !x.DelFlag).Select(x => new TuitionType
            {
                Id = x.Id,
                Name = x.Name,
                Money = x.Money,
                Description = x.Description,
                SchoolYear = x.SchoolYear
            }).ToList();

            tuitionDetail.TuitionFee = classOfStudent.Department.Program.Fees;
            tuitionDetail.TotalOfFee = tuitionDetail.TuitionFee;
            foreach (TuitionType tuitionType in tuitionDetail.TuitionTypes)
            {
                tuitionDetail.TotalOfFee += tuitionType.Money;
            }
            return tuitionDetail;
        }

        public Profile GetProfile(string token)
        {
            int id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var Profile = new Profile();
            Profile = context.UserInfoes.Where(x => x.Id == id && !x.DelFlag).Select(x => new Profile
            {
                Id = x.Id,

                FirstName = x.FirstName,

                LastName = x.LastName,

                Sex = x.Sex,

                DateOfBirth = x.DateOfBirth,

                PlaceOfBirth = x.PlaceOfBirth,

                NationalityId = x.NationalityId,

                ReligionId = x.ReligionId,

                EthnicId = x.EthnicId,

                Identitynumber = x.IdentityNumber,

                DateOfIssue = x.DateOfIssue,

                PlaceOfIssue = x.PlaceOfIssue,

                CircumstaneTypeId = x.Students.FirstOrDefault(y => !y.DelFlag).CircumstanceTypeId,

                PermanentResidence = x.PermanentResidence,

                Address = x.Address,

                PhoneNumber = x.PhoneNumber,

                Email = x.Email,

                HighSchoolName = x.Students.FirstOrDefault(y => !y.DelFlag).HighSchoolName,

                //IsJoinYouthGroup = x.Students.FirstOrDefault(y => !y.DelFlag).Is,

                DateOfJoiningYouthGroup = x.Students.FirstOrDefault(y => !y.DelFlag).DateOfJoiningYouthGroup,

                PlaceOfJoinYouthGroup = x.Students.FirstOrDefault(y => !y.DelFlag).PlaceOfJoinYouthGroup,

                HavingBooksOfYouthGroup = x.Students.FirstOrDefault(y => !y.DelFlag).HavingBooksOfYouthGroup,
                HavingCardsOfYouthGroup = x.Students.FirstOrDefault(y => !y.DelFlag).HavingCardsOfYouthGroup

            }).FirstOrDefault();

            return Profile;
        }
    }
}