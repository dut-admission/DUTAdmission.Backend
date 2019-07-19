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
                .Students.FirstOrDefault(x => !x.DelFlag).FamilyMembers.Select(x => new FamilyMember()
                {
                    Id              = x.Id,
                    Name            = x.UserInfo.FirstName + x.UserInfo.LastName,
                    Address         = x.UserInfo.Address,
                    CareerTypeId    = x.CareerTypeId,
                    CareerTypeName  = x.CareerType.Name,
                    Email           = x.UserInfo.Email,
                    EthnicId        = x.UserInfo.EthnicId,
                    EthnicName      = x.UserInfo.Ethnic.Name,
                    NationalityId   = x.UserInfo.NationalityId,
                    NationalityName = x.UserInfo.Nationality.Name,
                    PhoneNumber     = x.UserInfo.PhoneNumber,
                    RelationId      = x.RelationId,
                    RelationName    = x.RelationType.Name,
                    ReligionId      = x.UserInfo.ReligionId,
                    ReligionName    = x.UserInfo.Religion.Name,
                    YearOfBirth     = x.UserInfo.DateOfBirth.Year
                }
               ).ToList();
        }
        public FamilyMember AddFamilyMember(FamilyMember family, int idUser)
        {
            var student = context.Students.FirstOrDefault(x => x.UserInfoId == idUser && !x.DelFlag);
            context.FamilyMembers.Where(x => x.StudentId == student.Id && x.Id == family.Id && !x.DelFlag).Update(x => new NewDatabase.Schema.Entity.FamilyMember
            {
                CareerTypeId = x.CareerTypeId,
                RelationId = x.RelationId,
            });
            context.SaveChanges();
            return family;
        }

        public FamilyMember UpdateFamilyMember(FamilyMember family, int idUser)
        {
            var Student = context.Students.FirstOrDefault(x => x.UserInfoId == idUser && !x.DelFlag);
            context.FamilyMembers.Where(x => x.StudentId == Student.Id && x.Id == family.Id && !x.DelFlag).Update(x => new NewDatabase.Schema.Entity.FamilyMember
            {
                CareerTypeId = x.CareerTypeId,
                RelationId = x.RelationId,
            });
            context.SaveChanges();
            return family;
        }
        public bool DeleteFamilyMember(int idFamily, int idUser)
        {
            var student = context.Students.FirstOrDefault(x => x.UserInfoId == idUser && !x.DelFlag);
            if (student == null)
            {
                return false;
            }
            //context.FamilyMembers.Where(x => x.StudentId == student.Id && x.Id == idFamily && !x.DelFlag).Update(x => new NewDatabase.Schema.Entity.HighSchoolResult
            //{
            //    DelFlag = true
            //});
            context.SaveChanges();
            return true;
        }
    }
}