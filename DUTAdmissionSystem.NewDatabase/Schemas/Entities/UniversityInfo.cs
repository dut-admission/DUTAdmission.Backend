namespace DUTAdmissionSystem.NewDatabase.Schema.Entity
{
    using DUTAdmissionSystem.NewDatabase.Schema.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UniversityInfo")]
    public partial class UniversityInfo : TableHaveIdInt
    {
        [Required]
        [StringLength(200)]
        public string UniversityName { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string Fax { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [StringLength(255)]
        public string Website { get; set; }
    }
}