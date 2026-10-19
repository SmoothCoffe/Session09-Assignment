using System.Text;

namespace Session09Assignment;
public static class TextHelper
{
    public static bool IsShorterThan(this string value, int length)
        => value.Length < length;

    public static string Repeat(this string value, int times)
    {
        if (times < 0)
            throw new ArgumentOutOfRangeException(nameof(times), "Times must be non-negative.");

        if (times == 0 || value.Length == 0)
            return string.Empty;

        // StringBuilder avoids O(n^2) string concatenation cost.
        var sb = new StringBuilder(value.Length * times);
        for (int i = 0; i < times; i++)
            sb.Append(value);
        return sb.ToString();
    }
}
