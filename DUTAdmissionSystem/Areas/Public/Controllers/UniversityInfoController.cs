using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Public.Controllers
{
    public class UniversityInfoController : ApiController
    {
        private readonly IUniversityInfoService _universityInfoService;

        public UniversityInfoController(IUniversityInfoService universityInfoService)
        {
            _universityInfoService = universityInfoService;
        }

        [HttpGet]
        [ActionName("GetUniversityInfo")]
        public IHttpActionResult GetUniversityInfo([FromBody]UniversityInfoConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_universityInfoService.GetUniversityInfo(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

       
    }
}
