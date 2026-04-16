using System;
using DivisorAssignment.Services;

namespace DivisorAssignment
{
    class Program
    {
        static void Main()
        {
            int testCaseCount = int.Parse(Console.ReadLine()!);

            IDivisorService divisorService = new DivisorService();

            while (testCaseCount-- > 0)
            {
                int maxNumber = int.Parse(Console.ReadLine()!);

                int result = divisorService.CountNumbersWithEqualAdjacentDivisors(maxNumber);

                Console.WriteLine(result);
            }
        }
    }
}