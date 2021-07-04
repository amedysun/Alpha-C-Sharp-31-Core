using System;
using System.Linq;
using System.Text;

namespace _04.LongestBlockInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string longestRun = new string(text.Select((c, index) => text.Substring(index).TakeWhile(e => e == c))
                                    .OrderByDescending(e => e.Count())
                                    .First().ToArray());

            Console.WriteLine(longestRun);
        }
    }
}
