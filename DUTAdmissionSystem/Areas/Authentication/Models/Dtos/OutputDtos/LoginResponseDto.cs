using Newtonsoft.Json;

namespace DUTAdmissionSystem.Areas.Authentication.Models.Dtos.OutputDtos
{
    public class LoginResponseDto
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}