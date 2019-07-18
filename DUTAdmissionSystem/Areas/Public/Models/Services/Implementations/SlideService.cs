using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Implementations
{
    public class SlideService:ISlideService
    {
        private readonly DataContext db = new DataContext();

        public List<SlideResponseDto> GetSlide(SlideConditionSearch conditionSearch)
        {
            // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
            if (conditionSearch == null)
            {
                conditionSearch = new SlideConditionSearch();
            }

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(db.Slides.Count(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfSlide = db.Slides.Where(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.Title.Contains(conditionSearch.KeySearch)))))
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.PageSize)
                .Take(paging.PageSize).Select(x => new SlideResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    IsShowing = x.IsShowing,
                    Content = x.Content,
                    Url=x.Url,
                    CreatedAt = x.CreatedAt
                }).ToList();
            return listOfSlide ?? listOfSlide;
        }

        public SlideResponseDto GetSlideById(int id)
        {
            return new SlideResponseDto(db.Slides.FirstOrDefault(s => !s.DelFlag && s.Id == id));
        }
    }
}