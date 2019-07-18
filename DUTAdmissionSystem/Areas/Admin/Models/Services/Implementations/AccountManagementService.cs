using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class AccountManagementService: IAccountManagementService
    {
        private readonly DataContext context = new DataContext();

        public List<AccountReponseDto> GetListAccount(AccountConditionSearch conditionSearch)
        {
            // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
            if (conditionSearch == null)
            {
                conditionSearch = new AccountConditionSearch();
            }

            // Lấy các thông tin dùng để phân trang
            var paging = new Paging(context.Accounts.Count(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.UserName.Contains(conditionSearch.KeySearch) || (x.UserInfo.FirstName+ x.UserInfo.LastName).Contains(conditionSearch.KeySearch)
                                                        || x.UserInfo.IdentityInfo.IdentityNumber.Contains(conditionSearch.KeySearch)))) &&
                (conditionSearch.GroupId==0 ||
                conditionSearch.GroupId!=0 && x.AccountGroupId==conditionSearch.GroupId))
                , conditionSearch.CurrentPage, conditionSearch.PageSize);

            // Tìm kiếm và lấy dữ liệu theo trang
            var listOfAccount = context.Accounts.Where(x => !x.DelFlag &&
                (conditionSearch.KeySearch == null ||
                (conditionSearch.KeySearch != null && (x.UserName.Contains(conditionSearch.KeySearch) || (x.UserInfo.FirstName + x.UserInfo.LastName).Contains(conditionSearch.KeySearch)
                                                        || x.UserInfo.IdentityInfo.IdentityNumber.Contains(conditionSearch.KeySearch)))) &&
                (conditionSearch.GroupId == 0 ||
                conditionSearch.GroupId != 0 && x.AccountGroupId == conditionSearch.GroupId))
                .OrderBy(x => x.Id)
                .Skip((paging.CurrentPage - 1) * paging.PageSize)
                .Take(paging.PageSize).Select(x => new AccountReponseDto
                {
                    Id = x.Id,
                    UserName =x.UserName,
                    FirstName =x.UserInfo.FirstName,
                    LastName =x.UserInfo.LastName,
                    IdentityNumber =x.UserInfo.IdentityInfo.IdentityNumber,
                    Email =x.UserInfo.ContactInfo.Email,
                    PhoneNumber =x.UserInfo.ContactInfo.PhoneNumber,
                    AccountGroupId =x.AccountGroupId,
                    AccountGroupName =x.AccountGroup.Name
                }).ToList();
            return listOfAccount;
        }

        public List<AccountLibraries> GetAccountLibraries()
        {
            
            return context.AccountGroups.Where(x=>!x.DelFlag).Select(x=>new AccountLibraries
            {
                Id=x.Id,
                Name=x.Name,
                Description=x.Description
            }).ToList();
        }
    }
}