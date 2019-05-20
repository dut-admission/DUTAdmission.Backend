using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Public.Controllers
{
    public class TuitionDetailController : ApiController
    {
        private readonly ITuitionManagerService _tuitionManagerService;

        public TuitionDetailController(ITuitionManagerService tuitionManagerService)
        {
            _tuitionManagerService = tuitionManagerService;
        }

        [HttpGet]
        [ActionName("GetTuitionDetail")]
        public IHttpActionResult GetTuitionDetail()
        {
            try
            {
                return Ok(_tuitionManagerService.GetTuitionDetail(Request.GetAuthorizationHeader()));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
