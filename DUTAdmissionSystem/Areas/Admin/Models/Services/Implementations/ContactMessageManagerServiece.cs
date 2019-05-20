﻿using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class ContactMessageManagerServiece: IContactMessageManagerServiece
    {
        private readonly DataContext context = new DataContext();
        public List<ContactMessageResponseDto> GetContactMessageList(ContactMessageConditionSearch conditionSearch)
        {
            // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
            if (conditionSearch == null)
            {
                conditionSearch = new ContactMessageConditionSearch();
            }

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(context.ContactMessages.Count(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.Email.Contains(conditionSearch.KeySearch) || x.FullName.Contains(conditionSearch.KeySearch))&&
                (conditionSearch.StatusId==0)||
                conditionSearch.StatusId!=0&&x.StatusId==conditionSearch.StatusId)))
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfContactMessager = context.ContactMessages.Where(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.Email.Contains(conditionSearch.KeySearch) || x.FullName.Contains(conditionSearch.KeySearch)) &&
                (conditionSearch.StatusId == 0) ||
                conditionSearch.StatusId != 0 && x.StatusId == conditionSearch.StatusId)))
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.NumberOfRecord)
                .Take(paging.NumberOfRecord).Select(x => new ContactMessageResponseDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    Message = x.Message,
                    StatusId = x.StatusId
                }).ToList();
            return listOfContactMessager;
        }

        public void UpdateContactMessage(UpdateContactMessage updateContactMessage)
        {
            context.ContactMessages.Where(x => x.Id == updateContactMessage.Id && !x.DelFlag).Update(x => new Database.Schema.Entity.ContactMessage
            {
                StatusId = updateContactMessage.StatusId
            });
        }
    }
}