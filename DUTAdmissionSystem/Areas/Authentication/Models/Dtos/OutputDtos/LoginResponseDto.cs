using Newtonsoft.Json;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos
{
    public class LoginResponseDto
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("isStudent")]
        public bool IsStudent { get; set; }
    }
}