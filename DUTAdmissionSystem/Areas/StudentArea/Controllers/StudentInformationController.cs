using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.StudentArea.Services.Components;
using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Fillters;
using System;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.StudentArea.Controllers
{
    public class StudentInformationController : ApiController
    {
        private readonly IStudentInforService _studentTuitionService;
        private readonly IHighSchoolResultService _highSchoolResultService;

        public StudentInformationController(IStudentInforService studentTuitionService, IHighSchoolResultService highSchoolResultService)
        {
            _studentTuitionService = studentTuitionService;
            _highSchoolResultService = highSchoolResultService;
        }

        

        [HttpGet]
        [ActionName("GetProfile")]
        [DUTAuthorize]
        public IHttpActionResult GetProfile()
        {
            try
            {
                int id = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                var profile = _studentTuitionService.GetProfile(id);
                profile.HighSchoolResults= _highSchoolResultService.GetHighSchoolResults(id);
                return Ok(profile);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("UpdateAvatar")]
        [DUTAuthorize]
        public IHttpActionResult UpdateAvatar([FromBody]Avatar avatar)
        {
            try
            {
                return Ok(_studentTuitionService.UpdateAvatar(avatar, FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader()), Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("UpdateProfile")]
        [DUTAuthorize]
        public IHttpActionResult UpdateProfile([FromBody]Profile profile)
        {
            try
            {
                return Ok(_studentTuitionService.SaveProfile(profile, FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader())));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetLibrariesOfProFile")]
        public IHttpActionResult GetLibrariesOfProFile()
        {
            try
            {
                var result = _studentTuitionService.GetLibrariesOfProFile();
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