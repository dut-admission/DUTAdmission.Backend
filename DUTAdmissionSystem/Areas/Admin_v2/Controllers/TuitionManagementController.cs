using DUTAdmissionSystem.Areas.Admin_v2.Services.Components;
using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
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
        [HttpPost]
        [ActionName("UpdateTutionInformation")]
        public IHttpActionResult UpdateTutionInformation([FromBody]TutionInformation tutionInfor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_tuitionManagementService.UpdateTutionInformation(tutionInfor));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
