using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos
{
    public class DocumentResponseDto
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsRequired { get; set; }
    }
}