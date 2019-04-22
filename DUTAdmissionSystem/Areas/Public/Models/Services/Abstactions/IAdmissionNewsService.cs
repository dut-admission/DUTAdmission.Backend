using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using System.Collections.Generic;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstactions
{
    public interface IAdmissionNewsService
    {
        List<AdmissionNewsResponseDto> GetAdmissionNews(AdmissionNewsConditionSearch conditionSearch);

        AdmissionNewsResponseDto GetAdmissionNewsById(int id);
    }
}