using System;

namespace LACE.Domain.Extensions
{
    public static class GuardExtensions
    {
        public static TType Guard<TType>(this TType input, string name)
        {
            return input ?? throw new ArgumentNullException(name);
        }

        public static string GuardNullOrWhiteSpace(this string input, string name)
        {
            return input.IsNullOrWhitespace() ? throw new ArgumentNullException(name) : input;
        }
    }
}
