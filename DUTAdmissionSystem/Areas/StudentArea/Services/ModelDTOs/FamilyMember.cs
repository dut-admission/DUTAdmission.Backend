using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RelationId { get; set; }
        public string RelationName { get; set; }
        public int YearOfBirth { get; set; }
        public int CareerTypeId { get; set; }
        public string CareerTypeName { get; set; }
        public int EthnicId { get; set; }
        public string EthnicName { get; set; }
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
        public int NationalityId { get; set; }
        public string NationalityName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}