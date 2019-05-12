using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class UpdatePassword
    {
        [JsonProperty("page_size")]
        public string OldPassword { get; set; }

        [JsonProperty("page_size")]
        public string NewPassword { get; set; }
    }
}