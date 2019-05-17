using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class AdmissionNewsManagerService: IAdmissionNewsManagerService
    {
        private readonly DataContext context = new DataContext();

        public List<AdmissionsNewsManagerResponseDto> GetAdmissionNewsList(AdmissionNewsManagerConditionSearch conditionSearch)
        {
            // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
            if (conditionSearch == null)
            {
                conditionSearch = new AdmissionNewsManagerConditionSearch();
            }

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(context.AdmissionNews.Count(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfNews = context.AdmissionNews.Where(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                .Take(paging.NumberOfRecord).Select(x => new AdmissionsNewsManagerResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Summary = x.Summary,
                    Content = x.Content
                }).ToList();
            return listOfNews == null ? null : listOfNews;
        }

    }
}