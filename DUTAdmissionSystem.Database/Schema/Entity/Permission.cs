namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission : TableHaveIdInt
    {
        public int AccountGroupId { get; set; }

        public int FunctionInScreenId { get; set; }

        public bool IsActived { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }

        public virtual FunctionInScreen FunctionInScreen { get; set; }
    }
}
