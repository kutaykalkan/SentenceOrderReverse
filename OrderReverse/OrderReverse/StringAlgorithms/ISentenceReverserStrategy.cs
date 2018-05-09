using OrderReverse.Validation;

namespace OrderReverse
{
    public interface ISentenceReverserStrategy
    {
        string Reverse(string inputString, IInputStringValidator inputStringValidator);
    }
}
