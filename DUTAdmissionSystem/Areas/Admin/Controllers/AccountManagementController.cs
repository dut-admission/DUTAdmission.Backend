using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Admin.Controllers
{
    public class AccountManagementController : ApiController
    {
        private readonly IAccountManagementService _accountManagementService;

        public AccountManagementController(IAccountManagementService accountManagementService)
        {
            _accountManagementService = accountManagementService;
        }

        [HttpPost]
        [ActionName("GetAccountList")]
        public IHttpActionResult GetAccountList([FromBody]AccountConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_accountManagementService.GetListAccount(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [ActionName("GetAccountLibraries")]
        public IHttpActionResult GetAccountLibraries()
        {
            try
            {
                return Ok(_accountManagementService.GetAccountLibraries());
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
