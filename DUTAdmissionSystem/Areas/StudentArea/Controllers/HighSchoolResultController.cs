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
    public class HighSchoolResultController : ApiController
    {
        private readonly IHighSchoolResultService _highSchoolResultService;
        // GET: api/HighSchoolResult
        public HighSchoolResultController(IHighSchoolResultService highSchoolResultService)
        {
            _highSchoolResultService = highSchoolResultService;
        }
        [HttpGet]
        [ActionName("GetHighSchoolResult")]
        public IHttpActionResult GetHighSchoolResult()
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                var result = _highSchoolResultService.GetHighSchoolResults(idUser);
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
        [ActionName("AddHighSchoolResult")]
        // [Authorize]
        public IHttpActionResult AddHighSchoolResult([FromBody]HighSchoolResult highSchoolResult)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (_highSchoolResultService.AddHighSchoolResult(highSchoolResult, idUser) == false)
                {
                    return BadRequest("Kết quả học tập năm này đã tồn tại.");
                };
                return Ok(highSchoolResult);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpPut]
        [ActionName("UpdateHighSchoolResult")]
        public IHttpActionResult UpdateHighSchoolResult([FromBody]HighSchoolResult highSchoolResult)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _highSchoolResultService.UpdateHighSchoolResult(highSchoolResult, idUser);
                return Ok(highSchoolResult);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpDelete]
        [ActionName("DeleteHighSchoolResult")]
        public IHttpActionResult DeleteHighSchoolResult(int id)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _highSchoolResultService.DeleteHighSchoolResult(idUser, id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
