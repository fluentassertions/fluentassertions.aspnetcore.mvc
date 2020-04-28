using System;
using System.Linq;

namespace FluentAssertions.Mvc.Tests.Helpers
{
    static class FailureMessageHelper
    {
        public const string Reason = "it is {0}";
        public readonly static object[] ReasonArgs = new[] { (object)10 };

        public static string Format(string message, params string[] args)
        {
            var formattedArg = args.Select(x => String.Format("\"{0}\"", x)).ToArray();

            return String.Format(message, formattedArg);
        }

        public static string ExpectedContextToBeXButY(string context, string expected, string actual)
        {
            return ExpectedContextToBeXButY(context, (object)$"\"{expected}\"", (object)$"\"{actual}\"");
        }

        public static string ExpectedContextToBeXButY(string context, DateTimeOffset? expected, DateTimeOffset? actual)
        {
            return ExpectedContextToBeXButY(context, ToString(expected), ToString(actual));
        }

        public static string ExpectedContextToBeXButY(string context, object expected, object actual)
        {
            return $"Expected {context} to be {expected} because it is 10 but found {actual}.";
        }

        public static string ExpectedAtKeyValueXButFoundY(string context, string key, string expected, string actual)
        {
            return $"Expected {context} to contain value \"{expected}\" at key \"{key}\" because it is 10 but found \"{actual}\".";
        }

        public static string ExpectedKeyButNotFound(string context, string key, string expected)
        {
            return $"Expected {context} to contain value \"{expected}\" at key \"{key}\" because it is 10, but the key was not found.";
        }

        private static object ToString(DateTimeOffset? expected)
        {
            if (expected.HasValue)
                return $"<{expected:yyyy-MM-dd HH:mm:ss.fffffff z}h>";
            else
                return "<null>";
        }

    }
}
