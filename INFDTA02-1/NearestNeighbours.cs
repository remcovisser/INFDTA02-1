using System;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA021
{
    public class NearestNeighbours
    {
        Dictionary<int, Dictionary<int, double>> data;
        int user_id;
        double treshhold = 0.35;
        int k = 3;

        // Set the user properties
        public NearestNeighbours(Dictionary<int, Dictionary<int, double>> data, int user_id)
        {
            this.data = data;
            this.user_id = user_id;
        }


        private Dictionary<int, double> GetNearestNeighbours(Dictionary<int, double> similarities)
        {
            Dictionary<int, double> result = new Dictionary<int, double>();
            List<int> user_rated_products = data[user_id].Keys.ToList();

            for (int i = 1; i < data.Count; i++)
            {
                List<int> target_reated_products = data[i].Keys.ToList();
                if(similarities[i] > treshhold && !user_rated_products.SequenceEqual(target_reated_products))
                {
                    result[i] = similarities[i];
                }
            }
            return result.OrderByDescending(x => x.Value).Take(k).ToDictionary(pair => pair.Key, pair => pair.Value);
        }


        private void PrintResult(Dictionary<int, double> result)
        {
            int i = 1;
            foreach (KeyValuePair<int, double> rating in result)
            {
                Console.WriteLine("Nearest neighbour " + i + ": " + rating.Key + " with similarity " + rating.Value);
                i++;
            }
        }


        public void Pearson()
        {
            Dictionary<int, double> similarities = new Dictionary<int, double>();
            for (int i = 1; i < data.Count; i++)
            {
                if (i != user_id)
                {
                    similarities.Add(i, new Similarity(data[user_id], data[i]).Pearson());
                }
            }

            Console.WriteLine("Pearson");
            PrintResult(GetNearestNeighbours(similarities));
        }


        public void Cosine()
        {
            Dictionary<int, double> similarities = new Dictionary<int, double>();
            for (int i = 1; i < data.Count; i++)
            {
                if (i != user_id)
                {
                    similarities.Add(i, new Similarity(data[user_id], data[i]).Cosine());
                }
            }

            Console.WriteLine("Cosine");
            PrintResult(GetNearestNeighbours(similarities));
        }


        public void Euclidean()
        {
            Dictionary<int, double> similarities = new Dictionary<int, double>();
            for (int i = 1; i < data.Count; i++)
            {
                if (i != user_id)
                {
                    similarities.Add(i, new Similarity(data[user_id], data[i]).Euclidean());
                }
            }

            Console.WriteLine("Euclidean");
            PrintResult(GetNearestNeighbours(similarities));
        }

    }
}
