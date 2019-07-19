using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.Components
{
    public interface IFamilyMemberService
    {
        List<FamilyMember> GetFamilyMembers(int idUser);
        FamilyMember AddFamilyMember(FamilyMember result, int idUser);
        FamilyMember UpdateFamilyMember(FamilyMember result, int idUser);
        //bool DeleteFamilyMember(int idResult, int idUser);
    }
}
