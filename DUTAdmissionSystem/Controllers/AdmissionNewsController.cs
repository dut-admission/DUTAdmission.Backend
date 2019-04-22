using DUTAdmissionSystem.Models.Dto.Input;
using DUTAdmissionSystem.Models.Service.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Controllers
{
    public class AdmissionNewsController : ApiController
    {
        private readonly IAdmissionNewsService _admissionNewsService;

        public AdmissionNewsController(IAdmissionNewsService admissionNewsService)
        {
            _admissionNewsService = admissionNewsService;
        }

        [HttpGet]
        [ActionName("GetAdmissionNews")]
        public IHttpActionResult GetAdmissionNews([FromBody]AdmissionNewsConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_admissionNewsService.GetAdmissionNews(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
