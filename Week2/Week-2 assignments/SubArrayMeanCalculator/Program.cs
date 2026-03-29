using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubArrayMeanCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of elements and number of queries (N Q):");
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int numberOfElements = input[0];
            int numberOfQueries = input[1];

            Console.WriteLine("Enter the array elements:");
            long[] elements = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

            long[] prefixSum = PrefixSumCalculator.BuildPrefixSum(elements);

            Console.WriteLine("Enter the queries (L R):");
            for (int queryIndex = 0; queryIndex < numberOfQueries; queryIndex++)
            {
                int[] rangeInput = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int leftIndex = rangeInput[0];
                int rightIndex = rangeInput[1];

                long result = MeanCalculator.CalculateFloorMean(
                    prefixSum,
                    leftIndex,
                    rightIndex
                );

                Console.WriteLine(result);
            }
        }
    }

    class PrefixSumCalculator
    {
        public static long[] BuildPrefixSum(long[] elements)
        {
            int length = elements.Length;
            long[] prefixSum = new long[length + 1];
            prefixSum[0] = 0;

            for (int index = 1; index <= length; index++)
            {
                prefixSum[index] = prefixSum[index - 1] + elements[index - 1];
            }

            return prefixSum;
        }
    }

    class MeanCalculator
    {
        public static long CalculateFloorMean(long[] prefixSum, int leftIndex, int rightIndex)
        {
            long subarraySum = prefixSum[rightIndex] - prefixSum[leftIndex - 1];
            int subarrayLength = rightIndex - leftIndex + 1;

            return subarraySum / subarrayLength;
        }
    }
}
