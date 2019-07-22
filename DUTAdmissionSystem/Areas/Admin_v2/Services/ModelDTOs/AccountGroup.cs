using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AccountGroupTbl = DUTAdmissionSystem.NewDatabase.Schema.Entity.AccountGroup;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs
{
    public class AccountGroup
    {
        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        [Required]
        [StringLength(255)]
        public string Description { set; get; }
    }

    public class AccountGroupResponse
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public AccountGroupResponse()
        {

        }

        public AccountGroupResponse(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public AccountGroupResponse(AccountGroupTbl c)
        {
            Id = c.Id;
            Name = c.Name;
            Description = c.Description;
        }
    }
}