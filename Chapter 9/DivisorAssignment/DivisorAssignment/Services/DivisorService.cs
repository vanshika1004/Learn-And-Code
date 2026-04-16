using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisorAssignment.Services
{
        public class DivisorService : IDivisorService
        {
            public int CountNumbersWithEqualAdjacentDivisors(int maxNumber)
            {
                if (maxNumber <= 2)
                    return 0;

                int[] divisorCounts = new int[maxNumber + 1];

                for (int currentDivisor = 1; currentDivisor <= maxNumber; currentDivisor++)
                {
                    for (int multiple = currentDivisor; multiple <= maxNumber; multiple += currentDivisor)
                    {
                        divisorCounts[multiple]++;
                    }
                }

                int validCount = 0;

                for (int currentNumber = 2; currentNumber < maxNumber; currentNumber++)
                {
                    if (divisorCounts[currentNumber] == divisorCounts[currentNumber + 1])
                    {
                        validCount++;
                    }
                }

                return validCount;
            }
        }
}
