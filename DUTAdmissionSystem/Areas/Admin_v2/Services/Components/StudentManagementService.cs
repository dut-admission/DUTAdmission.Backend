using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.Components
{
    public class StudentManagementService : IStudentManagementService
    {
        private DataContext context = new DataContext();

        public Students GetListStudents(StudentConditionSearch conditionSearch)
        {
            if (conditionSearch == null)
            {
                conditionSearch = new StudentConditionSearch();
            }

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(context.Students.Count(x => !x.DelFlag &&
                //Search tên hoặc cmnd
                (conditionSearch.Keyword == "" ||
                (conditionSearch.Keyword != "" && ((x.UserInfo.LastName + " " + x.UserInfo.FirstName).Contains(conditionSearch.Keyword)
                || x.UserInfo.IdentityNumber.Contains(conditionSearch.Keyword) || x.IdentificationNumber.Contains(conditionSearch.Keyword))))
                 //Search lớp
                 && (conditionSearch.ClassId == 0 ||
                (conditionSearch.ClassId != 0 && (x.ClassId == conditionSearch.ClassId)))
                 && (conditionSearch.Status == null ||
                (conditionSearch.Status != null && (x.IsAdmitted == conditionSearch.Status))))
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            var students = new Students();
            students.TuitionTypes = context.TuitionTypes.Where(x => !x.DelFlag).Select(x => new TuitionType
            {
                Id = x.Id,
                Name = x.Name,
                Money = x.Money,
                Description = x.Description
            }).ToList();
            double fee = students.TuitionTypes.Sum(x => x.Money);
            students.StudentResponses= context.Students.Where(x => !x.DelFlag &&
                //Search tên hoặc cmnd
                (conditionSearch.Keyword == null ||
                (conditionSearch.Keyword != null && ((x.UserInfo.LastName + " " + x.UserInfo.FirstName).Contains(conditionSearch.Keyword)
                || x.UserInfo.IdentityNumber.Contains(conditionSearch.Keyword) || x.IdentificationNumber.Contains(conditionSearch.Keyword))))
                 //Search lớp
                 && (conditionSearch.ClassId == 0 ||
                (conditionSearch.ClassId != 0 && (x.ClassId == conditionSearch.ClassId)))
                 //Search ngành
                 && (conditionSearch.Status == null ||
                (conditionSearch.Status != null && (x.IsAdmitted == conditionSearch.Status)))).OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.PageSize)
                .Take(paging.PageSize).Select(x => new StudentResponse
                {
                    Id = x.Id,

                    FirstName = x.UserInfo.FirstName,

                    LastName = x.UserInfo.LastName,

                    Sex = x.UserInfo.Sex,

                    DateOfBirth = x.UserInfo.DateOfBirth,

                    PlaceOfBirth = x.UserInfo.PlaceOfBirth,

                    NationalityId = x.UserInfo.NationalityId,

                    ReligionId = x.UserInfo.ReligionId,

                    EthnicId = x.UserInfo.EthnicId,

                    IdentityNumber = x.UserInfo.IdentityNumber,

                    DateOfIssue = x.UserInfo.DateOfIssue,

                    PlaceOfIssue = x.UserInfo.PlaceOfIssue,

                    CircumstanceTypeId = x.CircumstanceTypeId,

                    PermanentResidence = x.UserInfo.PermanentResidence,

                    Address = x.UserInfo.Address,

                    PhoneNumber = x.UserInfo.PhoneNumber,

                    Email = x.UserInfo.Email,

                    HighSchoolName = x.HighSchoolName,

                    ClassName = x.Class.Name,
                    DepartmentName = x.Class.Department.Name,
                    ProgramName = x.Class.Department.Program.Name,
                    FacultyName = x.Class.Department.Faculty.Name,
                    ElectionName = x.ElectionType.Name,
                    EnrollmentAreaName = x.EnrollmentArea.Name,

                    IsJoinYouthGroup = x.IsJoinYouthGroup,

                    DateOfJoiningYouthGroup = x.DateOfJoiningYouthGroup,

                    PlaceOfJoinYouthGroup = x.PlaceOfJoinYouthGroup,

                    HavingBooksOfYouthGroup = x.HavingBooksOfYouthGroup,
                    HavingCardsOfYouthGroup = x.HavingCardsOfYouthGroup,
                    IsAdmitted = x.IsAdmitted,
                    IsPaid = x.IsPaid,
                    ElectionType = x.ElectionTypeId,
                    FamilyMembers = x.FamilyMembers.Where(y => !y.DelFlag).Select(y => new FamilyMember()
                    {
                        Id = y.Id,
                        FirstName = y.UserInfo.FirstName,
                        LastName = y.UserInfo.LastName,
                        Address = y.UserInfo.Address,
                        CareerTypeId = y.CareerTypeId,
                        RelationId = y.RelationId,
                        RelationName = y.RelationType.Name,
                        CareerTypeName = y.CareerType.Name,
                        Email = y.UserInfo.Email,
                        EthnicId = y.UserInfo.EthnicId,
                        EthnicName = y.UserInfo.Ethnic.Name,
                        NationalityId = y.UserInfo.NationalityId,
                        NationalityName = y.UserInfo.Nationality.Name,
                        PhoneNumber = y.UserInfo.PhoneNumber,
                        ReligionId = y.UserInfo.ReligionId,
                        ReligionName = y.UserInfo.Religion.Name,
                        YearOfBirth = y.UserInfo.DateOfBirth.Year
                    }
               ).ToList(),
                    HighSchoolResults = x.HighSchoolResults.Where(y => !x.DelFlag).Select(y => new HighSchoolResult()
                    {
                        Id = y.Id,
                        ConductTypeId = y.ConductTypeId,
                        GPAScore = y.GPAScore,
                        HighSchoolYearId = y.HighSchoolYearId,
                        LearningAbilityId = y.LearningAbilityId,
                        ConductTypeName = y.ConductType.Level,
                        HighSchoolYear = y.HighSchoolYear.Year,
                        LearningAbilityName = y.LearningAbility.Level
                    }
               ).ToList(),
                    Achievements = x.Achievements.Where(y => !x.DelFlag).Select(y => new Achievement()
                    {
                        Id = y.Id,
                        AchievementLevelId = y.AchievementLevelId,
                        AchievementLevelName = y.AchievementLevel.Name,
                        AchievementPrizeId = y.AchievementPrizeId,
                        AchievementPrizeName = y.AchievementPrize.Name,
                        AchievementTypeId = y.AchievementTypeId,
                        AchievementTypeName = y.AchievementType.Name,
                        Description = y.Description
                    }
               ).ToList(),
                    Documents = x.Documents.Where(y => !y.DelFlag).Select(y => new Document
                    {
                        Id = y.Id,
                        Name = y.DocumentType.Name,
                        IsSubmitted = y.IsSubmitted
                    }).ToList(),
                    TotalOfFee = x.Class.Department.Program.Fees + fee,
                    TuitionFee = x.Class.Department.Program.Fees,

                    


                }).ToList();
            return students;

        }
    }
}