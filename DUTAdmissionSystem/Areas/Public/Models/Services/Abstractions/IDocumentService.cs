using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Public.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions
{
    public interface IDocumentService
    {
        DocumentResponseDto UpdateFile(DocumentDto documentDto, string token, string host);
        List<DocumentResponseDto> GetListDocument(string token);
    }
}
