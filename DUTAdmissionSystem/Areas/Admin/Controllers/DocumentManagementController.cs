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

        [HttpPost]
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

        [HttpPost]
        [ActionName("AddDocumentType")]
        public IHttpActionResult AddDocumentType([FromBody]DocumentTypeManagement documentType)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_documentManagementService.AddDocumentType(documentType));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("EditDocumentType")]
        public IHttpActionResult EditDocumentType([FromBody]DocumentTypeManagement documentType, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_documentManagementService.EditDocumentType(documentType, id));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [ActionName("DeleteDocumentType")]
        public IHttpActionResult DeleteDocumentType(int id)
        {
            try
            {
                _documentManagementService.DeleteDocumentType(id);
                return Ok(true);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
