using System;

namespace LACE.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool EmptyInsensitiveEquals(this string input, string other, StringComparison comparison = StringComparison.Ordinal)
        {
            if (input.IsNullOrWhitespace() && other.IsNullOrWhitespace())
            {
                return true;
            }

            if (input.IsNullOrWhitespace() || other.IsNullOrWhitespace())
            {
                return false;
            }

            return input.Equals(other);
        }

        public static bool IsNullOrWhitespace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
    }
}
