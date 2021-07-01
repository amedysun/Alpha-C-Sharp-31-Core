using System;
using System.Linq;

namespace _01.ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ",(Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse())));
        }
    }
}
