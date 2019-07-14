using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Models.Dtos.InputDtos
{
    public class UniversityInfo_2ConditionSearch
    {
        [JsonProperty("key_search_for_title")]
        public string KeySearch { set; get; }

        [JsonProperty("current_page")]
        public int CurrentPage { set; get; }

        [JsonProperty("page_size")]
        public int PageSize { set; get; }

        public UniversityInfo_2ConditionSearch()
        {
            this.KeySearch = "";
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }
}