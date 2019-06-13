using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class Profile
    {
        public string IdentificationNumber { get; set; }

        public string IdentityNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Avatar { get; set; }
        public int CircumstanceTypeId { get; set; }

        public PersonalInfo PersonalInfo { get; set; }
        public UniversityInfo UniversityInfo { get; set; }
        public HightSchoolInfo HightSchoolInfo { get; set; }


    }

    public class PersonalInfo
    {
        public string DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public bool Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int EthnicId { get; set; }
        public int ReligionId { get; set; }
        public int NationalityId { get; set; }
        public string PermanentResidence { get; set; }

    }

    public class UniversityInfo
    {
        public string ClassName { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyName { get; set; }
        public string ProgramName { get; set; }
        public string EnrollmentAreaName { get; set; }
        public string ElectionName { get; set; }
    }

    

    public class HightSchoolInfo {
        public string HightSchoolName { get; set; }
        public YouthGroupInfo YouthGroupInfo { get; set; }
    }

    public class YouthGroupInfo
    {
        public string DateOfJoiningYouthGroup { get; set; }
        public string PlaceOfJoinYouthGroup { get; set; }
        public bool HavingBooksOfYouthGroup { get; set; }
        public bool HavingCardsOfYouthGroup { get; set; }
    }

    

  


    //-----------------------------------------------------------------------

    public class Achievement
    {
        public int Id { get; set; }
        public int AchievementTypeId { get; set; }
        public int AchievementLevelId { get; set; }
        public int AchievementPrizeId { get; set; }
        public string Description { get; set; }
    }

    public class FamilyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RelationId { get; set; }
        public int YearOfBirth { get; set; }
        public int CareerTypeId { get; set; }
        public int EthnicId { get; set; }
        public int ReligionId { get; set; }
        public int NationalityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class HighSchoolResult
    {
        public int Id { get; set; }
        public int HightSchoolYearId { get; set; }
        public int ConductTypeId { get; set; }
        public int LearningAbilityId { get; set; }
        public double GPAScore { get; set; }

    }

    public class DeletionObject
    {
        public int Id { get; set; }
        public int ObjectType { get; set; }
    }

   
}