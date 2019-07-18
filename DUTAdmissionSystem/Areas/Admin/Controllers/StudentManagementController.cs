using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Admin.Controllers
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

        [HttpPut]
        [ActionName("UpdateStudent")]
        public IHttpActionResult UpdateStudent([FromBody]StudentDto student)
        {
            try
            {
                return Ok(_studentManagementService.UpdateStudent(student));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpDelete]
        [ActionName("DeleteStudent")]
        public IHttpActionResult DeleteStudent([FromUri]int id)
        {
            try
            {
                return Ok(_studentManagementService.DeleteStudent(id));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }


    }
}
