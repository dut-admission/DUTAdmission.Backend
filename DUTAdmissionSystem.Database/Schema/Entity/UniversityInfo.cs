namespace DUTAdmissionSystem.Database.Schema.Entity
{
    using DUTAdmissionSystem.Database.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UniversityInfo")]
    public partial class UniversityInfo : TableHaveIdInt
    {
        [StringLength(200)]
        public string UniversityName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(30)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Summary { get; set; }

        [StringLength(255)]
        public string Website { get; set; }
    }
}