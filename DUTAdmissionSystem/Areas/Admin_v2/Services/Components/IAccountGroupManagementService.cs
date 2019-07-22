using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.Components
{
    public interface IAccountGroupManagementService
    {
        List<AccountGroupResponse> GetListAccountGroups();
        AccountGroupResponse GetAccountGroupById(int id);
        AccountGroupResponse AddAccountGroup(AccountGroup accountGroup);
        AccountGroupResponse EditAccountGroup(AccountGroup accountGroup, int id);
        void DeleteAccountGroup(int id);
    }
}
