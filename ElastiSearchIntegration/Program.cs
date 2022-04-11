using System;

namespace ElastiSearchIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddNewIndexTest();

        }

        public static void AddNewIndexTest()
        {
            Elasticsearch objSearch = new Elasticsearch();

            objSearch.AddNewIndex(new City(1, "delhi", "delhi", "India", "9.879 million"));
            objSearch.AddNewIndex(new City(2, "mumbai", "Maharashtra", "India", "11.98 million"));
            objSearch.AddNewIndex(new City(3, "chennai", "Tamil Nadu", "India", "4.334 million"));
            objSearch.AddNewIndex(new City(4, "kolkata", "W. Bengal", "India", "4.573 million"));
            objSearch.AddNewIndex(new City(5, "Banglore", "Karnataka", "India", "4.302 million"));
            objSearch.AddNewIndex(new City(6, "Pune", "Maharashtra", "India", "2.538 million"));

            var result = objSearch.GetResult();
            var searchResult = objSearch.GetResult("chennai");
            Console.Write(result);
            Console.Read();
            Console.Read();
        }
    }

}
