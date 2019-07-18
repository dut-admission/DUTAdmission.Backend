using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class DocumentTypeDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public DocumentTypeDto()
        {
        }
        public DocumentTypeDto(int id, string name)
        {
            Id = id;
            Name = name;

        }
        public DocumentTypeDto(DocumentType c)
        {
            Id = c.Id;
            Name = c.Name;
        }
    }
}