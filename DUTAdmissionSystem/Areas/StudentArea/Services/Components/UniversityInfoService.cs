using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using System.Collections.Generic;
using System.Linq;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class UniversityInfoService : IUniversityInfoService
    {
        private readonly DataContext db = new DataContext();

        public List<UniversityInfo> GetUniversityInfo(UniversityInfoConditionSearch conditionSearch)
        {
            // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
            if (conditionSearch == null)
            {
                conditionSearch = new UniversityInfoConditionSearch();
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
                .Take(paging.PageSize).Select(x => new UniversityInfo
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