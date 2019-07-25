using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs
{
    public class Students
    {
        public List<StudentResponse> StudentResponses { get; set; }
        public List<TuitionType> TuitionTypes { get; set; }

    }
    public class StudentResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public bool Sex { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public int NationalityId { get; set; }

        public int ReligionId { get; set; }

        public int EthnicId { get; set; }

        public string IdentityNumber { get; set; }

        public DateTime? DateOfIssue { get; set; }

        public string PlaceOfIssue { get; set; }

        public int CircumstanceTypeId { get; set; }

        public string PermanentResidence { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string HighSchoolName { get; set; }

        public bool IsJoinYouthGroup { get; set; }

        public DateTime DateOfJoiningYouthGroup { get; set; }

        public string PlaceOfJoinYouthGroup { get; set; }

        public bool HavingBooksOfYouthGroup { get; set; }

        public bool HavingCardsOfYouthGroup { get; set; }

        public int ClassId { get; set; }
        public int DepartmentId { get; set; }
        public string FacultyName { get; set; }
        public string ProgramName { get; set; }
        public int EnrollmentAreaId { get; set; }
        public string ElectionName { get; set; }

        public bool IsAdmitted { get; set; }
        public bool IsPaid { get; set; }

        public int ElectionType { get; set; }

        public List<FamilyMemberManagemnet> FamilyMembers { get; set; }
        public List<HighSchoolResultManagemnet> HighSchoolResults { get; set; }
        public List<AchievementManagemnet> Achievements { get; set; }
        public List<Document> Documents { get; set; }

        public double TuitionFee { get; set; }

        public double TotalOfFee { get; set; }

        public string IdentificationNumber { get; set; }
    }


    public class FamilyMemberManagemnet
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RelationId { get; set; }
        public string RelationName { get; set; }
        public int YearOfBirth { get; set; }
        public int CareerTypeId { get; set; }
        public string CareerTypeName { get; set; }
        public int EthnicId { get; set; }
        public string EthnicName { get; set; }
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
        public int NationalityId { get; set; }
        public string NationalityName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class HighSchoolResultManagemnet
    {
        public int Id { get; set; }
        public int HighSchoolYearId { get; set; }
        public int HighSchoolYear { get; set; }
        public int ConductTypeId { get; set; }
        public string ConductTypeName { get; set; }
        public int LearningAbilityId { get; set; }
        public string LearningAbilityName { get; set; }
        public double GPAScore { get; set; }
    }

    public class AchievementManagemnet
    {
        public int Id { get; set; }
        public int AchievementTypeId { get; set; }
        public string AchievementTypeName { get; set; }
        public int AchievementLevelId { get; set; }
        public string AchievementLevelName { get; set; }
        public int AchievementPrizeId { get; set; }
        public string AchievementPrizeName { get; set; }
        public string Description { get; set; }
    }

    public class Document
    {
        public int Id { get; set; }

        public int DocumentTypeId { get; set; }
        public string Name { get; set; }

        public bool IsSubmitted { get; set; }
    }

    

    public class TuitionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public string Description { get; set; }
    }

}