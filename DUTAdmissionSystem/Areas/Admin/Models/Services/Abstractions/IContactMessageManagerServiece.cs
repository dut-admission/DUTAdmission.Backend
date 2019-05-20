using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions
{
    public interface IContactMessageManagerServiece
    {
        List<ContactMessageResponseDto> GetContactMessageList(ContactMessageConditionSearch conditionSearch);
        void UpdateContactMessage(int id,UpdateContactMessage updateContactMessage);
        void ReplyContactMessage(int id, ReplyContactMessage replyContactMessage);
    }
}
