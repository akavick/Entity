using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HwEntityLevikoffVictorP11015.Entities
{
    [Table("product")]
    public partial class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual Department Department { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        public string Unit { get; set; }
    }
}