using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
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
    public class DocumentController : ApiController
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPut]
        [ActionName("UpdateFile")]
        //[Authorize]
        public IHttpActionResult UpdateFile([FromBody]DocumentDto documentDto)
        {
            try
            {
                _documentService.UpdateFile(documentDto, Request.GetAuthorizationHeader(), Request.RequestUri.Host);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetListDocument")]
        //[Authorize]
        public IHttpActionResult GetListDocument()
        {
            try
            {
                return Ok(_documentService.GetListDocument(Request.GetAuthorizationHeader()));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
