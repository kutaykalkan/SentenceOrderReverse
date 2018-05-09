using System;
using System.Text;
using NUnit.Framework;
using OrderReverse.StringAlgorithms;
using OrderReverse.Validation;

namespace OrderReverse.Tests
{
    [TestFixture]
    public class MirrorReverseTests
    {
        private readonly MirrorReverse _mirrorReverse = new MirrorReverse(new GenericInputStringValidator());

        [TestCase("bob", ExpectedResult = "bob")]
        [TestCase("tom", ExpectedResult = "mot")]
        [TestCase("mama", ExpectedResult = "amam")]
        [TestCase("ma am", ExpectedResult = "ma am")]
        [TestCase("ma  am", ExpectedResult = "ma  am")]
        [TestCase(" ma  am", ExpectedResult = "ma  am ")]
        [TestCase("  tom", ExpectedResult = "mot  ")]
        [TestCase("123tom", ExpectedResult = "mot321")]
        [TestCase("makam", ExpectedResult = "makam")]
        [TestCase("a", ExpectedResult = "a")]
        [TestCase("Bac", ExpectedResult = "caB")]
        public string MirrorReverse(string input)
        {
            return _mirrorReverse.Reverse(new StringBuilder(input), 0, input.Length - 1);
        }

        [Test]
        public void OrderReserverTestInputValidations()
        {
            //Case1
            string input = "    ";
            Exception exception = Assert.Throws<ArgumentException>(() => _mirrorReverse.Reverse(new StringBuilder(input), 0, input.Length - 1));
            StringAssert.AreEqualIgnoringCase("WhiteSpace or empty strings are not allowed!", exception.Message);

            //Case2
            input = "";
            exception = Assert.Throws<ArgumentException>(() => _mirrorReverse.Reverse(new StringBuilder(input), 0, input.Length - 1));
            StringAssert.AreEqualIgnoringCase("WhiteSpace or empty strings are not allowed!", exception.Message);

            //Case3
            input = null;
            Assert.Throws<NullReferenceException>(() => _mirrorReverse.Reverse(new StringBuilder(input), 0, input.Length - 1));
        }
    }
}
