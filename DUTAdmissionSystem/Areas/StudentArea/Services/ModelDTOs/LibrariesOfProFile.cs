using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs
{
    public class LibrariesOfProFile
    {
        public List<Nationality> NationalityList { get; set; }

        public List<Religion> ReligionList { get; set; }

        public List<Ethnic> EthnicList { get; set; }

        public List<Program> ProgramList { get; set; }

        public List<Faculty> FacultyList { get; set; }

        public List<Department> DepartmentList { get; set; }

        public List<ElectionType> ElectionTypeList { get; set; }

        public List<EnrollmentArea> EnrollmentAreaList { get; set; }

        public List<CircumstanceType> CircumstanceTypeList { get; set; }

        public List<HightSchoolYear> HightSchoolYearList { get; set; }

        public List<ConductType> ConductTypeList { get; set; }

        public List<LearningAbility> LearningAbilityList { get; set; }

        public List<CareerType> CareerTypeList { get; set; }

        public List<RelationType> RelationTypeList { get; set; }

        public List<TalentType> TalentTypeList { get; set; }

        public List<DocumentType> DocumentTypeList { get; set; }

        public List<InsuranceDuration> InsuranceDurationList { get; set; }

        public List<InsuranceType> InsuranceTypeList { get; set; }

        public List<AchievementPrize> AchievementPrizeList { get; set; }

        public List<AchievementLevel> AchievementLevelList { get; set; }

        public List<AchievementType> AchievementTypeList { get; set; }

        public List<Subject> SubjectList { get; set; }

        public List<PositionType> PositionTypeList { get; set; }

        public List<Class> Classes { get; set; }

        public List<TuitionType> TuitionTypes { get; set; }
    }

    public class Class
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class Nationality
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Religion
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class Ethnic
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class Program
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Fees { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Faculty Faculty { get; set; }
    }

    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ElectionType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class EnrollmentArea
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double BonusingPoint { get; set; }
    }

    public class CircumstanceType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class HightSchoolYear
    {
        public int Id { get; set; }

        public int Year { get; set; }
    }

    public class ConductType
    {
        public int Id { get; set; }

        public string Level { get; set; }
    }

    public class LearningAbility
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public double StartingPoint { get; set; }


        public double EndingPoint { get; set; }
    }

    public class CareerType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class RelationType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class TalentType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class DocumentType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class InsuranceDuration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Fees { get; set; }
    }

    public class InsuranceType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public InsuranceDuration InsuranceDuration { get; set; }
    }

    public class AchievementPrize
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class AchievementLevel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class AchievementType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class PositionType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}