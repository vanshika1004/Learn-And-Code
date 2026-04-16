using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisorAssignment.Services
{
        public interface IDivisorService
        {
            int CountNumbersWithEqualAdjacentDivisors(int maxNumber);
        }
}
