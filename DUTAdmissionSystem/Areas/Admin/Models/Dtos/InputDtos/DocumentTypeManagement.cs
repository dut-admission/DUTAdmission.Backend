using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos
{
    public class DocumentTypeManagement
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
    }
}