using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace HwEntityLevikoffVictorP11015.Entities
{
    [Table("order")]
    public partial class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Stuff Stuff { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string Description
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine($"�����:     {Id,-10} ����: {Date,-10} �����: {Positions.Select(p => p.Product.Price = p.Quantity).Sum()} $");
                sb.AppendLine($"������:    {Client.LastName,-15}{Client.FirstName,-15}{Client.SecondName,-15}");
                sb.AppendLine($"���������: {Stuff.LastName,-15}{Stuff.FirstName,-15}{Stuff.SecondName,-15}");
                foreach (var p in Positions)
                    sb.AppendLine($"\t�����: {p.Product.Name,-10} ����������: {p.Quantity,-10} �������: {p.Product.Unit}");

                return sb.ToString();
            }
        }

        public virtual ICollection<OrderPosition> Positions { get; set; } = new HashSet<OrderPosition>();
    }
}