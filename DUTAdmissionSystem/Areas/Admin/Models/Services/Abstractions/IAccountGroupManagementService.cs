using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions
{
    public interface IAccountGroupManagementService
    {
        List<AccountGroupResponseDto> GetListAccountGroups();
        AccountGroupResponseDto GetAccountGroupById(int id);
        AccountGroupResponseDto AddAccountGroup(AccountGroupDto accountGroup);
        AccountGroupResponseDto EditAccountGroup(AccountGroupDto accountGroup, int id);
        void DeleteAccountGroup(int id);
    }
}
