using DUTAdmissionSystem.Database.Schema.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Models.Dtos.OutputDtos
{
    public class AdmissionNewsResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        public AdmissionNewsResponseDto()
        {

        }

        public AdmissionNewsResponseDto(int id, string title, string imageUrl, string summary, string content, DateTime? createdAt)
        {
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Summary = summary;
            Content = content;
            CreatedAt = createdAt;
        }

        public AdmissionNewsResponseDto(AdmissionNew admissionNew)
        {
            Id = admissionNew.Id;
            Title = admissionNew.Title;
            ImageUrl = admissionNew.ImageUrl;
            Summary = admissionNew.Summary;
            Content = admissionNew.Content;
            CreatedAt = admissionNew.CreatedAt;
        }
    }
}