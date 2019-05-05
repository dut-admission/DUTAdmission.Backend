using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using System.Collections.Generic;


namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions
{
    public interface ISlideService
    {
        List<SlideResponseDto> GetSlide(SlideConditionSearch conditionSearch);

        SlideResponseDto GetSlideById(int id);
    }
}
