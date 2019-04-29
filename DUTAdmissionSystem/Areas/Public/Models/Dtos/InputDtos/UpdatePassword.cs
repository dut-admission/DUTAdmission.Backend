using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class UpdatePassword
    {
        [JsonProperty("old_password")]
        [Required]
        public string OldPassWord { set; get; }

        [RegularExpression("^(?=.*\\d)(?=.*[a-zA-Z])[a-zA-Z0-9]{8,50}$")]
        [JsonProperty("new_password")]
        [Required]
        public string NewPassWord { set; get; }

        [JsonProperty("confirm_password")]
        [Required]
        [Compare("NewPassWord")]
        public string ConfirmPassword { set; get; }
    }
}