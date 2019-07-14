using DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.StudentArea.Models.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.StudentArea.Controllers
{
    public class UniversityInfo_2Controller : ApiController
    {
        private readonly IUniversityInfo_2Service _universityInfoService;

        public UniversityInfo_2Controller(IUniversityInfo_2Service universityInfoService)
        {
            _universityInfoService = universityInfoService;
        }

        [HttpGet]
        [ActionName("GetUniversityInfo_2")]
        public IHttpActionResult GetUniversityInfo_2([FromBody]UniversityInfo_2ConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_universityInfoService.GetUniversityInfo(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
