using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos
{
    public class TokenInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}