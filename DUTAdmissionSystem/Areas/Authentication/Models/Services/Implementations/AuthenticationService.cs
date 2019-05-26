using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Authentication.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System.Linq;
using System.Data.Entity;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext db = new DataContext();

        public LoginResponseDto Login(LoginDto dto)
        {
            var result = new LoginResponseDto();

            dto.Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(dto.Password));

            var accountFromDb = db.Accounts.FirstOrDefault(x => x.UserName == dto.UserName && x.Password == dto.Password && !x.DelFlag);

            if (accountFromDb == null)
            {
                return null;
            }

            var isStudent = db.AccountGroups.FirstOrDefault(x => !x.DelFlag && x.Name.ToLower().Equals("student")).Id == accountFromDb.AccountGroupId;

            var accessToken = JwtAuthenticationExtensions.CreateToken(accountFromDb, isStudent);

            result.AccessToken = accessToken;

            result.FirstName = accountFromDb.UserInfo.FirstName;

            result.LastName = accountFromDb.UserInfo.LastName;

            result.Avatar = accountFromDb.UserInfo.Avatar;

            result.UserName = accountFromDb.UserName;

            result.IsStudent = isStudent;

            return result;
        }

        public bool ForgetPass(ForgetPassword input)
        {

            var taikhoan = db.Accounts.FirstOrDefault(x => string.Compare(x.UserName, input.Username) == 0 && string.Compare(x.UserInfo.ContactInfo.Email, input.Email) == 0 && !x.DelFlag);
            if (taikhoan == null)
            {
                return false;
            }
            else
            {
                string newPass = FunctionCommon.AutoPassword();
                SendMail.Send(taikhoan.UserInfo.ContactInfo.Email, newPass, "[DUTAdmissionSystem] Forget Password");
                taikhoan.Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(newPass));
                db.SaveChanges();
                return true;
            }

        }
    }

    
}