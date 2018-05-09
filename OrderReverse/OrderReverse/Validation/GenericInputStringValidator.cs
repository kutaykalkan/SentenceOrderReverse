using System;

namespace OrderReverse.Validation
{
    public class GenericInputStringValidator : IInputStringValidator
    {
        public void Validate(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                if(input == null)
                    throw new ArgumentNullException(nameof(input));
                throw new ArgumentException("WhiteSpace or empty strings are not allowed!");
            }
        }
    }
}
