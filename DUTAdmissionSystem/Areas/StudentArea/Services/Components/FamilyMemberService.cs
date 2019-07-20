using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z.EntityFramework.Plus;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private DataContext context = new DataContext();

        public List<FamilyMember> GetFamilyMembers(int idUser)
        {
            return context.UserInfoes.FirstOrDefault(x => x.Id == idUser && !x.DelFlag)
                .Students.FirstOrDefault(x => !x.DelFlag).FamilyMembers.Where(x => !x.DelFlag).Select(x => new FamilyMember()
                {
                    Id              = x.Id,
                    Name            = x.UserInfo.FirstName + " "+ x.UserInfo.LastName,
                    Address         = x.UserInfo.Address,
                    CareerTypeId    = x.CareerTypeId,
                    CareerTypeName  = x.CareerType.Name,
                    Email           = x.UserInfo.Email,
                    EthnicId        = x.UserInfo.EthnicId,
                    EthnicName      = x.UserInfo.Ethnic.Name,
                    NationalityId   = x.UserInfo.NationalityId,
                    NationalityName = x.UserInfo.Nationality.Name,
                    PhoneNumber     = x.UserInfo.PhoneNumber,
                    ReligionId      = x.UserInfo.ReligionId,
                    ReligionName    = x.UserInfo.Religion.Name,
                    YearOfBirth     = x.UserInfo.DateOfBirth.Year
                }
               ).ToList();
        }
        public FamilyMember AddFamilyMember(FamilyMember family, int idUser)
        {
            var studentId = context.Students.FirstOrDefault(x => x.UserInfoId == idUser && !x.DelFlag).Id;
            if (context.FamilyMembers.FirstOrDefault(x => x.StudentId == studentId && x.Id == family.RelationId && !x.DelFlag) != null)
            {
                return null;
            }
            family.Id = context.HighSchoolResults.Max(x => x.Id) + 1;
            context.FamilyMembers.Add(new NewDatabase.Schema.Entity.FamilyMember
            {
                CareerTypeId    = family.CareerTypeId,
                RelationId      = family.RelationId,
                StudentId       = studentId
            });
            context.SaveChanges();
            return new FamilyMember()
            {
                Id              = family.Id,
                //Name            = family.UserInfo.FirstName + x.UserInfo.LastName,
                //Address         = family.UserInfo.Address,
                //CareerTypeId    = family.CareerTypeId,
                //CareerTypeName  = family.CareerType.Name,
                //Email           = family.UserInfo.Email,
                //EthnicId        = family.UserInfo.EthnicId,
                //EthnicName      = family.UserInfo.Ethnic.Name,
                //NationalityId   = family.UserInfo.NationalityId,
                //NationalityName = family.UserInfo.Nationality.Name,
                //PhoneNumber     = family.UserInfo.PhoneNumber,
                //RelationId      = family.RelationId,
                //RelationName    = family.RelationType.Name,
                //ReligionId      = family.UserInfo.ReligionId,
                //ReligionName    = family.UserInfo.Religion.Name,
                //YearOfBirth     = family.UserInfo.DateOfBirth.Year
            };
        }

        public FamilyMember UpdateFamilyMember(FamilyMember family, int idUser)
        {
            var familyMember = context.FamilyMembers.FirstOrDefault(x => x.Id == family.Id && !x.DelFlag);
            familyMember.CareerTypeId = family.CareerTypeId;
            familyMember.RelationId = family.RelationId;
            familyMember.UserInfo.Address = family.Address;
            familyMember.UserInfo.PhoneNumber = family.PhoneNumber;
            familyMember.UserInfo.DateOfBirth = new DateTime(family.YearOfBirth,1,1);
            familyMember.UserInfo.EthnicId = family.EthnicId;
            familyMember.UserInfo.NationalityId = family.NationalityId;
            familyMember.UserInfo.ReligionId = family.ReligionId;
            context.SaveChanges();
            return new FamilyMember()
            {
                Id              = family.Id,
                Name            = family.Name,
                Address         = family.Address,
                CareerTypeId    = family.CareerTypeId,
                CareerTypeName  = context.CareerTypes.FirstOrDefault(x => x.Id == family.CareerTypeId && !x.DelFlag).Name,
                Email           = family.Email,
                EthnicId        = family.EthnicId,
                EthnicName      = context.Ethnics.FirstOrDefault(x => x.Id == family.EthnicId && !x.DelFlag).Name,
                NationalityId   = family.NationalityId,
                NationalityName = context.Nationalities.FirstOrDefault(x => x.Id == family.NationalityId && !x.DelFlag).Name,
                PhoneNumber     = family.PhoneNumber,
                RelationId      = family.RelationId,
                RelationName    = context.RelationTypes.FirstOrDefault(x => x.Id == family.RelationId && !x.DelFlag).Name,
                ReligionId      = family.ReligionId,
                ReligionName    = context.CareerTypes.FirstOrDefault(x => x.Id == family.CareerTypeId && !x.DelFlag).Name,
                YearOfBirth     = family.YearOfBirth
            };
        }
        public bool DeleteFamilyMember(int idFamily, int idUser)
        {
            var studentId = context.Students.FirstOrDefault(x => x.UserInfoId == idUser).Id;
            var result = context.FamilyMembers.FirstOrDefault(x => x.StudentId == studentId && x.Id == idFamily && !x.DelFlag);
            if (result == null)
            {
                return false;
            }
            result.DelFlag = true;
            context.SaveChanges();
            return true;
        }
    }
}