using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos
{
    public class ContactMessageConditionSearch
    {
        public string KeySearch { set; get; }

        public int StatusId { get; set; }

        public int CurrentPage { set; get; }

        public int PageSize { set; get; }

        public ContactMessageConditionSearch()
        {
            this.StatusId = 0;
            this.KeySearch = "";
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }

    public class UpdateContactMessage
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}