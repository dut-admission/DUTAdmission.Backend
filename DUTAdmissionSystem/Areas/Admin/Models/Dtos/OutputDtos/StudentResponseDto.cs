using DUTAdmissionSystem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class StudentResponseDto
    {
        public List<StudentDto> ListOfStudents { set; get; }

        public List<ClassDto> ListOfClasses { set; get; }

        public List<DepartmentDto> ListOfDepartments { set; get; }

        public List<ProgramDto> ListOfPrograms { set; get; }

        public Paging Paging { get; set; }

        public StudentResponseDto()
        {

        }

        public StudentResponseDto(List<StudentDto> listOfStudents, List<ClassDto> listOfClasses, List<DepartmentDto> listOfDepartments, List<ProgramDto> listOfPrograms, Paging paging)
        {
            ListOfStudents = listOfStudents;
            ListOfClasses = listOfClasses;
            ListOfDepartments = listOfDepartments;
            ListOfPrograms = listOfPrograms;
            Paging = paging;
        }
    }
}