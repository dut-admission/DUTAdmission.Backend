using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos
{
    public class TuitionConditionSearch
    {
        public string KeySearch { set; get; }

        public int ClassId { get; set; }

        public int DepartmentId { get; set; }

        public int ProgramId { get; set; }

        public bool IsPaid { get; set; }

        public int CurrentPage { set; get; }

        public int PageSize { set; get; }

        public TuitionConditionSearch()
        {
            this.KeySearch = "";
            this.ClassId = 0;
            this.DepartmentId = 0;
            this.ProgramId = 0;
            this.ClassId = 0;
            this.IsPaid = false;
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }
}