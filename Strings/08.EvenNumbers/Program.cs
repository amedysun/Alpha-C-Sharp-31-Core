using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _08.EvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regexNumsPattern = @"[0-9]+";
            Regex rgx = new Regex(regexNumsPattern);

            List<int> nums = new List<int>();


            foreach (Match match in rgx.Matches(input))
            {
                nums.Add(int.Parse(match.Value));

            }

            int maxNum = -1;
            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    if (num > maxNum)
                    {
                        maxNum = num;
                    }
                }
            }

            Console.WriteLine(maxNum);
        }
    }
}
