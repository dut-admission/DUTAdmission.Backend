using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public interface IHighSchoolResultService
    {
        List<HighSchoolResult> GetHighSchoolResults(int idUser);
        HighSchoolResult AddHighSchoolResult(HighSchoolResult result, int idUser);
        HighSchoolResult UpdateHighSchoolResult(HighSchoolResult result, int idUser);
        bool DeleteHighSchoolResult(int idUser, int highSchoolYearId);
    }
}
