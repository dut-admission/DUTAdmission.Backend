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
    public class AdmissionNewsManagerController : ApiController
    {
        private readonly IAdmissionNewsManagerService _admissionNewsManagerService;

        public AdmissionNewsManagerController(IAdmissionNewsManagerService admissionNewsManagerService)
        {
            _admissionNewsManagerService = admissionNewsManagerService;
        }

        [HttpGet]
        [ActionName("GetAdmissionNewsList")]
        public IHttpActionResult GetAdmissionNewsList([FromBody]AdmissionNewsManagerConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_admissionNewsManagerService.GetAdmissionNewsList(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("Add_EditAdmissionNews")]
        public IHttpActionResult Add_EditAdmissionNews([FromBody]AdmissionNews admissionNews)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _admissionNewsManagerService.Add_EditAdmissionNews(admissionNews);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [ActionName("DeleteAdmissionNews")]
        public IHttpActionResult DeleteAdmissionNews(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _admissionNewsManagerService.DelAdmissionNews(id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
