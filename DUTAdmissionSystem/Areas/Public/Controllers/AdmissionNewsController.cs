    using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Public.Controllers
{
    public class AdmissionNewsController : ApiController
    {
        private readonly IAdmissionNewsService _admissionNewsService;

        public AdmissionNewsController(IAdmissionNewsService admissionNewsService)
        {
            _admissionNewsService = admissionNewsService;
        }

        [HttpGet]
        [ActionName("GetAdmissionNews")]
        public IHttpActionResult GetAdmissionNews([FromBody]AdmissionNewsConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_admissionNewsService.GetAdmissionNews(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetAdmissionNewsById")]
        public IHttpActionResult GetAdmissionNewsById(int id)
        {
            try
            {
                var result = _admissionNewsService.GetAdmissionNewsById(id);
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