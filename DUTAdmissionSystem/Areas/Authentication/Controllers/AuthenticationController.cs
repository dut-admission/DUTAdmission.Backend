using DUTAdmissionSystem.Areas.Authentication.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Authentication.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.Authentication.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        
        [HttpPost]
        public IHttpActionResult Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = authenticationService.Login(dto);

            if (result == null)
                return CreateUnauthorizedResponse("Invalid username or password");

            var output = Request.CreateResponse(HttpStatusCode.OK, result);

            output.Headers.Add("Authorization", result.AccessToken);

            return ResponseMessage(output);
        }

        private IHttpActionResult CreateUnauthorizedResponse(string message)
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(message)
            });
        }
    }
}
