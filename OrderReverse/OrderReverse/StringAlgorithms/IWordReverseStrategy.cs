using System.Text;

namespace OrderReverse.StringAlgorithms
{
    public interface IWordReverseStrategy
    {
        string Reverse(StringBuilder input, int start, int end);
    }
}
