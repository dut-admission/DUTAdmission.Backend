using DUTAdmissionSystem.Areas.Admin_v2.Services.ModelDTOs;
using DUTAdmissionSystem.NewDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.Admin_v2.Services.Components
{
    public class TuitionManagementService : ITuitionManagementService
    {

        private readonly DataContext context = new DataContext();

        public bool UpdateTutionInformation(TutionInformation tutionInfor, int idUser)
        {
            var student = context.Students.FirstOrDefault(x => x.Id == tutionInfor.IdStudent && !x.DelFlag);
            student.IsPaid = tutionInfor.IsPaid;
            context.Receipts.Add(new NewDatabase.Schema.Entity.Receipt()
            {
                CollectorUserId = idUser,
                PayerUserId = tutionInfor.IdStudent,
                Money = tutionInfor.Money,
                IsPaid = tutionInfor.IsPaid,
                Name = tutionInfor.Name,
                Description = tutionInfor.Description,
                CollectionDate = DateTime.Now
            });
            context.SaveChanges();
            return tutionInfor.IsPaid;
        }
    }
}