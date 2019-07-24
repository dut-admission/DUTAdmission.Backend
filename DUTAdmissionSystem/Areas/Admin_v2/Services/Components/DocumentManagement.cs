using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TblDocument = DUTAdmissionSystem.NewDatabase.Schema.Entity.Document;



namespace DUTAdmissionSystem.Areas.Admin_v2.Services.Components
{
    public class DocumentManagement: IDocumentManagement
    {
        private DataContext context = new DataContext();
        public List<Document> UpdateDocument(List<Document> documentReponses)
        {
            foreach(var documentReponse in documentReponses)
            {
                context.Documents.Where(x => x.Id == documentReponse.Id && !x.DelFlag).Update(x => new TblDocument
                {
                    IsSubmitted = documentReponse.IsSubmitted
                });
            }


            context.SaveChanges();

            return documentReponses;

        }
    }
}