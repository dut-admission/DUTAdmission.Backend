using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions;
using DUTAdmissionSystem.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Implementations
{
    public class PermissionManagementService : IPermissionManagementService
    {
        private readonly DataContext db = new DataContext();

        public List<PermissionResponseDto> GetListPermissions()
        {
            var list = db.AccountGroups
                .Where(x => !x.DelFlag && !x.Name.ToLower().Equals("student") && !x.Name.ToLower().Equals("admin")).ToList()
                .Select(x => new PermissionResponseDto(x, GetListScreensByAccountId(x.Id))).ToList();
            return list ?? new List<PermissionResponseDto>();
        }


        private List<PermissionDto> GetListPermissionsByScreenId(int id)
        {
            var list = db.Permissions.Include(x => x.FunctionInScreen).Where(x => !x.DelFlag && x.FunctionInScreen.ScreenId == id).ToList()
                .Select(x => new PermissionDto(x)).ToList();
            return list ?? new List<PermissionDto>();
        }
        private List<ScreenDto> GetListScreensByAccountId(int id)
        {
            var list = db.Permissions.Include(x => x.FunctionInScreen).Where(x => !x.DelFlag && x.AccountGroupId == id).ToList()
                .Select(x => new ScreenDto(x.FunctionInScreen.Screen, GetListPermissionsByScreenId(x.FunctionInScreen.ScreenId))).ToList();
            return list ?? new List<ScreenDto>();
        }
    }
}