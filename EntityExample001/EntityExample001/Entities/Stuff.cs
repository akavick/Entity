using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityExample001.Entities
{
    [Table("stuff")]
    public partial class Stuff : User
    {
        [Required, Index(IsUnique = true)]
        public int Number { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}