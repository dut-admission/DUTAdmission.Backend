using System;
using System.Collections.Generic;
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
}