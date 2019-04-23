using DUTAdmissionSystem.Database.Schema.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos
{
    public class UniversityInfoDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("university_name")]
        public string UniversityName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        public UniversityInfoDto()
        {
        }

        public UniversityInfoDto(int id, string universityName, string address, string phoneNumber, string fax, string email, string summary, string website, DateTime? createdAt)
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

        public UniversityInfoDto(UniversityInfo universityInfo)
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