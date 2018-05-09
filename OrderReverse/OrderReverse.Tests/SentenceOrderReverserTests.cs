using System;
using NUnit.Framework;
using OrderReverse.StringAlgorithms;
using OrderReverse.Validation;

namespace OrderReverse.Tests
{
    [TestFixture]
    public class SentenceOrderReverserTests
    {
        private readonly ISentenceReverserStrategy _sentenceReverserOptimal =
            new SentenceReverserOptimal(new MirrorReverse(new GenericInputStringValidator()),
                new GenericInputStringValidator());

        private readonly ISentenceReverserStrategy _sentenceReverserStack =
            new SentenceReverserStack(new GenericInputStringValidator());

        /// <summary>
        ///     Combined Order Reverser test cases. Decided not to separate test cases for this example for time constraints.
        ///     Otherwise, I would try to write my test cases with when-then style function names that will do single validation
        ///     each time.
        /// </summary>
        [TestCase("bob tom ron", ExpectedResult = "ron tom bob")]
        [TestCase("bob  tom ron", ExpectedResult = "ron tom  bob")]
        public string OrderReverserTestsCombinedOptimalStrategy(string input)
        {
            return _sentenceReverserOptimal.Reverse(input, new GenericInputStringValidator());
        }

        [TestCase("bob tom ron", ExpectedResult = "ron tom bob")]
        public string OrderReverserTestsCombinedStack(string input)
        {
            return _sentenceReverserStack.Reverse(input, new GenericInputStringValidator());
        }

        //Nunit does not support testcases when exception needs to be thrown. Thus, using Test.
        [Test]
        public void OrderReserverTestInputValidations()
        {
            //Case1
            var input = "";
            Exception exception = Assert.Throws<ArgumentException>(() =>
                _sentenceReverserOptimal.Reverse(input, new GenericInputStringValidator()));
            StringAssert.AreEqualIgnoringCase("WhiteSpace or empty strings are not allowed!", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
                _sentenceReverserStack.Reverse(input, new GenericInputStringValidator()));
            StringAssert.AreEqualIgnoringCase("WhiteSpace or empty strings are not allowed!", exception.Message);

            //Case2
            input = " ";
            exception = Assert.Throws<ArgumentException>(() =>
                _sentenceReverserOptimal.Reverse(input, new GenericInputStringValidator()));
            StringAssert.AreEqualIgnoringCase("WhiteSpace or empty strings are not allowed!", exception.Message);

            exception = Assert.Throws<ArgumentException>(() =>
                _sentenceReverserStack.Reverse(input, new GenericInputStringValidator()));
            StringAssert.AreEqualIgnoringCase("WhiteSpace or empty strings are not allowed!", exception.Message);
        }
    }
}