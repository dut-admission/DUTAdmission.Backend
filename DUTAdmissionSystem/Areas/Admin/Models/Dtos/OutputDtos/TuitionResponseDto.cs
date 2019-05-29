using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class TuitionResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public double TuitionFee { get; set; }
        public string TotalTuition { get; set; }
        public bool IsPaid { get; set; }
        public Receipt Receipt { get; set; }
    }

    public class Receipt
    {
        public int Id { get; set; }
        public int CollectorUserId { get; set; }
        public int PayerUserId { get; set; }
        public decimal Money { get; set; }
        public int ReceiptNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CollectionDate { get; set; }
    }

    public class TuitionTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public string Description { get; set; }
    }

    public class LibrariesOfTuition
    {
        public TuitionTypes TuitionTypes { get; set; }
        public List<Statuses> Statuses { get; set; }
        public List<EducationProgram> EducationPrograms { get; set; }
        
    }

    public class Statuses
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EducationProgram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Departments> Departments { get; set; }
    }

    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Classes> Classes { get; set; }
    }

    public class Classes
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}