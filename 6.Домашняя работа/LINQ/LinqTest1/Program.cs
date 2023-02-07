using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinqTest1
{
    class Program
    {

        static void Main(string[] args)
        {
            LinqMethod3();
            LinqMethod1();
            LinqMethod2();
        }

        private static void LinqMethod1()
        {
            //массив - источник данных
            string[] countries = { "Albania","UK","Lithuania","Andorra",
                "Austria", "Latvia", "Liechtenstein", "Switzerland",
                "Ireland", "Sweden","Italy", "France","Liechtenstein",
                "Spain", "Turkey", "Germany", "Switzerland", "Monaco",
                "Montenegro", "Norway", "Finland", "Turkey", "UK",
                "Poland", "Portugal", "Lithuania", "Luxembourg"
                };
            //LINQ запрос
            var result = (from c in countries
                         where c.StartsWith("L")
                         //where c.Length > 10
                         orderby c.Length descending
                         select c).Distinct();

            Console.WriteLine("Countries beginning with L:");
            //продолжение работы с запросом
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
        }

        private static void LinqMethod2()
        {
            //массив - источник данных
            string[] countries = { "Albania","UK","Lithuania","Andorra",
                "Austria", "Latvia", "Liechtenstein", "Switzerland",
                "Ireland", "Sweden","Italy", "France","Liechtenstein",
                "Spain", "Turkey", "Germany", "Switzerland", "Monaco",
                "Montenegro", "Norway", "Finland", "Turkey", "UK",
                "Poland", "Portugal", "Lithuania", "Luxembourg"
                };
            //LINQ запрос
            var result = countries.OrderBy(c => c.Length).Where(c => c.StartsWith("L")).Distinct();

            Console.WriteLine("Countries beginning with L:");
            //продолжение работы с запросом
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nAggregate functions:\n");
            Console.WriteLine(result.Max());
            Console.WriteLine(result.Min());
            Console.WriteLine(result.Count());
            //Console.WriteLine(result.Average());
            //Console.WriteLine(result.Sum());
            
            Console.ReadLine();
        }

        delegate int del(int i);
        static void TestLambda()
        {
            del myDelegate = (x) => x * x;
            int sq = myDelegate(5); //sq = 25
        }

        private static void LinqMethod3()
        {
            //массив - источник данных
            string[] countries = { "Albania","UK","Lithuania","Andorra",
                "Austria", "Latvia", "Liechtenstein", "Switzerland",
                "Ireland", "Sweden","Italy", "France","Liechtenstein",
                "Spain", "Turkey", "Germany", "Switzerland", "Monaco",
                "Montenegro", "Norway", "Finland", "Turkey", "UK",
                "Poland", "Portugal", "Lithuania", "Luxembourg"
                };

            List<Product> products = new List<Product>();
            for (int i= 0; i<100; i++)
            {
                Thread.Sleep(5);
                products.Add(new Product { Name = "Product" + (++i),
                    Price = (new Random()).Next(0,1000),
                    Manufacturer = countries[(new Random()).Next(0, countries.Length - 1)],
                    Count = (new Random()).Next(0, 10) });
            }
            //Console.WriteLine("All products:");
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}

            //LINQ запрос
            //var result = from c in products
            //             where c.Price<500
            //             orderby c.Price 
            //             select new { c.Name, c.Price };

            var result = products.Where(p => p.Price > 800)
                .Select(p => new { p.Name, p.Price });

            Console.WriteLine("\nProducts with price greater than 800:");
            //продолжение работы с запросом
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total count:"+result.Count());
            Console.WriteLine("\nTop 5:\n");
            foreach (var item in result.Take(5))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nAfter top 5:\n");
            foreach (var item in result.Skip(5))
            {
                Console.WriteLine(item);
            }

            var pr = products.FirstOrDefault(p => p.Price > 500 &&
                p.Manufacturer.StartsWith("L"));
            Console.WriteLine("\nFirst:"+pr);
            Console.ReadLine();

        }
    }
}
