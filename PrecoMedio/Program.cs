using System;
using System.IO;
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
        }
    }
}
