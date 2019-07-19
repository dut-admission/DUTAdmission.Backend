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
        public IHttpActionResult GetUniversityInfo_2()
        {
            try
            {
                return Ok(_universityInfoService.GetUniversityInfo());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}