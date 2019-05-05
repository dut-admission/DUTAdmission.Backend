using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos
{
    public class LoginResponseDto
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("user")]
        public UserResponseDto User { get; set; }

        [JsonProperty("group")]
        public GroupResponseDto Group { get; set; }
    }
}