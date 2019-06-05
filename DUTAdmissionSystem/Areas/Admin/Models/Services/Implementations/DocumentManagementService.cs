using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class DocumentManagementService : IDocumentManagementService
    {
        private readonly DataContext db = new DataContext();

        public DocumentResponseDto GetListDocuments(DocumentConditionSearch conditionSearch)
        {
            if (conditionSearch == null)
            {
                conditionSearch = new DocumentConditionSearch();
            }
            var ListClassId = conditionSearch.ProgramId == 0 ? new List<int>() : GetClassIdByProgramId(conditionSearch.ProgramId);

            var ListStudentId = (conditionSearch.DocumentTypeId == 0 && conditionSearch.StatusId == 0) ? new List<int>() 
                : GetStudentIdByDocument(conditionSearch.DocumentTypeId, conditionSearch.StatusId);

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(db.Students.Include(x => x.UserInfo).Include(d => d.Class)
                .Count(x => !x.DelFlag &&
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
                 //Search loại và trạng thái
                 && (conditionSearch.DocumentTypeId == 0 || conditionSearch.StatusId == 0 ||
                ((conditionSearch.DocumentTypeId != 0 || conditionSearch.StatusId !=0 )
                && ListStudentId.Contains(x.Id)))
                )
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfstudent = db.Students.Include(x => x.UserInfo).Include(d => d.Class)
                .Where(x => !x.DelFlag &&
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
                 //Search loại và trạng thái
                 && (conditionSearch.DocumentTypeId == 0 || conditionSearch.StatusId == 0 ||
                ((conditionSearch.DocumentTypeId != 0 || conditionSearch.StatusId != 0)
                && ListStudentId.Contains(x.Id)))).ToList()
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                .Take(paging.NumberOfRecord)
                .Select(x => new StudentForDocumentDto(x, GetListDocumentByStudentId(x.Id)))
                .ToList();


            return new DocumentResponseDto(listOfstudent ?? null, GetListClasses(), GetListDepartments(), GetListPrograms(), GetListDocumentTypes(), GetListStatuses());
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

        private List<DocumentTypeDto> GetListDocumentTypes()
        {
            return db.DocumentTypes.Where(x => !x.DelFlag).ToList()
                .Select(x => new DocumentTypeDto(x)).ToList();
        }

        private List<StatusDto> GetListStatuses()
        {
            return db.Statuses.Where(x => !x.DelFlag).ToList()
                .Select(x => new StatusDto(x)).ToList();
        }

        private List<int> GetClassIdByProgramId(int programId)
        {
            var list = db.Classes.Include(d => d.Department).Where(x => !x.DelFlag && x.Department.ProgramId == programId).ToList()
                .Select(x => x.Id).ToList();
            return list ?? new List<int>();
        }

        private List<int> GetStudentIdByDocument(int documentTypeId, int statusId)
        {
            var list = db.Documents.Where(x => !x.DelFlag && (x.DocumentTypeId == documentTypeId || x.StatusId == statusId)).ToList()
                .Select(x => x.StudentId).ToList();
            return list ?? new List<int>();
        }

        private List<DocumentInfoDto> GetListDocumentByStudentId(int id)
        {
            var list = db.Documents.Include(d => d.DocumentType).Include(d => d.Status).Where(x => !x.DelFlag && x.StudentId == id).ToList()
                .Select(x => new DocumentInfoDto(x)).ToList();
            return list ?? new List<DocumentInfoDto>();
        }

        public List<DocumentTypeDto> GetDocumentTypeList()
        {
            return db.DocumentTypes.Where(x => !x.DelFlag).Select(x => new DocumentTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }

        public Database.Schema.Entity.DocumentType AddDocumentType(DocumentTypeManagement documentTypeManagement)
        {
            var documentType = db.DocumentTypes.Add(new Database.Schema.Entity.DocumentType
            {
                IsRequired = documentTypeManagement.IsRequired,
                Name = documentTypeManagement.Name,
                Description = documentTypeManagement.Description
            });
            db.SaveChanges();
            return documentType;
        }
        public DocumentTypeDto EditDocumentType(DocumentTypeManagement documentTypeManagement, int id)
        {
            db.DocumentTypes.Where(x => x.Id == id && !x.DelFlag).Update(x => new Database.Schema.Entity.DocumentType
            {
                IsRequired = documentTypeManagement.IsRequired,
                Name = documentTypeManagement.Name,
                Description = documentTypeManagement.Description
            });
            db.SaveChanges();
            return new DocumentTypeDto
            {
                Id = id,
                IsRequired = documentTypeManagement.IsRequired,
                Name = documentTypeManagement.Name,
                Description = documentTypeManagement.Description
            };
        }
        public void DeleteDocumentType(int id)
        {
            var documentType = db.DocumentTypes.FirstOrDefault(x => !x.DelFlag && x.Id==id);
            if (documentType != null)
            {
                documentType.DelFlag = true;
            }
            db.SaveChanges();
        }
    }
}