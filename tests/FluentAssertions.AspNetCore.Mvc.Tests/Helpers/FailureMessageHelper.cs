using System;
using System.Linq;

namespace FluentAssertions.Mvc.Tests.Helpers
{
    static class FailureMessageHelper
    {
        public static string Format(string message, params string[] args)
        { 
            var formattedArg = args.Select(x => String.Format("\"{0}\"", x)).ToArray();

            return String.Format(message, formattedArg);
        }

        public static string ExpectedContextToBeXButY(string context, string expected, string actual)
        {
            return $"Expected {context} to be \"{expected}\" because it is 10 but found \"{actual}\".";
        }
    }
}
