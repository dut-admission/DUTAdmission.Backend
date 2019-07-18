using DUTAdmissionSystem.Database.Schema.Entity;
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

        public List<DocumentInfoDto> DocumentInfoes { set; get; }

        public StudentForDocumentDto()
        {

        }

        public StudentForDocumentDto(int id, string firstName, string lastName, string identityNumber, int classId, string className, List<DocumentInfoDto> documentInfoes)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IdentityNumber = identityNumber;
            ClassId = classId;
            ClassName = className;
            DocumentInfoes = documentInfoes;
        }

        public StudentForDocumentDto(Student student, List<DocumentInfoDto> list)
        {
            Id = student.Id;
            FirstName = student.UserInfo.FirstName;
            LastName = student.UserInfo.LastName;
            IdentityNumber = student.IdentificationNumber;
            ClassId = student.ClassId;
            ClassName = student.Class.Name;
            DocumentInfoes = list;
        }
    }
}