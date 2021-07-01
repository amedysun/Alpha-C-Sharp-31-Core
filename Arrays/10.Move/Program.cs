using System;
using System.Linq;
using System.Numerics;

namespace _10.Move
{
    class Program
    {
        const string commandForRight = "forward";
        const string commandForLeft = "backwards";
        static void Main(string[] args)
        {
            int currentIndex = int.Parse(Console.ReadLine());
            int[] sequenceOfNumbers = Console.ReadLine().Split(',')
                .Select(int.Parse).ToArray();

            BigInteger forwardsSum = 0;
            BigInteger backwardsSum = 0;
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "exit")
            {
                string[] parts = input.Split();
                int steps = int.Parse(parts[0]);
                string command = parts[1];
                int size = int.Parse(parts[2]);

                switch (command)
                {
                    case commandForRight:
                        for (int i = 0; i < steps; i++)
                        {

                            int currentSize = size;
                            while (currentSize > 0)
                            {
                                currentIndex++;
                                if (currentIndex > sequenceOfNumbers.Length - 1)
                                {
                                    currentIndex = 0;
                                }
                                currentSize--;
                            }
                            AddToSum(currentIndex, sequenceOfNumbers, ref forwardsSum, ref backwardsSum, command);
                        }
                        break;
                    case commandForLeft:
                        for (int i = 0; i < steps; i++)
                        {

                            int currentSize = size;
                            while (currentSize > 0)
                            {
                                currentIndex--;
                                if (currentIndex < 0)
                                {
                                    currentIndex = sequenceOfNumbers.Length - 1;
                                }
                                currentSize--;
                            }
                            AddToSum(currentIndex, sequenceOfNumbers, ref forwardsSum, ref backwardsSum, command);
                        }
                        break;
                    default:
                        break;

                }
            }

            Console.WriteLine($"Forward: {forwardsSum}");
            Console.WriteLine($"Backwards: {backwardsSum}");
        }

        private static void AddToSum(int currentIndex, int[] sequenceOfNumbers, ref BigInteger forwardsSum, ref BigInteger backwardsSum, string command)
        {
            if (command == commandForRight)
            {
                forwardsSum += sequenceOfNumbers[currentIndex];
            }
            else
            {
                backwardsSum += sequenceOfNumbers[currentIndex];
            }
        }
      }
    }
