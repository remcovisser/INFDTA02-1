using System;
using System.Collections.Generic;

namespace INFDTA021
{
    public class Part1
    {
        private Dictionary<int, double> user1;
        private Dictionary<int, double> user2;

        // Set the user properties
        public Part1(Dictionary<int, double> user1, Dictionary<int, double> user2)
        {
            this.user1 = user1;
            this.user2 = user2;
        }


        // Parse the data for the Pearson coefficient, filter out the ratings which are not present for both users 
        private Tuple<List<double>, List<double>> PearsonParseRatings()
        {
            List<double> user1_parsed_ratings = new List<double>();
            List<double> user2_parsed_ratings = new List<double>();

            foreach (KeyValuePair<int, double> user1_ratings in user1)
            {
                foreach (KeyValuePair<int, double> user2_ratings in user2)
                {
                    if (user1_ratings.Key == user2_ratings.Key)
                    {
                        user1_parsed_ratings.Add(user1_ratings.Value);
                        user2_parsed_ratings.Add(user2_ratings.Value);
                    }
                }
            }
          
            return new Tuple<List<double>, List<double>>(user1_parsed_ratings, user2_parsed_ratings);
        }
      
        // Calculate the Pearson coefficient for user3 and user4 in the data set
        public double Pearson()
        {
            // Get the parsed data
            Tuple<List<double>, List<double>> parsed_ratings = this.PearsonParseRatings();
            List<double> user1_ratings = parsed_ratings.Item1;
            List<double> user2_ratings = parsed_ratings.Item2; 
            int n = user1_ratings.Count;

            // Set default values
            double sum_of_x = 0;
            double sum_of_y = 0;
            double sum_of_x_squared = 0;
            double sum_of_y_squared = 0;
            double sum_of_x_times_y = 0;

            // Calculate the values using sigma
            for (int i = 0; i < n; i++) 
            {
                sum_of_x += user1_ratings[i];
                sum_of_y += user2_ratings[i];
                sum_of_x_squared += user1_ratings[i] * user1_ratings[i];
                sum_of_y_squared += user2_ratings[i] * user2_ratings[i];
                sum_of_x_times_y += user1_ratings[i] * user2_ratings[i];
            }
          
            //  Calculate the rest of the values using the values from the loop
            double avarage_of_sum_of_y_squared = (sum_of_y * sum_of_y) / n;
            double avarage_of_sum_of_x_squared = (sum_of_x * sum_of_x) / n;
            double avarage_of_sum_of_x_times_sum_of_y = (sum_of_x * sum_of_y) / n;
                    
            // Calculate the final values
            double a = sum_of_x_times_y - avarage_of_sum_of_x_times_sum_of_y;
            double b = Math.Sqrt(sum_of_x_squared - avarage_of_sum_of_x_squared);
            double c = Math.Sqrt(sum_of_y_squared - avarage_of_sum_of_y_squared);

            // Calculate the result
            double result = a / (b * c);
            return result;
        }
    }
}
