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


            //new NearestNeighbours(data, 7).Pearson().PrintResult();
            //new NearestNeighbours(data, 7).Cosine().PrintResult();
            //new NearestNeighbours(data, 7).Euclidean().PrintResult();


            // Given the 3 nearest neighbours of user 7 (computed with Pearson), predict the ratings that user 7 would give to items 101, 103, 106.
            Console.WriteLine("Predict the ratings that user 7 would give to items 101 = " + new PredictingRatings(data, 101, 7).Pearson());
            Console.WriteLine("Predict the ratings that user 7 would give to items 103 = " + new PredictingRatings(data, 103, 7).Pearson());
            Console.WriteLine("Predict the ratings that user 7 would give to items 106 = " + new PredictingRatings(data, 106, 7).Pearson());

            Console.WriteLine("Predict the ratings that user 4 would give to items 101 = " + new PredictingRatings(data, 101, 4).Pearson());


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
