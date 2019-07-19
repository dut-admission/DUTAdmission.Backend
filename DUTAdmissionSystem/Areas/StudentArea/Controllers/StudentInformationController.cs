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

        public StudentInformationController(IStudentInforService studentTuitionService)
        {
            _studentTuitionService = studentTuitionService;
        }

        

        [HttpGet]
        [ActionName("GetProfile")]
        [DUTAuthorize]
        public IHttpActionResult GetProfile()
        {
            try
            {
                return Ok(_studentTuitionService.GetProfile(FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader())));
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
    }
}