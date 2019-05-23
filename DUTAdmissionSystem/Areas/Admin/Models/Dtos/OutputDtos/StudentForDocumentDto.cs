using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class StudentForDocumentDto
    {
        public int Id { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string IdentityNumber { set; get; }

        public int ClassId { set; get; }

        public string ClassName { set; get; }

        public int DocumentTypeId { set; get; }

        public string DocumentTypeName { set; get; }

        public string Description { set; get; }

        public bool IsRequied { set; get; }

        public string Url { set; get; }

        public string FileName { set; get; }

        public string ResponseMessage { set; get; }

        public int StatusId { set; get; }

        public string StatusName { set; get; }

        public StudentForDocumentDto()
        {

        }

        public StudentForDocumentDto(int id, string firstName, string lastName, string identityNumber, int classId, string className, int documentTypeId, string documentTypeName, string description, bool isRequied, string url, string fileName, string responseMessage, int statusId, string statusName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IdentityNumber = identityNumber;
            ClassId = classId;
            ClassName = className;
            DocumentTypeId = documentTypeId;
            DocumentTypeName = documentTypeName;
            Description = description;
            IsRequied = isRequied;
            Url = url;
            FileName = fileName;
            ResponseMessage = responseMessage;
            StatusId = statusId;
            StatusName = statusName;
        }
    }
}