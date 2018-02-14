using System;

namespace INFDTA021
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var importer = new Importer();
            var data = importer.GetContent("userItem.data");

            Console.WriteLine("Waiting!");
            Console.ReadLine();
        }
    }
}
