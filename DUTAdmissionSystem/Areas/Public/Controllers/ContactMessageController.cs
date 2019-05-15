using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Public.Controllers
{
    public class ContactMessageController : ApiController
    {
        private readonly IContactMessageService _contactMessageService;

        public ContactMessageController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }

        [HttpPost]
        [ActionName("SubmitContactMessage")]
        public IHttpActionResult SubmitContactMessage([FromBody]ContactMessageDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _contactMessageService.SubmitContactMessage(dto);

                return Ok(AppMessage.OkSucceeded);

            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
