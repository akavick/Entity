using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HwEntityLevikoffVictorP11015.Entities
{
    [Table("department")]
    public partial class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Stuff> Stuffs { get; set; } = new HashSet<Stuff>();

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}