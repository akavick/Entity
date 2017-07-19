using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityExample001.Entities
{
    [Table("client")]
    public partial class Client : User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Index(IsUnique = true)]
        public Guid Code { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}