using DUTAdmissionSystem.Database.Schema.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Authentication.Services.ModelDTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public UserResponseDto(UserInfo user, string username)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            AvatarUrl = user.Avatar;
            Username = username;
        }
    }
}