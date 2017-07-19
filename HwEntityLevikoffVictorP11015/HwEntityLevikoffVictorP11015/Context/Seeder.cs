using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HwEntityLevikoffVictorP11015.Entities;

namespace HwEntityLevikoffVictorP11015.Context
{
    public static class Seeder
    {
        private static readonly string[] FirstNamesMan = File.ReadAllLines(@"..\..\FirstNamesMan.txt");
        private static readonly string[] LastNamesMan = File.ReadAllLines(@"..\..\LastNamesMan.txt");
        private static readonly string[] SecondNamesMan = File.ReadAllLines(@"..\..\SecondNamesMan.txt");
        private static readonly string[] FirstNamesWoman = File.ReadAllLines(@"..\..\FirstNamesWoman.txt");
        private static readonly string[] LastNamesWoman = File.ReadAllLines(@"..\..\LastNamesWoman.txt");
        private static readonly string[] SecondNamesWoman = File.ReadAllLines(@"..\..\SecondNamesWoman.txt");
        private static readonly string[] Addresses = File.ReadAllLines(@"..\..\Cities.txt");
        private static readonly string[] ProductNames = File.ReadAllLines(@"..\..\Products.txt");
        private static readonly Random Rand = new Random();
        private static readonly int ClientsCount = 100;
        private static readonly int StuffsCount = 10;
        private static readonly int OrdersCount = 1000;
        private static readonly int MinPositios = 1;
        private static readonly int MaxPositios = 10;
        private static readonly int MinQuantity = 1;
        private static readonly int MaxQuantity = 100;
        private static readonly int ProductsCount = ProductNames.Length <= 500 ? ProductNames.Length : 500;
        private static readonly DateTime MinDate = new DateTime(TimeSpan.FromSeconds(63600000000).Ticks);
        private static readonly int DateDelta = Convert.ToInt32((DateTime.Now - MinDate).TotalSeconds);
        private static readonly string[] UnitNames =
        {
            "штука",
            "упаковка",
            "бутылка",
            "цисцерна",
            "вагон",
            "тележка",
            "банка",
            "килограмм",
            "ящик",
            "коробка"
        };


        private static void FillAnonymousList(List<dynamic> list, int count)
        {
            for (int i = 0;i < count;i++)
            {
                bool isMan = Rand.NextDouble() > 0.5;
                if (isMan)
                    list.Add(new
                    {
                        FirstName = FirstNamesMan[Rand.Next(FirstNamesMan.Length)],
                        SecondName = SecondNamesMan[Rand.Next(SecondNamesMan.Length)],
                        LastName = LastNamesMan[Rand.Next(LastNamesMan.Length)]
                    });
                else
                    list.Add(new
                    {
                        FirstName = FirstNamesWoman[Rand.Next(FirstNamesWoman.Length)],
                        SecondName = SecondNamesWoman[Rand.Next(SecondNamesWoman.Length)],
                        LastName = LastNamesWoman[Rand.Next(LastNamesWoman.Length)]
                    });
            }
        }


        public static void Seed(HwDataBase db)
        {
            var clientFios = new List<dynamic>();
            var stuffFios = new List<dynamic>();

            FillAnonymousList(clientFios, ClientsCount);
            FillAnonymousList(stuffFios, StuffsCount);

            var clients = new List<Client>();
            var stuffs = new List<Stuff>();
            var products = new List<Product>();
            var orders = new List<Order>();
            var departments = new List<Department>
            {
                new Department { Name = "Барахло", Number = 1 },
                new Department { Name = "Мусор", Number = 2 },
                new Department { Name = "Белиберда", Number = 3 },
                new Department { Name = "Абсурд", Number = 4 },
                new Department { Name = "Ерунда", Number = 5 }
            };

            db.Departments.AddRange(departments);

            for (int i = 0;i < ClientsCount;i++)
            {
                clients.Add(new Client
                {
                    FirstName = clientFios[i].FirstName,
                    LastName = clientFios[i].LastName,
                    SecondName = clientFios[i].SecondName,
                    Address = Addresses[Rand.Next(Addresses.Length)]
                });
            }

            db.Clients.AddRange(clients);

            for (int i = 0;i < StuffsCount;i++)
            {
                int num = Rand.Next();
                while (stuffs.Any(s => s.Number == num))
                    num = Rand.Next();
                stuffs.Add(new Stuff
                {
                    FirstName = stuffFios[i].FirstName,
                    LastName = stuffFios[i].LastName,
                    SecondName = stuffFios[i].SecondName,
                    Address = Addresses[Rand.Next(Addresses.Length)],
                    Department = departments[i % departments.Count],
                    Number = num
                });
            }

            db.Stuffs.AddRange(stuffs);

            for (int i = 0;i < ProductsCount;i++)
            {
                products.Add(new Product
                {
                    Name = ProductNames[Rand.Next(ProductNames.Length)],
                    Unit = UnitNames[Rand.Next(UnitNames.Length)],
                    Price = Rand.Next(1, 100000),
                    Department = departments[Rand.Next(departments.Count)]
                });
            }

            db.Products.AddRange(products);

            for (int i = 0;i < OrdersCount;i++)
            {
                var stuff = stuffs[Rand.Next(stuffs.Count)];
                var order = new Order
                {
                    Client = clients[Rand.Next(clients.Count)],
                    Stuff = stuff,
                    Date = new DateTime((MinDate + TimeSpan.FromSeconds(Rand.Next(DateDelta))).Ticks)
                };
                var depProducts = products.Where(p => p.Department == stuff.Department).ToList();
                var count = Rand.Next(MinPositios, MaxPositios + 1);
                for (int j = 0;j < count;j++)
                {
                    var product = depProducts[Rand.Next(depProducts.Count)];
                    while (order.Positions.Any(pos => pos.Product == product))
                        product = depProducts[Rand.Next(depProducts.Count)];
                    var position = new OrderPosition
                    {
                        Order = order,
                        Product = product,
                        Quantity = Rand.Next(MinQuantity, MaxQuantity)
                    };
                    order.Positions.Add(position);
                }
                orders.Add(order);
            }

            db.Orders.AddRange(orders);

            db.SaveChanges();
        }
    }
}
