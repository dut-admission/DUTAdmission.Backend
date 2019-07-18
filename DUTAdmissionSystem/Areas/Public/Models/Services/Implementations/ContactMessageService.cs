using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions;
using DUTAdmissionSystem.Database;
using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Implementations
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly DataContext db = new DataContext();

        public bool SubmitContactMessage(ContactMessageDto dto)
        {
            var contactMessage = new ContactMessage { FullName = dto.FullName, Email = dto.Email, Message = dto.Message, StatusId = 1 };
            db.ContactMessages.Add(contactMessage);
            db.SaveChanges();
            return true;
        }
    }
}