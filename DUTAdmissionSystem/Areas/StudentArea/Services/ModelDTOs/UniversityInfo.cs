using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs
{
    public class UniversityInfo
    {
        public int Id { get; set; }

        public string UniversityName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Summary { get; set; }

        public string Website { get; set; }

        public DateTime? CreatedAt { get; set; }

        public UniversityInfo()
        {
        }

        public UniversityInfo(int id, string universityName, string address, string phoneNumber, string fax, string email, string summary, string website, DateTime? createdAt)
        {
            Id = id;
            UniversityName = universityName;
            Address = address;
            PhoneNumber = phoneNumber;
            Fax = fax;
            Email = email;
            Summary = summary;
            Website = website;
            CreatedAt = createdAt;
        }

        public UniversityInfo(UniversityInfo universityInfo)
        {
            Id = universityInfo.Id;
            UniversityName = universityInfo.UniversityName;
            Address = universityInfo.Address;
            PhoneNumber = universityInfo.PhoneNumber;
            Fax = universityInfo.Fax;
            Email = universityInfo.Email;
            Summary = universityInfo.Summary;
            Website = universityInfo.Website;
            CreatedAt = universityInfo.CreatedAt;
        }
    }
}