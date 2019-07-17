using DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.StudentArea.Models.Services.Abstractions
{
    public interface IUniversityInfo_2Service
    {
        List<UniversityInfo_2Dto> GetUniversityInfo(UniversityInfo_2ConditionSearch conditionSearch);
    }
}
