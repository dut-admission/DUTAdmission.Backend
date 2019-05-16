using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private DataContext context = new DataContext();
        public void UpdateFile(DocumentDto documentDto, string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            int idStudent = context.Students.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag).Id;
            string url = FunctionCommon.SaveFile(documentDto.File, documentDto.DocumentId, documentDto.FileName);
            context.Documents.Where(x => x.StudentId == idStudent && !x.DelFlag).Update(x => new Database.Schema.Entity.Document
            {
                Url = url
            });
            context.SaveChanges();
        }
    }
}