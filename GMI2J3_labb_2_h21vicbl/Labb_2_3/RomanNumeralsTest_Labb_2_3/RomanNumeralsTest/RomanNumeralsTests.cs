using RomanNumeralsTest_Labb_2_3;

namespace RomanNumeralsTest_Labb_2_3
{
    public class Tests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Program.BuildLookupTables();
        }

        [TestCase(1,"I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(1000, "M")]
        public void TestFromRoman_KnownValues(int integer, string roman)
        {
            int result = Program.FromRoman(roman);
            int actual = integer;

            Assert.AreEqual(result, actual);
        }


        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(1000, "M")]
        public void TestToRoman_KnownValues(int integer, string roman)
        {
            string result = Program.ToRoman(integer);
            
            Assert.AreEqual(result, roman);
        }

        [TestCase(5000)]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestToRomanOutOfRange(int integer)
        {

            Assert.Throws<OutOfRangeError>(() => Program.ToRoman(integer));
        }


        [TestCase("MMMMM")]
        [TestCase("CMCM")]
        [TestCase("IIMXCC")]
        [TestCase("")]
        public void TestFromRomanInvalidRomanNumeralError(string roman)
        {
            Assert.Throws<InvalidRomanNumeralError>(() => Program.FromRoman(roman));
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void TestRoundTrip(int integer)
        {
            string roman = Program.ToRoman(integer);
            int NewInteger = Program.FromRoman(roman);

            Assert.That(NewInteger, Is.EqualTo(integer));
        }


    }

}