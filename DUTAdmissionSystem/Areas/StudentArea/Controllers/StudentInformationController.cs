﻿using DUTAdmissionSystem.Areas.StudentArea.Services.Components;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Fillters;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.StudentArea.Controllers
{
    public class StudentInformationController : ApiController
    {
        private readonly IStudentTuitionService _studentTuitionService;

        public StudentInformationController(IStudentTuitionService studentTuitionService)
        {
            _studentTuitionService = studentTuitionService;
        }

        [HttpGet]
        [ActionName("GetTuitionDetail")]
        [DUTAuthorize]
        public IHttpActionResult GetTuitionDetail()
        {
            try
            {
                return Ok(_studentTuitionService.GetTuitionDetail(Request.GetAuthorizationHeader()));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}