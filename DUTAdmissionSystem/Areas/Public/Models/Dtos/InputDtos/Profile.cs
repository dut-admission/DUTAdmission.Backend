using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class Profile
    {
    }

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
        public int GPAScore { get; set; }

    }
}