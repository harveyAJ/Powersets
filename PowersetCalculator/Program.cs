using System;
using System.Linq;

namespace PowersetCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your set (integers separated by space) e.g. 1 2 3 4 5:");

            //var set = new[] {1, 2, 3};
            //var list = new List<int>();
            //var set = list.ToArray(); 
            var userinput = Console.ReadLine()?.Split(' ');
            var set = (userinput ?? throw new ArgumentNullException()).Select(int.Parse).ToArray();
            
            Console.WriteLine();
            
            var subsets = SetsUtilities.Powerset(set);

            foreach (var combination in subsets)
            {
                Console.WriteLine($"{{{string.Join(",", combination)}}}");
            }
        }
    }
}
