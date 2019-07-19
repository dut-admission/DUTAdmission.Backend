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
        
        public Profile GetProfile(int id)
        {
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

        public string UpdateAvatar(Avatar avatar, int id, string host)
        {
            int idStudent = context.Students.FirstOrDefault(x => x.UserInfoId == id && !x.DelFlag).Id;
            string url = FunctionCommon.SaveFileImager(avatar.File, id, avatar.Name);
            string urlFile = context.Accounts.FirstOrDefault(x => x.UserInfoId == id  && !x.DelFlag).Avatar;
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
            userInfo.IdentityNumber = profile.Identitynumber;
            userInfo.DateOfIssue = profile.DateOfIssue;
            userInfo.PlaceOfIssue = profile.PlaceOfIssue;
            userInfo.Students.FirstOrDefault(y=>!y.DelFlag).CircumstanceTypeId = profile.CircumstaneTypeId;
            userInfo.PermanentResidence = profile.PermanentResidence;
            userInfo.Address = profile.Address;
            userInfo.PhoneNumber = profile.PhoneNumber;
            userInfo.Email = profile.Email;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).HighSchoolName = profile.HighSchoolName;
            //userInfo.Students.FirstOrDefault(y => !y.DelFlag).IsJoinYouthGroup = profile.IsJoinYouthGroup;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).DateOfJoiningYouthGroup = profile.DateOfJoiningYouthGroup;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).PlaceOfJoinYouthGroup = profile.PlaceOfJoinYouthGroup;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).HavingBooksOfYouthGroup = profile.HavingBooksOfYouthGroup;
            userInfo.Students.FirstOrDefault(y => !y.DelFlag).HavingCardsOfYouthGroup = profile.HavingCardsOfYouthGroup;

            context.SaveChanges();

            return profile;
        }

    }
}