using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.StudentArea.Services.Components;
using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
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
        private readonly IFamilyMemberService _familyMemberService;
        public FamilyMemberController(IFamilyMemberService familyMemberService)
        {
            _familyMemberService = familyMemberService;
        }

        [HttpGet]
        [ActionName("GetFamilyMembers")]
        public IHttpActionResult GetFamilyMembers()
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                var result = _familyMemberService.GetFamilyMembers(idUser);
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
        [ActionName("AddFamilyMember")]
        // [Authorize]
        public IHttpActionResult AddFamilyMember([FromBody]FamilyMember familyMember)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                familyMember = _familyMemberService.AddFamilyMember(familyMember, idUser);
                if (familyMember == null)
                {
                    return BadRequest("Mối quan hệ này đã tồn tại.");
                };
                return Ok(familyMember);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpPut]
        [ActionName("UpdateFamilyMember")]
        public IHttpActionResult UpdateHighSchoolResult([FromBody]FamilyMember familyMember)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                familyMember = _familyMemberService.UpdateFamilyMember(familyMember, idUser);
                if (familyMember == null)
                {
                    return BadRequest("Mối quan hệ này đã tồn tại.");
                };
                return Ok(familyMember);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpDelete]
        [ActionName("DeleteFamilyMember")]
        public IHttpActionResult DeleteFamilyMember(int id)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _familyMemberService.DeleteFamilyMember(idUser, id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
