using DUTAdmissionSystem.Database.Schema.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos
{
    public class SlideResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("is_showing")]
        public bool IsShowing { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        public SlideResponseDto()
        {
        }

        public SlideResponseDto(int id, string title, string imageUrl,  string content, bool isShowing, string url, DateTime? createdAt)
        {
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            IsShowing = isShowing;
            Content = content;
            Url = url;
            CreatedAt = createdAt;
        }

        public SlideResponseDto(Slide slide)
        {
            Id = slide.Id;
            Title = slide.Title;
            ImageUrl = slide.ImageUrl;
            IsShowing = slide.IsShowing;
            Content = slide.Content;
            Url = slide.Url;
            CreatedAt = slide.CreatedAt;
        }
    }
}