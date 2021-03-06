﻿using DUTAdmissionSystem.Areas.Admin.Models.Dtos.InputDtos;
using DUTAdmissionSystem.Areas.Admin.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUTAdmissionSystem.Areas.Admin.Models.Services.Abstractions
{
    public interface IDocumentManagementService
    {
        DocumentResponseDto GetListDocuments(DocumentConditionSearch conditionSearch); 
        List<DocumentTypeDto> GetDocumentTypeList();

        Database.Schema.Entity.DocumentType AddDocumentType(DocumentTypeManagement documentTypeManagement);
        DocumentTypeDto EditDocumentType(DocumentTypeManagement documentTypeManagement,int id);
        void DeleteDocumentType(int id);
    }
}
