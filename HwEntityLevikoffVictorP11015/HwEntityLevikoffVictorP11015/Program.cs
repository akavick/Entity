using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HwEntityLevikoffVictorP11015.Context;

namespace HwEntityLevikoffVictorP11015
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateAlwaysHwDataBase());
            //Database.SetInitializer(new DropCreateIfModelChangedHwDataBase());

            using (var db = new HwDataBase())
            {
                //db.Configuration.LazyLoadingEnabled = false;

                //db.Users.Load();
                //db.Clients.Load();
                //db.Departments.Load();
                //db.Stuffs.Load();
                //db.Products.Load();
                //db.Orders.Load();
                //db.OrderPositions.Load();

                Console.WriteLine("Получить Фамилию клиента с самым дорогим заказом:");
                db.Orders
                    .Select(o => new
                    {
                        o.Client.LastName,
                        Sum = o.Positions.Sum(op => op.Quantity * op.Product.Price)
                    })
                    .GroupBy(o => o.Sum)
                    .OrderByDescending(o => o.Key)
                    .FirstOrDefault()
                    ?.ToList()
                    .ForEach(o => Console.WriteLine($"{o.LastName,-15}{o.Sum} $"));
                Console.WriteLine();

                Console.WriteLine("Получить Фамилию сотрудника с наименьшим по стоимости заказом:");
                db.Orders
                    .Select(o => new
                    {
                        o.Stuff.LastName,
                        Sum = o.Positions.Sum(op => op.Quantity * op.Product.Price)
                    })
                    .GroupBy(o => o.Sum)
                    .OrderBy(o => o.Key)
                    .FirstOrDefault()
                    ?.ToList()
                    .ForEach(o => Console.WriteLine($"{o.LastName,-15}{o.Sum} $"));
                Console.WriteLine();

                Console.WriteLine("Получить стоимость среднего чека:");
                var query3 = db.Orders
                    .Select(o => o.Positions.Sum(op => op.Quantity * op.Product.Price))
                    .ToList();
                if (query3.Any())
                    Console.WriteLine(query3.Average());
                Console.WriteLine();

                Console.WriteLine("Вывести информацию сколько заказов было в каждом отделе:");
                db.Departments
                    .Select(d => new
                    {
                        d.Name,
                        Count = d.Stuffs.Select(s => s.Orders.Count).Sum()
                    })
                    .ToList()
                    .ForEach(o => Console.WriteLine($"{o.Name,-15}{o.Count,-10}"));
                Console.WriteLine();

                Console.WriteLine("Вывести заказы за последнюю неделю (база формируется рандомно! заказов таких может не быть!):");
                var date = DateTime.Now - TimeSpan.FromDays(7);
                db.Orders
                    .Where(o => o.Date > date)
                    .ToList()
                    .ForEach(o => Console.WriteLine(o.Description));
                Console.WriteLine();

                Console.WriteLine("Вывести наименование товаров заказа №4:");
                db.Orders
                    .SingleOrDefault(o => o.Id == 4)
                    ?.Positions
                    .ToList()
                    .ForEach(op => Console.WriteLine($"Товар: {op.Product.Name,-15} Количество: {op.Quantity,-10}"));
            }
        }
    }
}
