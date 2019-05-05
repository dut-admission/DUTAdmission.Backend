using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Dtos.InputDtos
{
    public class LoginDto
    {
        [JsonProperty("username")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [JsonProperty("password")]
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}