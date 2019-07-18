namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ErrorMsg")]
    public partial class ErrorMsg : TableHaveIdInt
    {
        [Required]
        public string Message { get; set; }
    }
}