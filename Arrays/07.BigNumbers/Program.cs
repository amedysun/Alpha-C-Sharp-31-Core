using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _07.BigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayLenghts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int firstSize = arrayLenghts[0];
            int secondSize = arrayLenghts[1];

            BigInteger[] firstArray = CreateArray(firstSize);
            BigInteger[] secondArray = CreateArray(secondSize);

            BigInteger sumOfTheArrays = GetSum(firstArray, secondArray);

            Console.WriteLine(string.Join(" ", sumOfTheArrays.ToString().ToCharArray().Reverse().ToArray()));
        }

        private static BigInteger GetSum(BigInteger[] firstArray, BigInteger[] secondArray)
        {
            BigInteger firstArraysValue = TurnArrayToABigNumber(firstArray);
            BigInteger secondArraysValue = TurnArrayToABigNumber(secondArray);

            BigInteger summary = firstArraysValue + secondArraysValue;
            return summary;
        }

        private static BigInteger TurnArrayToABigNumber(BigInteger[] sequenceOfNumbers)
        {
            StringBuilder numberAsString = new StringBuilder();
            for (int i = 0; i < sequenceOfNumbers.Length; i++)
            {
                numberAsString.Append(sequenceOfNumbers[i].ToString());
            }

            return BigInteger.Parse(numberAsString.ToString());
        }

        private static BigInteger[] CreateArray(int size)
        {
            BigInteger[] sequenceOfNumbers = Console.ReadLine().Split(' ').Select(BigInteger.Parse)
                .Reverse().Take(size).ToArray();

            return sequenceOfNumbers;
        }

        private static BigInteger CreatingValue(string[] token1)
        {
            StringBuilder sb1 = new StringBuilder();
            foreach (string value in token1)
            {
                sb1.Append(value);
            }

            BigInteger value1 = BigInteger.Parse(sb1.ToString());

            return value1;
        }
    }
}
