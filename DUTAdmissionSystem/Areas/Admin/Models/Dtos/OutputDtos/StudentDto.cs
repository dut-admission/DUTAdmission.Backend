using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class StudentDto
    {
        public int Id { set; get; }

        public string IdentificationNumber { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string IdentityNumber { set; get; }

        public DateTime DateOfBirth { set; get; }

        public bool Sex { set; get; }

        public string PhoneNumber { set; get; }

        public string Email { set; get; }

        public string Address { set; get; }

        public int ClassId { set; get; }

        public string ClassName { set; get; }

        public int DepartmentId { set; get; }

        public string DepartmentName { set; get; }

        public int ProgramId { set; get; }

        public string ProgramName { set; get; }

        public StudentDto()
        {

        }

        public StudentDto(int id, string username, string firstName, string lastName, string identityNumber, DateTime dateOfBirth, bool sex, string phoneNumber, string email, string address, int classId, string className, int departmentId, string departmentName, int programId, string programName)
        {
            Id = id;
            IdentificationNumber = username;
            FirstName = firstName;
            LastName = lastName;
            IdentityNumber = identityNumber;
            DateOfBirth = dateOfBirth;
            Sex = sex;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            ClassId = classId;
            ClassName = className;
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            ProgramId = programId;
            ProgramName = programName;
        }

        public StudentDto(Student student, BirthInfo birthInfo, ContactInfo contactInfo, Department department)
        {
            Id = student.Id;
            FirstName = student.UserInfo.FirstName;
            LastName = student.UserInfo.LastName;
            IdentityNumber = student.IdentificationNumber;
            DateOfBirth = birthInfo.DateOfBirth;
            Sex = birthInfo.Sex;
            PhoneNumber = contactInfo.PhoneNumber;
            Email = contactInfo.Email;
            Address = contactInfo.Address;
            ClassId = student.ClassId;
            ClassName = student.Class.Name;
            DepartmentId = department.Id;
            DepartmentName = department.Name;
            ProgramId = department.ProgramId;
            ProgramName = department.Program.Name;
        }
    }
}