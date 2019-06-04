using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Admin.Controllers
{
    public class PermissionManagementController : ApiController
    {
        private readonly IPermissionManagementService _permissionManagementService;

        public PermissionManagementController(IPermissionManagementService permissionManagementService)
        {
            _permissionManagementService = permissionManagementService;
        }

        [HttpGet]
        [ActionName("GetPermissions")]
        public IHttpActionResult GetPermissions()
        {
            try
            {
                return Ok(_permissionManagementService.GetListPermissions());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("UpdateActive")]
        public IHttpActionResult UpdateActive(int id)
        {
            try
            {
                _permissionManagementService.UpdateIsActivePermissionById(id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
