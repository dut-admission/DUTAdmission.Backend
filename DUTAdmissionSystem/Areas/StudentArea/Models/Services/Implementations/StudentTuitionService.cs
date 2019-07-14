using DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.StudentArea.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using DUTAdmissionSystem.NewDatabase.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Models.Services.Implementations
{
    public class StudentTuitionService : IStudentTuitionService
    {
        private DataContext context = new DataContext();
        public TuitionDetail_2 GetTuitionDetail(string token)
        {
            int id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            var classOfStudent = context.Students.FirstOrDefault(x => x.UserInfoId == id && !x.DelFlag).Class;
            TuitionDetail_2 tuitionDetail = new TuitionDetail_2();
            tuitionDetail.TuitionTypes = context.TuitionTypes.Where(x => !x.DelFlag).Select(x => new TuitionType_2
            {
                Id = x.Id,
                Name = x.Name,
                Money = x.Money,
                Description = x.Description,
                SchoolYear = x.SchoolYear
            }).ToList();

            tuitionDetail.TuitionFee = classOfStudent.Department.Program.Fees;
            tuitionDetail.TotalOfFee = tuitionDetail.TuitionFee;
            foreach (TuitionType_2 tuitionType in tuitionDetail.TuitionTypes)
            {
                tuitionDetail.TotalOfFee += tuitionType.Money;
            }
            return tuitionDetail;
        }
    }
}