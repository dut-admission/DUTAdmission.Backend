using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Public.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly IStudentProfileService _studentProfileService;
        public ProfileController(IStudentProfileService studentProfileService)
        {
            _studentProfileService = studentProfileService;
        }

        [HttpGet]
        [ActionName("GetStudentProfile")]
        public IHttpActionResult GetStudentProfileByIdAccount()
        {
            try
            {
                var result = _studentProfileService.GetStudentProfileByIdAccount(1);
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