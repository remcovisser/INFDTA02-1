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
            Tuple<List<double>, List<double>> parsed_ratings = this.PearsonParseRatings();
            List<double> user1_ratings = parsed_ratings.Item1;
            List<double> user2_ratings = parsed_ratings.Item2;
            int ratings_count = user1_ratings.Count;

            // Top left
            double xy = 0;
            for (int i = 0; i < ratings_count; i++) 
            {
                xy += user1_ratings[i] * user2_ratings[i];
            }

            // Top Right
            double xx = 0;
            double yy = 0;
            for (int i = 0; i < ratings_count; i++)
            {
                xx += user1_ratings[i];
                yy += user2_ratings[i];
            }
            double xxyy = (xx * yy) / ratings_count;


            // Bottom left left
            double xxp = 0;
            for (int i = 0; i < ratings_count; i++)
            {
                xxp += user1_ratings[i] * user1_ratings[i];
            }

            // Bottom left right
            double xxpa = (xx * xx) / ratings_count;

            // Bottom right left
            double yyp = 0;
            for (int i = 0; i < ratings_count; i++)
            {
                yyp +=user2_ratings[i] * user2_ratings[i];
            }

            // Bottom right right
            double yypa = (yy * yy) / ratings_count;
                    
            double a = xy - xxyy;
            double b = Math.Sqrt(xxp - xxpa);
            double c = Math.Sqrt(yyp - yypa);


            double r = a / (b * c);
            return r;
        }
    }
}
