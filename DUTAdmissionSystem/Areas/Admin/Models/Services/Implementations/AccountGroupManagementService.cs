using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class AccountGroupManagementService : IAccountGroupManagementService
    {
        private readonly DataContext db = new DataContext();

        public List<AccountGroupResponseDto> GetListAccountGroups()
        {
            return db.AccountGroups.Where(x => !x.DelFlag).ToList()
                .Select(x => new AccountGroupResponseDto(x)).ToList();
        }
    }
}