using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Public.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPut]
        [ActionName("UpdatePassword")]
        public IHttpActionResult GetSlides([FromBody]UpdatePassword data)
        {
            try
            {
                return Ok(_profileService.UpdatePassWord(data));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
