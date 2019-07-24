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
    public class DocumentManagementController : ApiController
    {

        private readonly IDocumentManagement _documentManagement;

        public DocumentManagementController(IDocumentManagement documentManagement)
        {
            _documentManagement = documentManagement;
        }
        [HttpPut]
        [ActionName("UpdateDocument")]
        public IHttpActionResult UpdateDocument([FromBody]List<Document> documentType)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_documentManagement.UpdateDocument(documentType));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
