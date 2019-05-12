using System;
using System.Collections.Generic;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos
{
    public class ProfileResponseDto
    {
        public string IdentificationNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Avatar { get; set; }
        public int CircumstanceTypeId { get; set; }

        public PersonalInfoResponseDto PersonalInfo { get; set; }
        public UniversityInfoResponseDto UniversityInfo { get; set; }
        public HightSchoolInfoResponseDto HightSchoolInfo { get; set; }
        public List<FamilyMemberResponseDto> FamilyMembers { get; set; }
    }
    /// <summary>
    /// This is some information at the 1st tab.
    /// </summary>
    public class PersonalInfoResponseDto
    {
        public DateTime? DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public DateTime DateOfBirth { get; set; }
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

    /// <summary>
    /// This is some information at the 2nd tab.
    /// </summary>
    public class UniversityInfoResponseDto
    {
        public string ClassName { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyName { get; set; }
        public string ProgramName { get; set; }
        public int EnrollmentAreaId { get; set; }
        public int ElectionId { get; set; }
        public List<UniversityExamResultResponseDto> UniversityExamResults { get; set; }
    }

    public class UniversityExamResultResponseDto
    {
        public string SubjectName { get; set; }
        public double Score { get; set; }
    }

    /// <summary>
    /// This is some information at the 3rd tab.
    /// </summary>
    public class HightSchoolInfoResponseDto
    {
        public string HightSchoolName { get; set; }
        public YouthGroupInfoResponseDto YouthGroupInfo { get; set; }
        public List<HighSchoolResultResponseInfo> HighSchoolResults { get; set; }
        public List<int> Talents { get; set; }
        public List<int> Positions { get; set; }
        public List<AchievementResponseDto> Achievements { get; set; }
        
    }
    public class HighSchoolResultResponseInfo
    {
        public int HightSchoolYearId { get; set; }
        public int ConductTypeId { get; set; }
        public int LearningAbilityId { get; set; }
        public double GPAScore { get; set; }
    }

    public class AchievementResponseDto
    {
        public int AchievementTypeId { get; set; }
        public int AchievementLevelId { get; set; }
        public int AchievementPrizeId { get; set; }
        public string Description { get; set; }
    }
    public class YouthGroupInfoResponseDto
    {
        public DateTime DateOfJoiningYouthGroup { get; set; }
        public string PlaceOfJoinYouthGroup { get; set; }
        public bool HavingBooksOfYouthGroup { get; set; }
        public bool HavingCardsOfYouthGroup { get; set; }
    }

    /// <summary>
    /// This is some information at the 4th tab.
    /// </summary>

    public class FamilyMemberResponseDto
    {
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

}