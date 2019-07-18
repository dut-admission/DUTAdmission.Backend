using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos
{
    public class StudentConditionSearch
    {
        public string Keyword { set; get; }

        public int ClassId { set; get; }

        public int ProgramId { set; get; }

        public int DepartmentId { set; get; }

        public int CurrentPage { set; get; }

        public int PageSize { set; get; }

        public StudentConditionSearch()
        {
            this.Keyword = "";
            this.ClassId = 0;
            this.ProgramId = 0;
            this.DepartmentId = 0;
            this.PageSize = 15;
            this.CurrentPage = 1;
        }
    }
}