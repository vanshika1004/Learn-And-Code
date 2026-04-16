using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DivisorAssignment.Services;


namespace DivisorAssignment.Tests
{
    public class DivisorServiceTests
    {
        private readonly IDivisorService _divisorService = new DivisorService();

        [Fact]
        public void CountNumbersWithEqualAdjacentDivisors_ShouldReturn2_ForInput15()
        {
            int result = _divisorService.CountNumbersWithEqualAdjacentDivisors(15);
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountNumbersWithEqualAdjacentDivisors_ShouldReturn0_ForSmallInput()
        {
            int result = _divisorService.CountNumbersWithEqualAdjacentDivisors(2);
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(3, 1)]
        [InlineData(5, 1)]
        [InlineData(10, 1)]
        public void CountNumbersWithEqualAdjacentDivisors_ShouldReturnExpectedValues(int input, int expected)
        {
            int result = _divisorService.CountNumbersWithEqualAdjacentDivisors(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountNumbersWithEqualAdjacentDivisors_ShouldHandleInvalidInput()
        {
            int result = _divisorService.CountNumbersWithEqualAdjacentDivisors(0);
            Assert.Equal(0, result);
        }
    }
}
