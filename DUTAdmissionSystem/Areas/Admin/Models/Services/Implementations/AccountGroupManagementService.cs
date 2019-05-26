using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Database;
using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class AccountGroupManagementService : IAccountGroupManagementService
    {
        private readonly DataContext db = new DataContext();

        public AccountGroupResponseDto AddAccountGroup(AccountGroupDto accountGroup)
        {
            var accountGroupdb = new AccountGroup { Name = accountGroup.Name, Description = accountGroup.Description };
            db.AccountGroups.Add(accountGroupdb);
            db.SaveChanges();
            return new AccountGroupResponseDto(accountGroupdb);
        }

        public AccountGroupResponseDto EditAccountGroup(AccountGroupDto accountGroup, int id)
        {
            var accountGroupFromDb = db.AccountGroups.FirstOrDefault(x => !x.DelFlag && x.Id == id);
            accountGroupFromDb.Name = accountGroup.Name;
            accountGroupFromDb.Description = accountGroup.Description;
            db.SaveChanges();
            return new AccountGroupResponseDto(accountGroupFromDb);
        }

        public AccountGroupResponseDto GetAccountGroupById(int id)
        {
            var accountGroupFromdb = db.AccountGroups.FirstOrDefault(x => !x.DelFlag && x.Id == id);
            return accountGroupFromdb == null ? new AccountGroupResponseDto() : new AccountGroupResponseDto(accountGroupFromdb);
        }

        public List<AccountGroupResponseDto> GetListAccountGroups()
        {
            return db.AccountGroups.Where(x => !x.DelFlag).ToList()
                .Select(x => new AccountGroupResponseDto(x)).ToList();
        }
    }
}