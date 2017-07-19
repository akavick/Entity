using System.Data.Entity;
using EntityExample001.Entities;

namespace EntityExample001.Context
{
    public partial class HwDataBase : DbContext
    {
        public HwDataBase() : base("name=HwDataBase")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Stuff> Stuffs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<OrderPosition> OrderPositions { get; set; }
    }
}