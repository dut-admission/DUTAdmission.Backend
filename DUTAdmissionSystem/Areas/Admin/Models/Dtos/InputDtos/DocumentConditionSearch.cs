using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos
{
    public class DocumentConditionSearch
    {
        public string Keyword { set; get; }

        public int ClassId { set; get; }

        public int ProgramId { set; get; }

        public int DepartmentId { set; get; }

        public int DocumentTypeId { set; get; }

        public int StatusId { set; get; }

        public int CurrentPage { set; get; }

        public int PageSize { set; get; }

        public DocumentConditionSearch()
        {
            this.Keyword = "";
            this.ClassId = 0;
            this.ProgramId = 0;
            this.DepartmentId = 0;
            this.DocumentTypeId = 0;
            this.StatusId = 0;
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }
}