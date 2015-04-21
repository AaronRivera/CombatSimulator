using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> beerList = new List<string> {"coors","bud", "blue moon", "left hand"};
            foreach (string beerName in beerList) 
            {
                Console.WriteLine(beerName);
            }

            Console.WriteLine("");

            List<string> letterBeer = beerList.Where(x => x.Length == 5).ToList<string>();

            foreach (string beer in letterBeer)
            {
                Console.WriteLine(beer);
            }


            Console.WriteLine("");

            foreach (string beer in beerList.Where(x => x.Contains("e")).Where(y => y.Length >2))
            {
                Console.WriteLine(beer);
            }
  

            Console.WriteLine("Longest");
            foreach(string longest in beerList.OrderByDescending(x=>x.Length).Skip(3))
            {
                Console.WriteLine(longest);
            }

            Console.WriteLine("count");

            Console.WriteLine(beerList.Count(x=>x.StartsWith("bud")));


            Console.ReadKey();
       }

        
    }
}
