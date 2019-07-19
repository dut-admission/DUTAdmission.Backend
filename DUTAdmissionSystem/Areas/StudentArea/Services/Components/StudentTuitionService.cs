using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using System.Linq;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public class StudentTuitionService : IStudentTuitionService
    {
        private DataContext context = new DataContext();

        public TuitionDetail GetTuitionDetail(int id)
        {
            var classOfStudent = context.Students.FirstOrDefault(x => x.UserInfoId == id && !x.DelFlag).Class;
            TuitionDetail tuitionDetail = new TuitionDetail();
            tuitionDetail.TuitionTypes = context.TuitionTypes.Where(x => !x.DelFlag).Select(x => new TuitionType
            {
                Id = x.Id,
                Name = x.Name,
                Money = x.Money,
                Description = x.Description,
                SchoolYear = x.SchoolYear
            }).ToList();

            tuitionDetail.TuitionFee = classOfStudent.Department.Program.Fees;
            tuitionDetail.TotalOfFee = tuitionDetail.TuitionFee;
            foreach (TuitionType tuitionType in tuitionDetail.TuitionTypes)
            {
                tuitionDetail.TotalOfFee += tuitionType.Money;
            }
            return tuitionDetail;
        }
    }
}