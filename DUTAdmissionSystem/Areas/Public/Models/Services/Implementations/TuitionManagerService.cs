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
    public class TuitionManagerService : ITuitionManagerService
    {
        private DataContext context = new DataContext();
        public TuitionDetail GetTuitionDetail(string token)
        {
            int id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var classOfStudent = context.Students.FirstOrDefault(x => x.UserInfoId == id && !x.DelFlag).Class;
            TuitionDetail tuitionDetail = new TuitionDetail();
            tuitionDetail.TuitionTypes = context.TuitionTypes.Where(x => !x.DelFlag).Select(x => new TuitionType
            {
                Id = x.Id,
                Name =x.Name,
                Money =x.Money,
                Description =x.Description
            }).ToList();

            tuitionDetail.TuitionFee = classOfStudent.Program.Fees;
            tuitionDetail.TotalOfFee = tuitionDetail.TuitionFee;
            foreach(TuitionType tuitionType in tuitionDetail.TuitionTypes)
            {
                tuitionDetail.TotalOfFee += tuitionType.Money;
            }
            return tuitionDetail;
        }
    }
}