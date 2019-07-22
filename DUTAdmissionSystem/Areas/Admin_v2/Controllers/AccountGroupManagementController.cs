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
    public class AccountGroupManagementController : ApiController
    {
        private readonly IAccountGroupManagementService _accountGroupManagementService;

        public AccountGroupManagementController(IAccountGroupManagementService accountGroupManagementService)
        {
            _accountGroupManagementService = accountGroupManagementService;
        }

        [HttpGet]
        [ActionName("GetAccountGroups")]
        public IHttpActionResult GetAccountGroups()
        {
            try
            {
                return Ok(_accountGroupManagementService.GetListAccountGroups());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetAccountGroupById")]
        public IHttpActionResult GetAccountGroupById(int id)
        {
            try
            {
                return Ok(_accountGroupManagementService.GetAccountGroupById(id));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [ActionName("AddAccountGroup")]
        public IHttpActionResult AddAccountGroup([FromBody]AccountGroup accountGroup)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_accountGroupManagementService.AddAccountGroup(accountGroup));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("EditAccountGroup")]
        public IHttpActionResult EditAccountGroup(int id, [FromBody]AccountGroup accountGroup)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(_accountGroupManagementService.EditAccountGroup(accountGroup, id));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [ActionName("DeleteAccountGroup")]
        public IHttpActionResult DeleteAccountGroup(int id)
        {
            try
            {
                _accountGroupManagementService.DeleteAccountGroup(id);
                return Ok(true);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
