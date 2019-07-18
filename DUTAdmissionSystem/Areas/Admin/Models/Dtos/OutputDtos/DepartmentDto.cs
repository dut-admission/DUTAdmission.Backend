using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class DepartmentDto
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public DepartmentDto()
        {

        }

        public DepartmentDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public DepartmentDto(Department c)
        {
            Id = c.Id;
            Name = c.Name;
        }
    }
}