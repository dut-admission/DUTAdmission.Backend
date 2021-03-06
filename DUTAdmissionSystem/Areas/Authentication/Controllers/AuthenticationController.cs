﻿using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.Authentication.Services.Components;
using DUTAdmissionSystem.Areas.Authentication.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
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
                return CreateUnauthorizedResponse("Username hoặc mật khẩu không chính xác.");

            var output = Request.CreateResponse(HttpStatusCode.OK, result);

            output.Headers.Add("Authorization", result.AccessToken);

            return ResponseMessage(output);
        }

        [HttpPost]
        [ActionName("ForgetPassword")]
        public IHttpActionResult ForgetPassword(ForgetPassword input)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (authenticationService.ForgetPass(input))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(AppMessage.NoAccount);
                };
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [ActionName("ChangePassword")]
        public IHttpActionResult ChangePassword(ChangePassword changePassword)
        {
            try
            {
                int id = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = authenticationService.ChangePass(changePassword, id);

                if (result == 2)
                {
                    return Ok();
                }
                else if (result == 1)
                {
                    return BadRequest("Mật khẩu cũ không đúng, vui lòng kiểm tra lại !");
                }
                else
                {
                    return BadRequest("Có lỗi xảy ra, vui lòng kiểm tra lại");
                };
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        private IHttpActionResult CreateUnauthorizedResponse(string message)
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(message)
            });
        }
    }
}