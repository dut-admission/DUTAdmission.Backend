using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstactions;
using DUTAdmissionSystem.Database;
using System.Collections.Generic;
using System.Linq;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Implementations
{
    public class AdmissionNewsService : IAdmissionNewsService
    {
        private readonly DataContext db = new DataContext();

        public List<AdmissionNewsResponseDto> GetAdmissionNews(AdmissionNewsConditionSearch conditionSearch)
        {
            // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
            if (conditionSearch == null)
            {
                conditionSearch = new AdmissionNewsConditionSearch();
            }

            // Lấy các thông tin dùng để phân trang
            var paging = new EducationManagement.Commons.Paging(db.AdmissionNews.Count(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfNews = db.AdmissionNews.Where(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                .Take(paging.NumberOfRecord).Select(x => new AdmissionNewsResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Summary = x.Summary,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt
                }).ToList();
            return listOfNews == null ? null : listOfNews;
        }

        public AdmissionNewsResponseDto GetAdmissionNewsById(int id)
        {
            var AdmissionNews =  db.AdmissionNews.FirstOrDefault(s => !s.DelFlag && s.Id == id);
            return AdmissionNews == null ? null : new AdmissionNewsResponseDto(a);
        }
    }
}