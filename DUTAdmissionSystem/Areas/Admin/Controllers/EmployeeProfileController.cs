﻿using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Fillters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Admin.Controllers
{
    public class EmployeeProfileController : ApiController
    {
        private readonly IEmployeeProfileService _employeeProfileService;

        public EmployeeProfileController(IEmployeeProfileService employeeProfileService)
        {
            _employeeProfileService = employeeProfileService;
        }

        [HttpGet]
        [ActionName("GetEmployeeProfile")]
        // [DUTAuthorize]
        public IHttpActionResult GetEmployeeProfile()
        {
            try
            {
                return Ok(_employeeProfileService.GetEmployeeProfile(Request.GetAuthorizationHeader()));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("UpdateEmployeeProfile")]
        // [DUTAuthorize]
        public IHttpActionResult UpdateEmployeeProfile([FromBody]UpdateEmployeeProfile updateEmployeeProfile)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _employeeProfileService.UpdateEmployeeProfile(updateEmployeeProfile, Request.GetAuthorizationHeader());
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
