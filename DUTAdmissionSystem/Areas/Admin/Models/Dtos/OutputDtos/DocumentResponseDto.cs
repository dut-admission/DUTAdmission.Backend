using DUTAdmissionSystem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class DocumentResponseDto
    {
        public List<StudentForDocumentDto> ListOfDocuments { set; get; }

        public List<ClassDto> ListOfClasses { set; get; }

        public List<DepartmentDto> ListOfDepartments { set; get; }

        public List<ProgramDto> ListOfPrograms { set; get; }

        public List<DocumentTypeDto> ListOfDocumentTypes { set; get; }

        public List<StatusDto> ListOfStatus { set; get; }
        public Paging Paging { set; get; }


        public DocumentResponseDto()
        {

        }

        public DocumentResponseDto(List<StudentForDocumentDto> listOfDocuments, List<ClassDto> listOfClasses, List<DepartmentDto> listOfDepartments, List<ProgramDto> listOfPrograms, List<DocumentTypeDto> listOfDocumentTypes, List<StatusDto> listOfStatus, Paging paging)
        {
            ListOfDocuments = listOfDocuments;
            ListOfClasses = listOfClasses;
            ListOfDepartments = listOfDepartments;
            ListOfPrograms = listOfPrograms;
            ListOfDocumentTypes = listOfDocumentTypes;
            ListOfStatus = listOfStatus;
            Paging = paging;
        }
    }
}