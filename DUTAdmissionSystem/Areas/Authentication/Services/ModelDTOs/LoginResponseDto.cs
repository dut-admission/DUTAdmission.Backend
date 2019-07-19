using Newtonsoft.Json;

namespace DUTAdmissionSystem.Areas.Authentication.Services.ModelDTOs
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Avatar { get; set; }

        public string UserName { get; set; }

        public bool IsStudent { get; set; }
    }
}