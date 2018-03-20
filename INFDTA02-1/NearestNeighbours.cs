using System;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA021
{
    public class NearestNeighbours
    {
        Dictionary<int, Dictionary<int, double>> data;
        int user_id;
        int k;
        Dictionary<int, double> result;
        double treshhold = 0.35;

        // Set the user properties
        public NearestNeighbours(Dictionary<int, Dictionary<int, double>> data, int user_id, int k = 3)
        {
            this.data = data;
            this.user_id = user_id;
            this.k = k;
        }


        private Dictionary<int, double> GetNearestNeighbours(Dictionary<int, double> similarities)
        {
            Dictionary<int, double> result = new Dictionary<int, double>();
            List<int> user_rated_products = data[user_id].Keys.ToList();

            for (int i = 1; i < data.Count; i++)
            {
                List<int> target_reated_products = data[i].Keys.ToList();
                if(similarities.ContainsKey(i) && similarities[i] > treshhold && !user_rated_products.SequenceEqual(target_reated_products) )
                {
                    result[i] = similarities[i];
                }
            }
            return result.OrderByDescending(x => x.Value).Take(k).ToDictionary(pair => pair.Key, pair => pair.Value);
        }


        public void PrintResult()
        {
            int i = 1;
            foreach (KeyValuePair<int, double> rating in result)
            {
                Console.WriteLine("Nearest neighbour " + i + ": " + rating.Key + " with similarity " + rating.Value);
                i++;
            }
        }

        public Dictionary<int, double> GetResult()
        {
            return this.result;
        }


        public NearestNeighbours Pearson()
        {
            Dictionary<int, double> similarities = new Dictionary<int, double>();
            for (int i = 1; i < data.Count; i++)
            {
                if (i != user_id)
                {
                    similarities.Add(i, new Similarity(data[user_id], data[i]).Pearson());
                }
            }
            result = GetNearestNeighbours(similarities);

            return this;
        }


        public NearestNeighbours Cosine()
        {
            Dictionary<int, double> similarities = new Dictionary<int, double>();
            for (int i = 1; i < data.Count; i++)
            {
                if (i != user_id)
                {
                    similarities.Add(i, new Similarity(data[user_id], data[i]).Cosine());
                }
            }
            result = GetNearestNeighbours(similarities);

            return this;
        }


        public NearestNeighbours Euclidean()
        {
            Dictionary<int, double> similarities = new Dictionary<int, double>();
            for (int i = 1; i < data.Count; i++)
            {
                if (i != user_id)
                {
                    similarities.Add(i, new Similarity(data[user_id], data[i]).Euclidean());
                }
            }
            result = GetNearestNeighbours(similarities);

            return this;
        }

    }
}
