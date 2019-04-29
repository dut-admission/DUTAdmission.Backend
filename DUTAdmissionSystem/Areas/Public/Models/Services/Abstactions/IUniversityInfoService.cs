using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstactions
{
    public interface IUniversityInfoService
    {
        List<UniversityInfoDto> GetUniversityInfo(UniversityInfoConditionSearch conditionSearch);

    }
}
