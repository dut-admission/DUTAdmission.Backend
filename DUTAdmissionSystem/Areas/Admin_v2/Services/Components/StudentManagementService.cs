using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TblAccount= DUTAdmissionSystem.NewDatabase.Schema.Entity.Account;
using TblUserInfo= DUTAdmissionSystem.NewDatabase.Schema.Entity.UserInfo;
using TblStudent= DUTAdmissionSystem.NewDatabase.Schema.Entity.Student;
using TblClass= DUTAdmissionSystem.NewDatabase.Schema.Entity.Class;
using TblDocument= DUTAdmissionSystem.NewDatabase.Schema.Entity.Document;
using EntityFramework.Extensions;

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
            students.StudentResponses = context.Students.Where(x => !x.DelFlag &&
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

                    ClassId = x.ClassId,
                    DepartmentId = x.Class.DepartmentId,
                    ProgramName = x.Class.Department.Program.Name,
                    FacultyName = x.Class.Department.Faculty.Name,
                    ElectionName = x.ElectionType.Name,
                    EnrollmentAreaId = x.EnrollmentAreaId,

                    IsJoinYouthGroup = x.IsJoinYouthGroup,

                    DateOfJoiningYouthGroup = x.DateOfJoiningYouthGroup,

                    PlaceOfJoinYouthGroup = x.PlaceOfJoinYouthGroup,

                    HavingBooksOfYouthGroup = x.HavingBooksOfYouthGroup,
                    HavingCardsOfYouthGroup = x.HavingCardsOfYouthGroup,
                    IsAdmitted = x.IsAdmitted,
                    IsPaid = x.IsPaid,
                    ElectionType = x.ElectionTypeId,
                    FamilyMembers = x.FamilyMembers.Where(y => !y.DelFlag).Select(y => new FamilyMemberManagemnet()
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
                    HighSchoolResults = x.HighSchoolResults.Where(y => !x.DelFlag).Select(y => new HighSchoolResultManagemnet()
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
                    Achievements = x.Achievements.Where(y => !x.DelFlag).Select(y => new AchievementManagemnet()
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

        public StudentResponse AddStudents(StudentResponse studentResponse)
        {

            TblUserInfo user = new TblUserInfo
            {
                FirstName = studentResponse.FirstName,
                LastName = studentResponse.LastName,
                Sex = studentResponse.Sex,
                DateOfBirth = studentResponse.DateOfBirth,
                PlaceOfBirth = studentResponse.PlaceOfBirth,
                NationalityId = studentResponse.NationalityId,
                ReligionId = studentResponse.ReligionId,
                EthnicId = studentResponse.EthnicId,
                IdentityNumber = studentResponse.IdentityNumber,
                DateOfIssue = studentResponse.DateOfIssue,
                PlaceOfIssue = studentResponse.PlaceOfIssue,

                PermanentResidence = studentResponse.PermanentResidence,
                Address = studentResponse.Address,
                PhoneNumber = studentResponse.PhoneNumber,
                Email = studentResponse.Email,

            };
            TblStudent student = new TblStudent
            {
                CircumstanceTypeId = studentResponse.CircumstanceTypeId,
                HighSchoolName = studentResponse.HighSchoolName,
                IsJoinYouthGroup = studentResponse.IsJoinYouthGroup,

                DateOfJoiningYouthGroup = studentResponse.DateOfJoiningYouthGroup,

                PlaceOfJoinYouthGroup = studentResponse.PlaceOfJoinYouthGroup,

                HavingBooksOfYouthGroup = studentResponse.HavingBooksOfYouthGroup,
                HavingCardsOfYouthGroup = studentResponse.HavingCardsOfYouthGroup,

                ClassId= studentResponse.ClassId,

                IsAdmitted = false,
                IsPaid = false,

                ElectionTypeId = studentResponse.ElectionType,
                IdentificationNumber=studentResponse.IdentificationNumber,
                EnrollmentAreaId=studentResponse.EnrollmentAreaId
            };

            foreach (var document in studentResponse.Documents)
            {
                TblDocument newDocument = new TblDocument
                {
                    IsSubmitted = false,
                    DocumentTypeId = document.DocumentTypeId,
                    StatusId=1
                };
                student.Documents.Add(newDocument);
            }



            TblAccount Account = new TblAccount
            {
                UserName = studentResponse.IdentificationNumber,
                Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(studentResponse.IdentificationNumber)),
                Avatar = "avatar",
                AccountGroupId =6
            };
            user.Accounts.Add(Account);
            user.Students.Add(student);

            context.UserInfoes.Add(user);

            

            context.SaveChanges();

            return studentResponse;
        }
        public StudentResponse EditStudents(StudentResponse studentResponse)
        {
            context.Students.Where(x => x.Id == studentResponse.Id && !x.DelFlag).Update(x => new TblStudent
            {
                CircumstanceTypeId = studentResponse.CircumstanceTypeId,
                HighSchoolName = studentResponse.HighSchoolName,
                IsJoinYouthGroup = studentResponse.IsJoinYouthGroup,

                DateOfJoiningYouthGroup = studentResponse.DateOfJoiningYouthGroup,

                PlaceOfJoinYouthGroup = studentResponse.PlaceOfJoinYouthGroup,

                HavingBooksOfYouthGroup = studentResponse.HavingBooksOfYouthGroup,
                HavingCardsOfYouthGroup = studentResponse.HavingCardsOfYouthGroup,

                ClassId = studentResponse.ClassId,

                IsAdmitted = false,
                IsPaid = false,

                ElectionTypeId = studentResponse.ElectionType,
                IdentificationNumber=studentResponse.IdentificationNumber,
                EnrollmentAreaId = studentResponse.EnrollmentAreaId
            });
            var UserId = context.Students.FirstOrDefault(x => x.Id == studentResponse.Id).UserInfoId;

            context.UserInfoes.Where(x => x.Id == UserId && !x.DelFlag).Update(x => new TblUserInfo
            {
                FirstName = studentResponse.FirstName,
                LastName = studentResponse.LastName,
                Sex = studentResponse.Sex,
                DateOfBirth = studentResponse.DateOfBirth,
                PlaceOfBirth = studentResponse.PlaceOfBirth,
                NationalityId = studentResponse.NationalityId,
                ReligionId = studentResponse.ReligionId,
                EthnicId = studentResponse.EthnicId,
                IdentityNumber = studentResponse.IdentityNumber,
                DateOfIssue = studentResponse.DateOfIssue,
                PlaceOfIssue = studentResponse.PlaceOfIssue,

                PermanentResidence = studentResponse.PermanentResidence,
                Address = studentResponse.Address,
                PhoneNumber = studentResponse.PhoneNumber,
                Email = studentResponse.Email
            });

            context.SaveChanges();
            return studentResponse;
        }
        public bool DeleteStudents(int id)
        {
            var student = context.Students.FirstOrDefault(x => x.Id == id && !x.DelFlag);
            if (student == null)
            {
                return false;
            }
            student.DelFlag = true;
            student.UserInfo.DelFlag = true;
            context.SaveChanges();
            return true;
        }
    }
}