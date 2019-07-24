using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs
{
    public class StudentConditionSearch
    {
        public string Keyword { set; get; }

        public int ClassId { set; get; }

        public bool IsAdmitted { set; get; }

        public int ElectionTypeId { get; set; }

        public int CurrentPage { set; get; }

        public int PageSize { set; get; }

        public StudentConditionSearch()
        {
            this.Keyword = "";
            this.ClassId = 0;
            this.IsAdmitted = false;
            this.PageSize = 15;
            this.CurrentPage = 1;
        }
    }
}