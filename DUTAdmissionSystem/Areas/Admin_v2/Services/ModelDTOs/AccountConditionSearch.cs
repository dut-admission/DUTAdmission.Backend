using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs
{
    public class AccountConditionSearch
    {
        public string KeySearch { set; get; }

        public int GroupId { get; set; }

        public int CurrentPage { set; get; }

        public int PageSize { set; get; }

        public AccountConditionSearch()
        {
            this.GroupId = 0;
            this.KeySearch = "";
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }
}