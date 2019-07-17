using DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.StudentArea.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Models.Services.Implementations
{
    public class UniversityInfo_2Service: IUniversityInfo_2Service
    {
        private readonly DataContext db = new DataContext();
        public List<UniversityInfo_2Dto> GetUniversityInfo(UniversityInfo_2ConditionSearch conditionSearch)
        {
            // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
            if (conditionSearch == null)
            {
                conditionSearch = new UniversityInfo_2ConditionSearch();
            }

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(db.UniversityInfoes.Count(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.UniversityName.Contains(conditionSearch.KeySearch))) ||
                (conditionSearch.KeySearch != null && (x.Email.Contains(conditionSearch.KeySearch)))))
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfUniversityInfo = db.UniversityInfoes.Where(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.UniversityName.Contains(conditionSearch.KeySearch))) ||
                (conditionSearch.KeySearch != null && (x.Email.Contains(conditionSearch.KeySearch)))))
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.PageSize)
                .Take(paging.PageSize).Select(x => new UniversityInfo_2Dto
                {
                    Id = x.Id,
                    UniversityName = x.UniversityName,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    Fax = x.Fax,
                    Email = x.Email,
                    Summary = x.Summary,
                    Website = x.Website,
                    CreatedAt = x.CreatedAt
                }).ToList();
            return listOfUniversityInfo ?? listOfUniversityInfo;
        }
    }
}