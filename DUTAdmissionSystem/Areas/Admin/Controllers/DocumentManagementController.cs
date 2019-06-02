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
    public class DocumentManagementController : ApiController
    {
        private readonly IDocumentManagementService _documentManagementService;

        public DocumentManagementController(IDocumentManagementService documentManagementService)
        {
            _documentManagementService = documentManagementService;
        }

        [HttpGet]
        [ActionName("GetDocuments")]
        public IHttpActionResult GetDocuments([FromBody]DocumentConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_documentManagementService.GetListDocuments(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetDocumentTypeList")]
        public IHttpActionResult GetDocumentTypeList()
        {
            try
            {
                return Ok(_documentManagementService.GetDocumentTypeList());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
