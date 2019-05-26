using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class TuitionManagementService
    {
        private readonly DataContext context = new DataContext();

        public List<TuitionResponseDto> GetAdmissionNewsList(TuitionConditionSearch conditionSearch)
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
                    //IsPaid =,
                    // =,
                }).ToList();
            return listOfTuition ;
        }
    }
}