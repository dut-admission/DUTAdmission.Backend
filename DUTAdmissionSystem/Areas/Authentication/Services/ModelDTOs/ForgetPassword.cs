using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Authentication.Services.ModelDTOs
{
    public class ForgetPassword
    {
        public string Email { get; set; }

        public string Username { get; set; }
    }
}