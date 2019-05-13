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

            return result;
        }
    }
}