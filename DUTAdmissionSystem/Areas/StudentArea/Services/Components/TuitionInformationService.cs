using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class TuitionInformationService : ITuitionInformationService
    {
        private DataContext context = new DataContext();
        public TuitionInformation GetTuitionInformation(int userId)
        {
            var tuitionInfor = new TuitionInformation();
            var classOfStudent = context.Students.FirstOrDefault(x => x.UserInfoId == userId && !x.DelFlag).Class;
            tuitionInfor.TuitionTypes = context.TuitionTypes.Where(x => !x.DelFlag).Select(x => new TuitionType
            {
                Id = x.Id,
                Name = x.Name,
                Money = x.Money,
                Description = x.Description
            }).ToList();
            tuitionInfor.TuitionFee = classOfStudent.Department.Program.Fees;
            tuitionInfor.TotalOfFee = tuitionInfor.TuitionTypes.Sum(x => x.Money) + tuitionInfor.TuitionFee;
            return tuitionInfor;
        }
    }
}