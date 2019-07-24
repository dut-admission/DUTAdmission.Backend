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
    public class StudentManagementController : ApiController
    {
        private readonly IStudentManagementService _studentManagementService;

        public StudentManagementController(IStudentManagementService studentManagementService)
        {
            _studentManagementService = studentManagementService;
        }

        [HttpPost]
        [ActionName("GetStudents")]
        public IHttpActionResult GetStudents([FromBody]StudentConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_studentManagementService.GetListStudents(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
