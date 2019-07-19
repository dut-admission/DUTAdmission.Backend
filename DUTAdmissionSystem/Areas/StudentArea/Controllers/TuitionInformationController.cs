using DUTAdmissionSystem.Areas.StudentArea.Services.Components;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Fillters;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.StudentArea.Controllers
{
    public class TuitionInformationController : ApiController
    {
        private readonly ITuitionInformationService _tuitionInforService;

        public TuitionInformationController(ITuitionInformationService tuitionInforService)
        {
            _tuitionInforService = tuitionInforService;
        }

        [HttpGet]
        [ActionName("GetTuitionDetail")]
        [DUTAuthorize]
        public IHttpActionResult GetTuitionDetail()
        {
            try
            {
                var userId = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                return Ok(_tuitionInforService.GetTuitionInformation(userId));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}