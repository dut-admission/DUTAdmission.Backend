using DUTAdmissionSystem.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Models.Services.Abstactions
{
    public interface IAdmissionNewsService
    {
        List<AdmissionNewsResponseDto> GetAdmissionNews(AdmissionNewsConditionSearch conditionSearch);

    }
}
