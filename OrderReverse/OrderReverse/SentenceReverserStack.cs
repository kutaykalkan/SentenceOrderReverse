using System;
using System.Collections.Generic;
using System.Linq;
using OrderReverse.StringAlgorithms;
using OrderReverse.Validation;

namespace OrderReverse
{
    /// <summary>
    /// Sentence Order Reverser with Stack implementation.
    /// Can be used as an alternative when the spaces are equal btw words, and no spaces before/after the whole sentence.
    /// </summary>
    public class SentenceReverserStack : ISentenceReverserStrategy
    {
        private readonly IInputStringValidator _inputStringValidator;

        public SentenceReverserStack(GenericInputStringValidator genericInputStringValidator)
        {
            _inputStringValidator = genericInputStringValidator;
        }

        public string Reverse(string inputString, IInputStringValidator inputStringValidator)
        {
            var outputString = "";

            _inputStringValidator.Validate(inputString);

            Stack<string> wordStack = new Stack<string>(inputString.Split(' ').Select(o => o.Trim()));

            while (wordStack.Count > 0)
                outputString += wordStack.Pop() + ((wordStack.Count >= 1) ? " " : "");

            return outputString;
        }
    }
}
