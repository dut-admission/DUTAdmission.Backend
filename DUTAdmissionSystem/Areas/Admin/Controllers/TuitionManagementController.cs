using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Admin.Controllers
{
    public class TuitionManagementController : ApiController
    {
        private readonly ITuitionManagementService _tuitionManagementService;

        public TuitionManagementController(ITuitionManagementService tuitionManagementService)
        {
            _tuitionManagementService = tuitionManagementService;
        }

        [HttpGet]
        [ActionName("GetTuitionList")]
        public IHttpActionResult GetTuitionList([FromBody]TuitionConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_tuitionManagementService.GetTuitionListResponse(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetTuitionLibraries")]
        public IHttpActionResult GetTuitionLibraries()
        {
            try
            {
                return Ok(_tuitionManagementService.GetLibraries());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
