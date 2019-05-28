using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class PermissionResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ScreenDto> Screens { get; set; }
        public PermissionResponseDto()
        {

        }

        public PermissionResponseDto(int id, string name, List<ScreenDto> screens)
        {
            Id = id;
            Name = name;
            Screens = screens;
        }

        public PermissionResponseDto(AccountGroup accountGroup, List<ScreenDto> screens)
        {
            this.Id = accountGroup.Id;
            this.Name = accountGroup.Name;
            this.Screens = screens;
        }
    }
}