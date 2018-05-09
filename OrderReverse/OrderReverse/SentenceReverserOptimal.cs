using System.Text;
using OrderReverse.StringAlgorithms;
using OrderReverse.Validation;

namespace OrderReverse
{
    /// <summary>
    /// Time and space efficient optimal algorithm for reversing sentences.
    /// </summary>
    public class SentenceReverserOptimal : ISentenceReverserStrategy
    {
        private readonly IWordReverseStrategy _reverserStrategy;
        private readonly IInputStringValidator _inputStringValidator;

        public SentenceReverserOptimal(IWordReverseStrategy reverserStrategy, IInputStringValidator inputStringValidator)
        {
            _reverserStrategy = reverserStrategy;
            _inputStringValidator = inputStringValidator;
        }
        public string Reverse(string inputString, IInputStringValidator inputStringValidator)
        {
            _inputStringValidator.Validate(inputString);
            StringBuilder outputString = new StringBuilder(_reverserStrategy.Reverse(new StringBuilder(inputString), 0, inputString.Length - 1));

            int start = 0;
            int end = inputString.Length - 1;
            bool flag = false;//to identify if we are already traversing a word.
            for (int i = 0; i < outputString.Length; i++)
            {
                if (!flag)
                {
                    if (outputString[i] != ' ')
                    {
                        start = i;
                        end = i;
                        flag = true;
                    }
                }
                else
                {
                    if (i + 1 < outputString.Length && outputString[i + 1] == ' ')//end of word
                    {
                        end = i;
                        _reverserStrategy.Reverse(outputString, start, end);
                        flag = false;
                    }
                    else if (i + 1 == outputString.Length)//end of string
                    {
                        end = i;
                        _reverserStrategy.Reverse(outputString, start, end);
                        flag = false;
                    }
                }
            }

            return outputString.ToString();
        }
    }
}
