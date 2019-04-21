namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ErrorMsg")]
    public partial class ErrorMsg : TableHaveIdInt
    {
        public string Message { get; set; }
    }
}