using DUTAdmissionSystem.Areas.Admin_v2.Services.Components;
using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Admin_v2.Controllers
{
    public class TuitionManagementController : ApiController
    {
        private readonly ITuitionManagementService _tuitionManagementService;
        public TuitionManagementController(ITuitionManagementService tuitionManagementService)
        {
            _tuitionManagementService = tuitionManagementService;
        }
        [HttpPost]
        [ActionName("UpdateTutionInformation")]
        public IHttpActionResult UpdateTutionInformation([FromBody]TutionInformation tutionInfor)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(_tuitionManagementService.UpdateTutionInformation(tutionInfor, idUser));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
