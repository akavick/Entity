using System;

namespace EfCoreBdFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EfCoreDBContext())
            {
                foreach (var person in context.Persons)
                {
                    Console.WriteLine(person.Id);
                }
            }
        }
    }
}
/*
Scaffold-DbContext "Server=SeaOfLove; Database=EfCoreDB; Trusted_Connection=true;" Microsoft.EntityFrameworkCore.SqlServer
 */
