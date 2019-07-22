using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.Components
{
    public class AccountGroupManagementService : IAccountGroupManagementService
    {
        private readonly DataContext db = new DataContext();

        public AccountGroupResponse AddAccountGroup(AccountGroup _accountGroup)
        {
            var accountGroup= db.AccountGroups.Add(new NewDatabase.Schema.Entity.AccountGroup { Name = _accountGroup.Name, Description = _accountGroup.Description });
            db.SaveChanges();
            return new AccountGroupResponse(accountGroup);
        }

        public AccountGroupResponse EditAccountGroup(AccountGroup accountGroup, int id)
        {
            var accountGroupFromDb = db.AccountGroups.FirstOrDefault(x => !x.DelFlag && x.Id == id);
            accountGroupFromDb.Name = accountGroup.Name;
            accountGroupFromDb.Description = accountGroup.Description;
            db.SaveChanges();
            return new AccountGroupResponse(accountGroupFromDb);
        }

        public AccountGroupResponse GetAccountGroupById(int id)
        {
            var accountGroupFromdb = db.AccountGroups.FirstOrDefault(x => !x.DelFlag && x.Id == id);
            return accountGroupFromdb == null ? new AccountGroupResponse() : new AccountGroupResponse(accountGroupFromdb);
        }

        public List<AccountGroupResponse> GetListAccountGroups()
        {
            return db.AccountGroups.Where(x => !x.DelFlag && x.Id != 1 && x.Id != 2).ToList()
                .Select(x => new AccountGroupResponse(x)).ToList();
        }

        public void DeleteAccountGroup(int id)
        {
            var accountGroup = db.AccountGroups.FirstOrDefault(x => !x.DelFlag && x.Id == id);
            if (accountGroup != null)
            {
                accountGroup.DelFlag = true;
            }
            db.SaveChanges();
        }
    }
}