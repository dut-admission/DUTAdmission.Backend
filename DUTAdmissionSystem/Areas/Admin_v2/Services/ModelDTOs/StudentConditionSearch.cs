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


        public bool ? Status { set; get; }

        public int CurrentPage { set; get; }

        public int PageSize { set; get; }

        public StudentConditionSearch()
        {
            this.Keyword = "";
            this.ClassId = 0;
            this.Status = null;
            this.PageSize = 15;
            this.CurrentPage = 1;
        }
    }
}