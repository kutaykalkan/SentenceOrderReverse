using System;
using System.Text;
using OrderReverse.Validation;

namespace OrderReverse.StringAlgorithms
{
    /// <summary>
    /// In place reverse algorithm for words.
    /// </summary>
    public class MirrorReverse : IWordReverseStrategy
    {
        private readonly IInputStringValidator _inputStringValidator;

        public MirrorReverse(IInputStringValidator inputStringValidator)
        {
            _inputStringValidator = inputStringValidator;
        }
        public string Reverse(StringBuilder input, int start, int end)
        {
            _inputStringValidator.Validate(input.ToString());
            while (start < end)
            {
                char temp = input[start];
                input[start] = input[end];
                input[end] = temp;
                start++;
                end--;
            }
            return input.ToString();
        }
    }
}
