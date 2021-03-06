﻿using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
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
        public DocumentResponseDto UpdateFile(DocumentDto documentDto, string token,string host)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            int idStudent = context.Students.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag).Id;
            string url = FunctionCommon.SaveFile(documentDto.File, documentDto.DocumentId, documentDto.FileName);
            string urlFile = context.Documents.FirstOrDefault(x => x.Id == documentDto.DocumentId && x.StudentId == idStudent && !x.DelFlag).Url;
            string strUrl = host + "/" + url;
            var doc = context.Documents.FirstOrDefault(x => !x.DelFlag && x.Id == documentDto.DocumentId);
            context.Documents.Where(x => x.Id == documentDto.DocumentId && x.StudentId == idStudent && !x.DelFlag).Update(x => new Database.Schema.Entity.Document
            {
                Url = strUrl,
                FileName=documentDto.FileName,
                StatusId=2,
                DocumentTypeId = doc.DocumentTypeId
            });
            context.SaveChanges();
            FunctionCommon.DeleteFile(urlFile.Substring(host.Length, urlFile.Length - host.Length));
            return context.Documents.Where(x=>x.Id==documentDto.DocumentId && !x.DelFlag).Select(x => new DocumentResponseDto
            {
                Id = x.Id,
                DocumentTypeId = x.DocumentTypeId,
                DocumentTypeName = x.DocumentType.Name,
                Url = x.Url,
                StatusId = x.StatusId,
                StatusName = x.Status.Name,
                IsRequired = x.DocumentType.IsRequired,
                ResponseMessage = x.ResponseMessage,
                Description = x.DocumentType.Description,
                FileName = x.FileName
            }).FirstOrDefault();
        }

        public List<DocumentResponseDto> GetListDocument(string token)
        {
            int Id = JwtAuthenticationExtensions.ExtractTokenInformation(token).UserId;
            int idStudent = context.Students.FirstOrDefault(x => x.UserInfoId == Id && !x.DelFlag).Id;
            return context.Documents.Where(x => x.StudentId == idStudent && !x.DelFlag).Select(x => new DocumentResponseDto
            {
                Id = x.Id,
                DocumentTypeId = x.DocumentTypeId,
                DocumentTypeName = x.DocumentType.Name,
                Url = x.Url,
                StatusId = x.StatusId,
                StatusName = x.Status.Name,
                IsRequired = x.DocumentType.IsRequired,
                ResponseMessage=x.ResponseMessage,
                Description=x.DocumentType.Description,
                FileName=x.FileName
            }).ToList();
        }
    }
}