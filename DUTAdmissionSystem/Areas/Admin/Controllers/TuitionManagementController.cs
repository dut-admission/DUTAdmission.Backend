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

        [HttpGet]
        [ActionName("GetTuitionTypeList")]
        public IHttpActionResult GetTuitionTypeList()
        {
            try
            {
                return Ok(_tuitionManagementService.GetTuitionTypeList());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("AddTuitionType")]
        public IHttpActionResult AddTuitionType([FromBody]TuitionTypeManagement tuitionType)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_tuitionManagementService.AddTuitionType(tuitionType));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("EditTuitionType")]
        public IHttpActionResult EditTuitionType([FromBody]TuitionTypeManagement tuitionType,int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_tuitionManagementService.EditTuitionType(tuitionType,id));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [ActionName("DeleteTuitionType")]
        public IHttpActionResult DeleteTuitionType(int id)
        {
            try
            {
                _tuitionManagementService.DeleteTuitionType(id);
                return Ok(true);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
