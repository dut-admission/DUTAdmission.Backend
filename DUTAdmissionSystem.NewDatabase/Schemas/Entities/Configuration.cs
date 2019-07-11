namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Configuration")]
    public partial class Configuration : TableHaveIdInt
    {
    }
}