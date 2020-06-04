using System;
using System.Globalization;
using System.Linq;
using System.Text;

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

        public static string ExpectedContextToBeXButY(string context, Uri expected, Uri actual)
        {
            return ExpectedContextToBeXButY(context, expected?.ToString(), actual?.ToString());
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
            {
                var builder = new StringBuilder($"<{expected:yyyy-MM-dd HH:mm:ss}");
                if (expected.Value.Millisecond > 0)
                {
                    builder.AppendFormat(".{0:fffffff}", expected.Value);
                }
                if (expected.Value.Offset.Hours > 0)
                {
                    builder.AppendFormat(" +{0}h", expected.Value.Offset.Hours);
                }
                else if (expected.Value.Offset.Hours < 0)
                {
                    builder.AppendFormat(" -{0}h", expected.Value.Offset.Hours);
                }
                builder.Append('>');
                return builder.ToString();
            }
            return "<null>";
        }

        internal static string ExpectedContextTypeXButFoundY(string context, Type expected, Type actual)
        {
            return $"Expected {context} to be of type {expected.FullName} but was {actual.FullName}.";
        }

        internal static string ExpectedContextTypeXButFoundNull(string context, Type expectedType)
        {
            return $"Expected {context} to be of type {expectedType}, but no value was supplied.";
        }

        internal static string ExpectedContextContainValueAtKeyButFoundNull(string context, string value, string key)
        {
            return $"Expected {context} to contain value \"{value}\" at key \"{key}\" because it is 10, but it is <null>.";
        }

        internal static string ExpectedContextContainValueAtKeyButKeyNotFound(string context, string value, string key)
        {
            return $"Expected {context} to contain value \"{value}\" at key \"{key}\" because it is 10, but the key was not found.";
        }

        // DateTimeOffset is stored as string and converted back in ASP.NET Core Framework
        public static DateTimeOffset? RoundToSeconds(DateTimeOffset? value)
        {
            if (!value.HasValue)
                return null;

            var expectedIssuedUtcAsString = value.Value.ToString("r", CultureInfo.InvariantCulture);

            return DateTimeOffset.TryParseExact(expectedIssuedUtcAsString, "r", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result)
                ? new DateTimeOffset?(result)
                : new DateTimeOffset?();
        }
    }
}
