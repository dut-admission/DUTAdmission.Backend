using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class DocumentInfoDto
    {
        public int DocumentTypeId { set; get; }

        public string DocumentTypeName { set; get; }

        public string Description { set; get; }

        public bool IsRequired { set; get; }

        public string Url { set; get; }

        public string FileName { set; get; }

        public string ResponseMessage { set; get; }

        public int StatusId { set; get; }

        public string StatusName { set; get; }

        public DocumentInfoDto()
        {

        }

        public DocumentInfoDto(int documentTypeId, string documentTypeName, string description, bool isRequied, string url, string fileName, string responseMessage, int statusId, string statusName)
        {
            DocumentTypeId = documentTypeId;
            DocumentTypeName = documentTypeName;
            Description = description;
            IsRequired = isRequied;
            Url = url;
            FileName = fileName;
            ResponseMessage = responseMessage;
            StatusId = statusId;
            StatusName = statusName;
        }
        public DocumentInfoDto(Document document)
        {
            DocumentTypeId = document.DocumentTypeId;
            DocumentTypeName = document.DocumentType.Name;
            Description = document.DocumentType.Description;
            IsRequired = document.DocumentType.IsRequired;
            Url = document.Url;
            FileName = document.FileName;
            ResponseMessage = document.ResponseMessage;
            StatusId = document.StatusId;
            StatusName = document.Status.Name;
        }
    }
}