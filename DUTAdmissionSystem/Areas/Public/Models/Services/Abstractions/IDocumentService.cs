using DUTAdmissionSystem.Areas.Public.Models.Dtos.InputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Public.Models.Services.Abstractions
{
    public interface IDocumentService
    {
        void UpdateFile(DocumentDto documentDto, string token);
    }
}
