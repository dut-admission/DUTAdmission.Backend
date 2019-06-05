using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class TuitionManagementService: ITuitionManagementService
    {
        private readonly DataContext context = new DataContext();

        public List<TuitionResponseDto> GetTuitionListResponse(TuitionConditionSearch conditionSearch)
        {
            // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
            if (conditionSearch == null)
            {
                conditionSearch = new TuitionConditionSearch();
            }

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(context.Students.Count(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.UserInfo.IdentityInfo.IdentityNumber.Contains(conditionSearch.KeySearch) || (x.UserInfo.FirstName + x.UserInfo.LastName).Contains(conditionSearch.KeySearch))) &&
                (conditionSearch.ClassId == 0 ||
                (conditionSearch.ClassId != 0 && x.ClassId == conditionSearch.ClassId)) &&
                (conditionSearch.DepartmentId == 0 ||
                (conditionSearch.DepartmentId != 0 && x.Class.DepartmentId == conditionSearch.DepartmentId)) &&
                (conditionSearch.ProgramId == 0 ||
                (conditionSearch.ProgramId != 0 && x.Class.Department.ProgramId == conditionSearch.ProgramId)
                // &&x.re)
                )))
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfTuition = context.Students.Where(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.UserInfo.IdentityInfo.IdentityNumber.Contains(conditionSearch.KeySearch) || (x.UserInfo.FirstName + x.UserInfo.LastName).Contains(conditionSearch.KeySearch))) &&
                (conditionSearch.ClassId == 0 ||
                (conditionSearch.ClassId != 0 && x.ClassId == conditionSearch.ClassId)) &&
                (conditionSearch.DepartmentId == 0 ||
                (conditionSearch.DepartmentId != 0 && x.Class.DepartmentId == conditionSearch.DepartmentId)) &&
                (conditionSearch.ProgramId == 0 ||
                (conditionSearch.ProgramId != 0 && x.Class.Department.ProgramId == conditionSearch.ProgramId)
                //&&(conditionSearch.IsPaid==null ||
                //(conditionSearch.IsPaid!=null && x.)
                // &&x.re)
                )))
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                .Take(paging.NumberOfRecord).Select(x => new TuitionResponseDto
                {
                    Id = x.Id,
                    FirstName = x.UserInfo.FirstName,
                    LastName = x.UserInfo.LastName,
                    IdentityNumber = x.UserInfo.IdentityInfo.IdentityNumber,
                    ClassId = x.ClassId,
                    ClassName = x.Class.Name,
                    TuitionFee = x.Class.Department.Program.Fees,
                    //TotalTuition = x.Class.Department.Program.Fees+x.,
                    //IsPaid =x.UserInfo.,
                    Receipt = x.UserInfo.ReceiptsForCollector.Where(y => !y.DelFlag).Select(y => new Receipt
                    {
                        Id =y.Id,
                        CollectorUserId =y.CollectorUserId,
                        PayerUserId =y.PayerUserId,
                        Money =y.Money,
                        ReceiptNumber =y.ReceiptNumber,
                        Name =y.Name,
                        Description =y.Description,
                        CollectionDate =y.CollectionDate
                    }).FirstOrDefault(),
                }).ToList();
            return listOfTuition;
        }

        public LibrariesOfTuition GetLibraries()
        {
            LibrariesOfTuition librariesOfTuition = new LibrariesOfTuition();
            librariesOfTuition.TuitionTypes = context.TuitionTypes.Where(x => !x.DelFlag).Select(x => new TuitionTypes
            {
                Id=x.Id,
                Name=x.Name,
                Description=x.Description,
                Money=x.Money
            }).FirstOrDefault();
            librariesOfTuition.Statuses = context.Statuses.Where(x => !x.DelFlag).Select(x => new Statuses
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();

            librariesOfTuition.EducationPrograms = context.Programs.Where(x => !x.DelFlag).Select(x => new EducationProgram
            {
                Id = x.Id,
                Name = x.Name,
                Departments=x.Departments.Where(y=>!y.DelFlag).Select(y=>new Departments
                {
                    Id=y.Id,
                    Name=y.Name,
                    Classes=y.Classes.Where(z=>!z.DelFlag).Select(z=>new Classes
                    {
                        Id=z.Id,
                        Name=z.Name
                    }).ToList()
                }).ToList()


            }).ToList();
            return librariesOfTuition;
        }

        public List<TuitionTypes> GetTuitionTypeList()
        {
            return context.TuitionTypes.Where(x => !x.DelFlag).Select(x=>new TuitionTypes
            {
                Id=x.Id,
                Money=x.Money,
                Name=x.Name,
                Description=x.Description
            }).ToList();
        }

        public Database.Schema.Entity.TuitionType AddTuitionType(TuitionTypeManagement tuitionTypeManagement)
        {
            var tuitionType=context.TuitionTypes.Add(new Database.Schema.Entity.TuitionType
            {
                Money = tuitionTypeManagement.Money,
                Name = tuitionTypeManagement.Name,
                Description = tuitionTypeManagement.Description
            });
            context.SaveChanges();
            return tuitionType;
        }
        public TuitionTypes EditTuitionType(TuitionTypeManagement tuitionTypeManagement, int id)
        {
            context.TuitionTypes.Where(x => x.Id == id && !x.DelFlag).Update(x => new Database.Schema.Entity.TuitionType
            {
                Money = tuitionTypeManagement.Money,
                Name = tuitionTypeManagement.Name,
                Description = tuitionTypeManagement.Description
            });
            context.SaveChanges();
            return new TuitionTypes{
                Id =id,
                Money =tuitionTypeManagement.Money,
                Name = tuitionTypeManagement.Name,
                Description = tuitionTypeManagement.Description
            };
        }
        public void DeleteTuitionType(int id)
        {
            var tuitionType = context.TuitionTypes.FirstOrDefault(x => !x.DelFlag && x.Id==id);
            if(tuitionType != null)
            {
                tuitionType.DelFlag = true;
            }
            context.SaveChanges();
            
        }
    }
}