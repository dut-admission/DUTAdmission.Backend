using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public int ScreenId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
        public bool IsActived { get; set; }
        public bool IsToViewIndex { get; set; }

        public PermissionDto()
        {

        }

        public PermissionDto(int id, int screenId, string functionName, string functionDescription, bool isActived, bool isToViewIndex)
        {
            Id = id;
            ScreenId = screenId;
            FunctionName = functionName;
            FunctionDescription = functionDescription;
            IsActived = isActived;
            IsToViewIndex = isToViewIndex;
        }

        public PermissionDto(Permission permission)
        {
            Id = permission.Id;
            ScreenId = permission.FunctionInScreen.ScreenId;
            FunctionName = permission.FunctionInScreen.Name;
            FunctionDescription = permission.FunctionInScreen.Description;
            IsActived = permission.IsActived;
            IsToViewIndex = permission.FunctionInScreen.IsToViewIndex;
        }
    }
}