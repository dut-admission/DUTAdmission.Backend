using DUTAdmissionSystem.Database.Schema.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos
{
    public class UserResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar_url")]
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