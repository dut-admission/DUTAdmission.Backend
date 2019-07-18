﻿using DUTAdmissionSystem.Areas.Authentication.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using System.Linq;

namespace DUTAdmissionSystem.Areas.Authentication.Services.Components
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

            var isStudent = db.AccountGroups.FirstOrDefault(x => !x.DelFlag && x.Name.ToLower().Equals("Sinh viên")).Id == accountFromDb.AccountGroupId;

            var accessToken = JwtAuthenticationExtensions.CreateToken(accountFromDb, isStudent);

            result.AccessToken = accessToken;

            result.FirstName = accountFromDb.UserInfo.FirstName;

            result.LastName = accountFromDb.UserInfo.LastName;

            result.Avatar = accountFromDb.Avatar;

            result.UserName = accountFromDb.UserName;

            result.IsStudent = isStudent;

            return result;
        }

        public bool ForgetPass(ForgetPassword input)
        {
            var taikhoan = db.Accounts.FirstOrDefault(x => string.Compare(x.UserName, input.Username) == 0 && string.Compare(x.UserInfo.Email, input.Email) == 0 && !x.DelFlag);
            if (taikhoan == null)
            {
                return false;
            }
            else
            {
                string newPass = FunctionCommon.AutoPassword();
                SendMail.Send(taikhoan.UserInfo.Email, newPass, "[DUTAdmissionSystem] Forget Password");
                taikhoan.Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(newPass));
                db.SaveChanges();
                return true;
            }
        }
    }
}