using System;
using System.Collections.Generic;

namespace INFDTA021
{
    class MainClass
    {
        
        public static void Main(string[] args)
        {
            // --------------------- Part 1 ---------------------
            // Import the data from userItem.data
            var importer = new Importer();
            Dictionary<int, Dictionary<int, double>> data = importer.GetContent("userItem.data");


            // Peason coefficient
            Console.WriteLine("Pearson coefficient of similarity between users 10 and 11: " + new Part1(data[10], data[11]).Pearson());
            Console.WriteLine("Pearson coefficient of similarity between users 3 and 4: " + new Part1(data[3], data[4]).Pearson());


            Console.ReadLine();
        }
    }
}
