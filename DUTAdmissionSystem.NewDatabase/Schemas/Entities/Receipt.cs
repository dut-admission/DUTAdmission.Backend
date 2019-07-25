using DUTAdmissionSystem.NewDatabase.Schema.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    public class Receipt: TableHaveIdInt
    {
        public int CollectorUserId { get; set; }
        public int PayerUserId { get; set; }
        public decimal Money { get; set; }
        public bool IsPaid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CollectionDate { get; set; }
        public virtual UserInfo Collector { get; set; }
        public virtual UserInfo Payer { get; set; }

    }
}