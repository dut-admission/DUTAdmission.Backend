using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class SlideConditionSearch
    {
        [JsonProperty("key_search_for_title")]
        public string KeySearch { set; get; }

        [JsonProperty("current_page")]
        public int CurrentPage { set; get; }

        [JsonProperty("page_size")]
        public int PageSize { set; get; }

        public SlideConditionSearch()
        {
            this.KeySearch = "";
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }
}