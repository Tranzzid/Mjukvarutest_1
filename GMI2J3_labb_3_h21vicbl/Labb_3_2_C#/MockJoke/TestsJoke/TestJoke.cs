using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Joke;
using Moq;
using System.Runtime.Intrinsics.X86;

namespace Joke.Tests
{
    public  class TestJoke
    {
        
        
        [SetUp]
        [Test]
        public void TestLenJoke()
        {
            string TestJoke = "Du är ett skämt";
            var MockWebApi = new Mock<IWebApi>();

            MockWebApi.Setup(x => x.LenJoke(TestJoke)).Returns(15);
            int ActualLenght = MockWebApi.Object.LenJoke(TestJoke);

            Assert.AreEqual(15, ActualLenght);

            Console.WriteLine($"The joke is '{TestJoke}' and it's {ActualLenght} characters long");
        }

        [Test]
        public void TestGetJoke()
        {
            string TestJoke = "Vi alla är ett skämt";
            var MockWebApi = new Mock<IWebApi>();

            MockWebApi.Setup(x => x.GetJoke()).Returns(TestJoke);
            string ActualJoke = MockWebApi.Object.GetJoke();

            Assert.AreEqual(TestJoke, ActualJoke);

            Console.WriteLine($"The joke is '{TestJoke}' and it's a perfect match to '{ActualJoke}'");

        }
    }
    
}
