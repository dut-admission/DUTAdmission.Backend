using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos
{
    public class AccountGroupDto
    {
        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        [Required]
        [StringLength(255)]
        public string Description { set; get; }

    }
}