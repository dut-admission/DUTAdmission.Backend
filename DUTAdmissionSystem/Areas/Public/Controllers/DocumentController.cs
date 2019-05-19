using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Fillters;
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
        [DUTAuthorize]
        public IHttpActionResult UpdateFile([FromBody]DocumentDto documentDto)
        {
            try
            {
                return Ok(_documentService.UpdateFile(documentDto, Request.GetAuthorizationHeader(), Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetListDocument")]
        [DUTAuthorize]
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
