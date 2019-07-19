using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.StudentArea.Services.Components;
using DUTAdmissionSystem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.StudentArea.Controllers
{
    public class FamilyMemberController : ApiController
    {
        private readonly IFamilyMemberService _FamilyMemberService;
        public FamilyMemberController(IFamilyMemberService FamilyMemberService)
        {
            _FamilyMemberService = FamilyMemberService;
        }

        [HttpGet]
        [ActionName("GetFamilyMembers")]
        public IHttpActionResult GetFamilyMembers()
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                var result = _FamilyMemberService.GetFamilyMembers(idUser);
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
