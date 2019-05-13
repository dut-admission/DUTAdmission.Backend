using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Public.Controllers
{
    public class SlideController : ApiController
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpGet]
        [ActionName("GetSlides")]
        public IHttpActionResult GetSlides([FromBody]SlideConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_slideService.GetSlide(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetSlideById")]
        public IHttpActionResult GetSlideById(int id)
        {
            try
            {
                var result = _slideService.GetSlideById(id);
                if (result == null)
                    return BadRequest(AppMessage.BadRequestNotFound);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}