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


            // Testing
            //Console.WriteLine("Pearson coefficient between users 7 and 1: " + new Similarity(data[7], data[1]).Pearson());
            //Console.WriteLine("Pearson coefficient between users 7 and 5: " + new Similarity(data[7], data[5]).Pearson());
            //Console.WriteLine("Pearson coefficient between users 7 and 4: " + new Similarity(data[7], data[4]).Pearson());
            //Console.WriteLine("Cosine between users 7 and 6: " + new Similarity(data[7], data[6]).Cosine());
            //Console.WriteLine("Cosine between users 7 and 2: " + new Similarity(data[7], data[2]).Cosine());
            //Console.WriteLine("Cosine between users 7 and 5: " + new Similarity(data[7], data[5]).Cosine());
            //Console.WriteLine("Euclidean between users 7 and 5: " + new Similarity(data[7], data[5]).Euclidean());
            //Console.WriteLine("Euclidean between users 7 and 3: " + new Similarity(data[7], data[3]).Euclidean());
            //Console.WriteLine("Euclidean between users 7 and 4: " + new Similarity(data[7], data[4]).Euclidean());


            new NearestNeighbours(data, 7).Pearson();
            new NearestNeighbours(data, 7).Cosine();
            new NearestNeighbours(data, 7).Euclidean();


            // Find the Pearson coefficient of similarity between users 3 and 4.

            /*
             * Find the 3 nearest neighbours of user 7 (with initial similarity threshold 0.35)
             */
            // Pearson coefficient
         
            // Cosine
            // Euclidean



            Console.ReadLine();
        }
    }
}
