using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class ContactMessageDto
    {
        [StringLength(50)]
        [Required]
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [StringLength(50)]
        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [StringLength(500)]
        [Required]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}