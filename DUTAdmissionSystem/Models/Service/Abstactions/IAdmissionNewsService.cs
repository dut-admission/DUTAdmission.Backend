using DUTAdmissionSystem.Models.Dto.Input;
using DUTAdmissionSystem.Models.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Models.Service.Abstactions
{
    public interface IAdmissionNewsService
    {
        List<AdmissionNewsResponseDto> GetAdmissionNews(AdmissionNewsConditionSearch conditionSearch);

    }
}
