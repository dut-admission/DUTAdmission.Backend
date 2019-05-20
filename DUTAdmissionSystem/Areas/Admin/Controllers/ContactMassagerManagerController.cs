using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Fillters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Admin.Controllers
{
    public class ContactMassagerManagerController : ApiController
    {
        private readonly IContactMessageManagerServiece _contactMessageManagerServiece;

        public ContactMassagerManagerController(IContactMessageManagerServiece contactMessageManagerServiece)
        {
            _contactMessageManagerServiece = contactMessageManagerServiece;
        }

        [HttpGet]
        [ActionName("GetContactMessagerList")]
        public IHttpActionResult GetContactMessagerList([FromBody]ContactMessageConditionSearch conditionSearch)
        {
            try
            {
                return Ok(_contactMessageManagerServiece.GetContactMessageList(conditionSearch));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("UpdateContactMessager")]
        public IHttpActionResult UpdateContactMessager(int id,UpdateContactMessage updateContactMessage)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _contactMessageManagerServiece.UpdateContactMessage(id,updateContactMessage);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("ReplyContactMessager")]
        public IHttpActionResult ReplyContactMessager(int id, ReplyContactMessage replyContactMessage)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _contactMessageManagerServiece.ReplyContactMessage(id, replyContactMessage);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
