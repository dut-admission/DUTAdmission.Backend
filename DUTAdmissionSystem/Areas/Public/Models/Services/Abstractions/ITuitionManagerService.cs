using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions
{
    public interface ITuitionManagerService
    {
        TuitionDetail GetTuitionDetail(string token);
    }
}
