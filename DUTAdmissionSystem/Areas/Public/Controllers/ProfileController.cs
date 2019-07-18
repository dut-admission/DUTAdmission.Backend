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
     //   [Authorize]
        [ActionName("GetStudentProfile")]
        public IHttpActionResult GetStudentProfileByIdAccount()
        {
            try
            {
                var result = _studentProfileService.GetStudentProfileByIdAccount(Request.GetAuthorizationHeader());
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
       // [Authorize]
        [ActionName("UpdatePassword")]
        public IHttpActionResult UpdatePassword([FromBody]UpdatePassword updatePassword) 
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

        [HttpGet]
        [ActionName("GetLibrariesOfProFile")]
        public IHttpActionResult GetLibrariesOfProFile()
        {
            try
            {
                var result = _studentProfileService.GetLibrariesOfProFile();
                if (result == null)
                    return BadRequest(AppMessage.BadRequestNotFound);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("UpdateAddAchievement")]
       // [Authorize]
        public IHttpActionResult UpdateAddAchievement([FromBody]Achievement achievement)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                 var result = _studentProfileService.UpdateAddAchievement(achievement, Request.GetAuthorizationHeader());
              
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("UpdateAddFamilyMember")]
       // [Authorize]
        public IHttpActionResult UpdateAddFamilyMember([FromBody]FamilyMember familyMember)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _studentProfileService.UpdateAddFamilyMember(familyMember, Request.GetAuthorizationHeader());

                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("UpdateAddHighSchoolResult")]
      //  [Authorize]
        public IHttpActionResult UpdateAddHighSchoolResult([FromBody]HighSchoolResult highSchoolResult)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = _studentProfileService.UpdateAddHighSchoolResult(highSchoolResult, Request.GetAuthorizationHeader());

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("DeletionObject")]
      //  [Authorize]
        public IHttpActionResult DeletionObject([FromBody]DeletionObject deletionObject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (_studentProfileService.DeletionObject(deletionObject, Request.GetAuthorizationHeader()))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                };

            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("UpdateProfile")]
        //  [Authorize]
        public IHttpActionResult UpdateProfile([FromBody]Profile profile)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _studentProfileService.UpdateProfile(profile, Request.GetAuthorizationHeader());

                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

       

    }
}