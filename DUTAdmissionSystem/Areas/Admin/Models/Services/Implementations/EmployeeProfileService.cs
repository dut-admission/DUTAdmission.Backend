using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class EmployeeProfileService: IEmployeeProfileService
    {
        private readonly DataContext context = new DataContext();
        public EmployeeProfile GetEmployeeProfile(string token)
        {
            int id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var employeeProfile = context.UserInfoes.Where(x => !x.DelFlag && x.Id == id).Select(x => new EmployeeProfile
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Avatar = x.Avatar,
                DateOfBirth = x.BirthInfo.DateOfBirth,
                PlaceOfBirth = x.BirthInfo.PlaceOfBirth,
                Sex = x.BirthInfo.Sex,
                PhoneNumber = x.ContactInfo.PhoneNumber,
                Email = x.ContactInfo.Email,
                Address = x.ContactInfo.Address,
                IdentityNumber = x.IdentityInfo.IdentityNumber
            }).FirstOrDefault();
            var account = context.Accounts.FirstOrDefault(x => !x.DelFlag && x.UserInfoId == id);
            employeeProfile.UserName = account.UserName;
            employeeProfile.AccountGroupName = account.AccountGroup.Name;
            return employeeProfile;
        }
    }
}