using System;
using System.IO;

namespace EfCore
{
    public static class Seeder
    {
        public static readonly string[] FirstNamesMan = File.ReadAllLines(@"..\..\..\Files\FirstNamesMan.txt");
        public static readonly string[] LastNamesMan = File.ReadAllLines(@"..\..\..\Files\LastNamesMan.txt");
        public static readonly string[] SecondNamesMan = File.ReadAllLines(@"..\..\..\Files\SecondNamesMan.txt");
        public static readonly string[] FirstNamesWoman = File.ReadAllLines(@"..\..\..\Files\FirstNamesWoman.txt");
        public static readonly string[] LastNamesWoman = File.ReadAllLines(@"..\..\..\Files\LastNamesWoman.txt");
        public static readonly string[] SecondNamesWoman = File.ReadAllLines(@"..\..\..\Files\SecondNamesWoman.txt");
        public static readonly string[] Addresses = File.ReadAllLines(@"..\..\..\Files\Cities.txt");
        public static readonly string[] ProductNames = File.ReadAllLines(@"..\..\..\Files\Products.txt");
        public static readonly Random Random = new Random();

        public static Person GetRandomUserData()
        {
            var sex = Random.NextDouble() > 0.5 ? Sex.Man : Sex.Woman;

            return new Person
            {
                Sex = sex,
                LastName = sex == Sex.Man 
                               ? LastNamesMan[Random.Next(LastNamesMan.Length)] 
                               : LastNamesWoman[Random.Next(LastNamesWoman.Length)],
                FirstName = sex == Sex.Man
                               ? FirstNamesMan[Random.Next(FirstNamesMan.Length)]
                               : FirstNamesWoman[Random.Next(FirstNamesWoman.Length)],
                SecondName = sex == Sex.Man
                               ? SecondNamesMan[Random.Next(SecondNamesMan.Length)]
                               : SecondNamesWoman[Random.Next(SecondNamesWoman.Length)],
                Address = Addresses[Random.Next(Addresses.Length)]
            };
        }
    }
}
