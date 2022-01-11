using System;
using System.IO;
using System.Linq;
using PrecoMedio.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace PrecoMedio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Product> list = new List<Product>();

            using StreamReader sr = File.OpenText(path);

            while (!sr.EndOfStream)
            {
                string[] fildes = sr.ReadLine().Split(",");
                string name = fildes[0];
                double price = double.Parse(fildes[1], CultureInfo.InvariantCulture);
                list.Add(new Product(name, price));
            }

            var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Average price = " + avg.ToString("F2", CultureInfo.InvariantCulture));

            var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
