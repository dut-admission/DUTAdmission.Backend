using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions
{
    public interface ITuitionManagementService
    {
        TuitionResponseDto GetTuitionListResponse(TuitionConditionSearch conditionSearch);
        LibrariesOfTuition GetLibraries();
        List<TuitionTypes> GetTuitionTypeList();

        Database.Schema.Entity.TuitionType AddTuitionType(TuitionTypeManagement tuitionTypeManagement);
        TuitionTypes EditTuitionType(TuitionTypeManagement tuitionTypeManagement,int id);
        void DeleteTuitionType(int id);
    }
}
