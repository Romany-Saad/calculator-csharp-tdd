using System;

namespace Calculator
{
    internal static class StringManipulation
    {
        internal static string[] SplitByLast(this string s, string delimiter)
        {
            var lastIndexOfDelimiter = s.LastIndexOf(delimiter, StringComparison.Ordinal);

            return lastIndexOfDelimiter < 0
                ? Array.Empty<string>()
                : new[]
                {
                    s[..lastIndexOfDelimiter],
                    s[(lastIndexOfDelimiter + delimiter.Length)..],
                };
        }

    }
}