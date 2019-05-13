using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DUTAdmissionSystem.Fillters
{
    /// <summary>
    /// Kiểm tra request trước khi đưa đến action của controller.
    /// Author       :   AnTM - 14/04/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   DUTAdmissionSystem.Fillters
    /// Copyright    :   Team DUTAdmissionSystem
    /// Version      :   1.0.0
    /// </remarks>
    public class DUTAuthorize : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Ghi đè phương thức dùng để lọc request.
        /// Author       :   AnTM - 14/04/2018 - create
        /// </summary>
        /// <param name="actionContext">
        /// Data của 1 request.
        /// </param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, AppMessage.NotAllowed);
            }
            else
            {
                string token = actionContext.Request.GetAuthorizationHeader();
                var tokenInformation = JwtAuthenticationExtensions.ExtractTokenInformation(token);
                if (tokenInformation == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, AppMessage.NotAllowed);
                }
                else if(tokenInformation.IsStudent)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NotAcceptable, AppMessage.NotAccept);
                }
                else
                {
                    var route = actionContext.RequestContext.RouteData;
                    string controller = (string)route.Values["controller"];
                    string action = (string)route.Values["action"];
                    if (!AccountVerification.CheckAuthentication(token, controller, action))
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NotAcceptable, AppMessage.NotAccept);
                    }
                }
            }
        }
    }
}