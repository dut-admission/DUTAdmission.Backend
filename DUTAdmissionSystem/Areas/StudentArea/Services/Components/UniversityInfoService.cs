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

        public List<UniversityInfo> GetUniversityInfo()
        {
            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfUniversityInfo = db.UniversityInfoes.Where(x => !x.DelFlag)
                .OrderBy(x => x.Id).Select(x => new UniversityInfo
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