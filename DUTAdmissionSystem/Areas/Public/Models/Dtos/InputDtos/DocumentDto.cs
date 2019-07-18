using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class DocumentDto
    {
        public int DocumentId { get; set; }

        public string File { get; set; }

        public string FileName { get; set; }
    }
}