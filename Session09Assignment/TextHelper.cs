using System.Text;

namespace Session09Assignment;

// =====================================================================
// Part 5 — Q9: TextHelper — Extension methods on string
// =====================================================================
// Extension methods MUST live in:
//   - a static, top-level (non-generic, non-nested) class
//   - the first parameter must be qualified with the `this` keyword
// =====================================================================

public static class TextHelper
{
    // BONUS STEP 1 — normal static method (NOT an extension method yet):
    //
    //   public static bool IsShorterThanNormal(string value, int length)
    //       => value.Length < length;
    //
    // Usage would have been:
    //   TextHelper.IsShorterThanNormal("Stethoscope", 5)
    //
    // BONUS STEP 2 — convert it to an extension method by adding `this`:

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
