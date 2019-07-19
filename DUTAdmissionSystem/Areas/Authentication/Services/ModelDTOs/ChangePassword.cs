using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Authentication.Services.ModelDTOs
{
    public class ChangePassword
    {
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}