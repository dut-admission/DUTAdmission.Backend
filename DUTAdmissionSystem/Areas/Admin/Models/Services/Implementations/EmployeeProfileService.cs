using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using EntityFramework.Extensions;
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

        public void UpdateEmployeeProfile(UpdateEmployeeProfile updateEmployeeProfile,string token)
        {
            int id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var userInfo = context.UserInfoes.FirstOrDefault(x => !x.DelFlag && x.Id == id);
            if(userInfo != null)
            {
                userInfo.FirstName = updateEmployeeProfile.FirstName;
                userInfo.LastName = updateEmployeeProfile.LastName;
                userInfo.Avatar = updateEmployeeProfile.Avatar;
                userInfo.BirthInfo.DateOfBirth = updateEmployeeProfile.DateOfBirth;
                userInfo.BirthInfo.PlaceOfBirth = updateEmployeeProfile.PlaceOfBirth;
                userInfo.BirthInfo.Sex = updateEmployeeProfile.Sex;
                userInfo.ContactInfo.PhoneNumber = updateEmployeeProfile.PhoneNumber;
                userInfo.ContactInfo.Email = updateEmployeeProfile.Email;
                userInfo.ContactInfo.Address = updateEmployeeProfile.Address;
                userInfo.IdentityInfo.IdentityNumber = updateEmployeeProfile.IdentityNumber;
            }
            context.SaveChanges();


        }
    }
}