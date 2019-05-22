using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class StudentManagementService : IStudentManagementService
    {
        private readonly DataContext db = new DataContext();

        public StudentResponseDto GetListStudents(StudentConditionSearch conditionSearch)
        {
            if (conditionSearch == null)
            {
                conditionSearch = new StudentConditionSearch();
            }
            var ListClassId = conditionSearch.ProgramId == 0 ? new List<int>() : GetClassIdByProgramId(conditionSearch.ProgramId);

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(db.Students.Include(x => x.UserInfo).Include(d => d.Class).Count(x => !x.DelFlag &&
                //Search tên hoặc cmnd
                (conditionSearch.Keyword == null ||
                (conditionSearch.Keyword != null && (x.UserInfo.FirstName.Contains(conditionSearch.Keyword) 
                || x.UserInfo.LastName.Contains(conditionSearch.Keyword) || x.IdentificationNumber.Contains(conditionSearch.Keyword))))
                 //Search lớp
                 && (conditionSearch.ClassId == 0 ||
                (conditionSearch.ClassId != 0 && (x.ClassId == conditionSearch.ClassId)))
                 //Search ngành
                 && (conditionSearch.DepartmentId == 0 ||
                (conditionSearch.DepartmentId != 0 && (x.Class.DepartmentId == conditionSearch.DepartmentId)))

                 //search chương trình
                 && (conditionSearch.ProgramId == 0 ||
                (conditionSearch.ProgramId != 0 && ListClassId.Contains(x.ClassId)))
                )
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfstudent = db.Students.Include(x => x.UserInfo).Include(d => d.Class).Where(x => !x.DelFlag &&
                (conditionSearch.Keyword == null ||
                (conditionSearch.Keyword != null && (x.UserInfo.FirstName.Contains(conditionSearch.Keyword)
                || x.UserInfo.LastName.Contains(conditionSearch.Keyword) || x.IdentificationNumber.Contains(conditionSearch.Keyword)))) &&
                (conditionSearch.ClassId == 0 ||
                (conditionSearch.ClassId != 0 && (x.ClassId == conditionSearch.ClassId))) &&
                (conditionSearch.DepartmentId == 0 ||
                (conditionSearch.DepartmentId != 0 && (x.Class.DepartmentId == conditionSearch.DepartmentId))) &&
                (conditionSearch.ProgramId == 0 ||
                (conditionSearch.ProgramId != 0 && ListClassId.Contains(x.ClassId)))).ToList()
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                .Take(paging.NumberOfRecord)
                .Select(x => new StudentDto(x, GetBirthInfoById(x.UserInfo.BirthInfoId), GetContactInfoById(x.UserInfo.ContactId), GetDepartmentById(x.Class.DepartmentId)))
                .ToList();


            return new StudentResponseDto(listOfstudent ?? null, GetListClasses(), GetListDepartments(), GetListPrograms());
        }

        private List<ClassDto> GetListClasses()
        {
            return db.Classes.Where(x => !x.DelFlag).ToList()
                .Select(x => new ClassDto(x)).ToList();
        }

        private List<DepartmentDto> GetListDepartments()
        {
            return db.Departments.Where(x => !x.DelFlag).ToList()
                .Select(x => new DepartmentDto(x)).ToList();
        }

        private List<ProgramDto> GetListPrograms()
        {
            return db.Programs.Where(x => !x.DelFlag).ToList()
                .Select(x => new ProgramDto(x)).ToList();
        }

        private List<int> GetClassIdByProgramId(int programId)
        {
            var list = db.Classes.Include(d => d.Department).Where(x => !x.DelFlag && x.Department.ProgramId == programId).ToList()
                .Select(x => x.Id).ToList();
            return list ?? new List<int>();
        }

        private BirthInfo GetBirthInfoById(int id)
        {
            return db.BirthInfoes.FirstOrDefault(x => !x.DelFlag && x.Id == id);
        }

        private ContactInfo GetContactInfoById(int id)
        {
            return db.ContactInfoes.FirstOrDefault(x => !x.DelFlag && x.Id == id);
        }

        private Department GetDepartmentById(int id)
        {
            return db.Departments.Include(x => x.Program).FirstOrDefault(x => !x.DelFlag && x.Id == id);
        }
    }
}