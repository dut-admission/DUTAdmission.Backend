﻿using Newtonsoft.Json;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos
{
    public class AdmissionNewsConditionSearch
    {
        [JsonProperty("key_search_for_title")]
        public string KeySearch { set; get; }

        [JsonProperty("current_page")]
        public int CurrentPage { set; get; }

        [JsonProperty("page_size")]
        public int PageSize { set; get; }

        public AdmissionNewsConditionSearch()
        {
            this.KeySearch = "";
            this.PageSize = 10;
            this.CurrentPage = 1;
        }
    }
}