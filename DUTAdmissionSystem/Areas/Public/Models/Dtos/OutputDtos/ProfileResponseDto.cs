using Newtonsoft.Json;
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
        public string EnrollmentAreaName { get; set; }
        public string ElectionName { get; set; }
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
        public int HightSchoolYear { get; set; }
        public int ConductTypeId { get; set; }
        public string ConductTypeName { get; set; }
        public int LearningAbilityId { get; set; }
        public string LearningAbilityName { get; set; }
        public double GPAScore { get; set; }
    }

    public class AchievementResponseDto
    {
        public int AchievementTypeId { get; set; }
        public string AchievementTypeName { get; set; }
        public int AchievementLevelId { get; set; }
        public string AchievementLevelName { get; set; }
        public int AchievementPrizeId { get; set; }
        public string AchievementPrizeName { get; set; }
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
        public string Name { get; set; }
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


    public class LibrariesOfProFile
    {
        [JsonProperty("nationality_list")]
        public List<Nationality> NationalityList { get; set; }

        [JsonProperty("religion_list")]
        public List<Religion> ReligionList { get; set; }

        [JsonProperty("ethnic_list")]
        public List<Ethnic> EthnicList { get; set; }

        [JsonProperty("program_list")]
        public List<Program> ProgramList { get; set; }

        [JsonProperty("faculty_list")]
        public List<Faculty> FacultyList { get; set; }

        [JsonProperty("department_list")]
        public List<Department> DepartmentList { get; set; }

        [JsonProperty("election_type_list")]
        public List<ElectionType> ElectionTypeList { get; set; }

        [JsonProperty("enrollment_area_list")]
        public List<EnrollmentArea> EnrollmentAreaList { get; set; }

        [JsonProperty("circumstance_type_list")]
        public List<CircumstanceType> CircumstanceTypeList { get; set; }

        [JsonProperty("hight_school_year_list")]
        public List<HightSchoolYear> HightSchoolYearList { get; set; }

        [JsonProperty("conduct_type_list")]
        public List<ConductType> ConductTypeList { get; set; }

        [JsonProperty("learning_ability_list")]
        public List<LearningAbility> LearningAbilityList { get; set; }

        [JsonProperty("career_type_list")]
        public List<CareerType> CareerTypeList { get; set; }

        [JsonProperty("relation_type_list")]
        public List<RelationType> RelationTypeList { get; set; }

        [JsonProperty("talent_type_list")]
        public List<TalentType> TalentTypeList { get; set; }

        [JsonProperty("document_type_list")]
        public List<DocumentType> DocumentTypeList { get; set; }

        [JsonProperty("insurance_duration_list")]
        public List<InsuranceDuration> InsuranceDurationList { get; set; }

        [JsonProperty("insurance_type_list")]
        public List<InsuranceType> InsuranceTypeList { get; set; }

        [JsonProperty("achievement_prize_list")]
        public List<AchievementPrize> AchievementPrizeList { get; set; }

        [JsonProperty("achievement_level_list")]
        public List<AchievementLevel> AchievementLevelList { get; set; }

        [JsonProperty("achievement_type_list")]
        public List<AchievementType> AchievementTypeList { get; set; }

        [JsonProperty("subject_list")]
        public List<Subject> SubjectList { get; set; }

        [JsonProperty("position_type_list")]
        public List<PositionType> PositionTypeList { get; set; }
    }

    public class Nationality
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Religion
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Ethnic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Program
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fees")]
        public double Fees { get; set; }
    }

    public class Department
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("faculty")]
        public Faculty Faculty { get; set; }
    }

    public class Faculty
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ElectionType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class EnrollmentArea
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("bonusing_point")]
        public double BonusingPoint { get; set; }
    }

    public class CircumstanceType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class HightSchoolYear
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }
    }

    public class ConductType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }
    }

    public class LearningAbility
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("starting_point")]
        public double StartingPoint { get; set; }


        [JsonProperty("ending_point")]
        public double EndingPoint { get; set; }
    }

    public class CareerType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class RelationType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class TalentType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class DocumentType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class InsuranceDuration
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fees")]
        public double Fees { get; set; }
    }

    public class InsuranceType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("insurance_duration")]
        public InsuranceDuration InsuranceDuration { get; set; }
    }

    public class AchievementPrize
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AchievementLevel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AchievementType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Subject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class PositionType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }


}