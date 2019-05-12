using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using System.Net;
using System.Net.Http;
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

        [HttpPut]
        [ActionName("UpdatePassword")]
        public IHttpActionResult UpdatePassword(UpdatePassword updatePassword) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (_studentProfileService.UpdatePass(updatePassword, Request.GetAuthorizationHeader()))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(AppMessage.NeverPassword);
                };
            }
            catch(System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("ForgetPassword")]
        public IHttpActionResult ForgetPassword(ForgetPassword input)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (_studentProfileService.ForgetPass(input))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(AppMessage.NeverPassword);
                };
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}