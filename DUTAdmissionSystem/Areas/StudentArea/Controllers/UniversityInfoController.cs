using DUTAdmissionSystem.Areas.StudentArea.Services.Components;
using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.StudentArea.Controllers
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
        public IHttpActionResult GetUniversityInfo_2([FromBody]UniversityInfoConditionSearch conditionSearch)
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