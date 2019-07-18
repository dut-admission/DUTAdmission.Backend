using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos
{
    public class AdmissionNewsManagerConditionSearch
    {
        public string KeySearch { set; get; }

        public int CurrentPage { set; get; }

        public int PageSize { set; get; }

        public AdmissionNewsManagerConditionSearch()
        {
            this.KeySearch = "";
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }

    public class AdmissionNews
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [StringLength(200)]
        public string Summary { get; set; }
    }
}