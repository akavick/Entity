using System;
using System.Linq;

namespace EfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var p = Seeder.GetRandomUserData();
                context.Persons.Add(p);

                //context.Persons.Remove(context.Persons.First());

                context.SaveChanges();
            }

        }
    }
}
/*
Add-Migration Initial
Update-Database
Add-Migration Initial2
Update-Database
 */
