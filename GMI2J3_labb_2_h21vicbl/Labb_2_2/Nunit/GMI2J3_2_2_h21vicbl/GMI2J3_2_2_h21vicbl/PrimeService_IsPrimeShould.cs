using static GMI2J3_2_2_h21vicbl.PrimeService;

namespace GMI2J3_2_2_h21vicbl
{
    public class Tests
    {
        [TestFixture]
        public class PrimeService_IsPrimeShould
        {
            private PrimeService _primeService;

            [SetUp]
            public void SetUp()
            {
                _primeService = new PrimeService();
            }

            //[Test]
            [TestCase(-1)]
            [TestCase(0)]
            [TestCase(1)]
            public void IsPrime_ValueLessThan2_ReturnFalse(int value)
            {
                var result = _primeService.IsPrime(value);

                Assert.IsFalse(result, $"{value} should not be prime");
            }
        }
    }
}