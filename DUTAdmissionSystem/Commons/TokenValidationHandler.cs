using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DUTAdmissionSystem.Commons
{
    public class TokenValidationHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authHeaders;
            // ReSharper disable once PossibleMultipleEnumeration
            if (!request.Headers.TryGetValues("Authorization", out authHeaders) || authHeaders.Count() > 1)
            {
                return false;
            }
            // ReSharper disable once PossibleMultipleEnumeration
            var bearerToken = authHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            //determine whether a jwt exists or not
            if (!TryRetrieveToken(request, out token))
            {
                //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                const string sec = Constants.TokenSecretKey;
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));


                SecurityToken securityToken;
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidAudience = Constants.ValidAudience,
                    ValidIssuer = Constants.ValidIssuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                //extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);

                return base.SendAsync(request, cancellationToken);
            }
            catch (Exception)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode), cancellationToken);
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires == null) return false;
            return DateTime.UtcNow < expires;
        }
    }
}