using DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.StudentArea.Models.Services.Abstractions
{
    public interface IStudentTuitionService
    {
        TuitionDetail_2 GetTuitionDetail(string token);
    }
}
