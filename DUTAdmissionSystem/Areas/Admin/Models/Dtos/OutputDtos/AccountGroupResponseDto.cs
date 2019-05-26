using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class AccountGroupResponseDto
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public AccountGroupResponseDto()
        {

        }

        public AccountGroupResponseDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public AccountGroupResponseDto(AccountGroup c)
        {
            Id = c.Id;
            Name = c.Name;
            Description = c.Description;
        }
    }
}