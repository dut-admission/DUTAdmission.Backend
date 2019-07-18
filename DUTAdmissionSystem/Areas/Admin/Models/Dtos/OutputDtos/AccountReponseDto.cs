using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class AccountReponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int AccountGroupId { get; set; }
        public string AccountGroupName { get; set; }
    }

    public class AccountLibraries
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}