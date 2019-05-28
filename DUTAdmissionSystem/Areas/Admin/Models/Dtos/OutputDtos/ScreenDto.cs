using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class ScreenDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PermissionDto> Permissions { get; set; }

        public ScreenDto()
        {

        }

        public ScreenDto(int id, string name, List<PermissionDto> permissions)
        {
            Id = id;
            Name = name;
            Permissions = permissions;
        }

        public ScreenDto(Screen screen, List<PermissionDto> permissions)
        {
            this.Id = screen.Id;
            this.Name = screen.Name;
            this.Permissions = permissions;
        }
    }
}