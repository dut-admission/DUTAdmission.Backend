using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class ForgetPassword
    {
        [JsonProperty("input")]
        public string Input { get; set; }
    }
}