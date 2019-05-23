using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Admin.Controllers
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
    }
}
