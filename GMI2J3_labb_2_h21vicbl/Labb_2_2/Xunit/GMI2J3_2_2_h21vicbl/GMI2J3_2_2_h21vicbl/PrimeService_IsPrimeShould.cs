using static GMI2J3_2_2_h21vicbl.PrimeService;
using Xunit;

namespace GMI2J3_2_2_h21vicbl
{
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould() 
        {  
            _primeService = new PrimeService(); 
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValueLessThan2_ReturnFalse(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
}