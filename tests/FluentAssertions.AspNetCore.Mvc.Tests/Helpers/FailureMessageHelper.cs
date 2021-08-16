using FluentAssertions.Formatting;
using System;
using System.Globalization;
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

        public static string ExpectedContextToBeXButY(string context, object expected, object actual)
        {
            return $"Expected {context} to be {Formatter.ToString(expected)} because it is 10 but found {Formatter.ToString(actual)}.";
        }

        public static string ExpectedAtKeyValueXButFoundY(string context, string key, string expected, string actual)
        {
            return $"Expected {context} to contain value \"{expected}\" at key \"{key}\" because it is 10 but found \"{actual}\".";
        }

        public static string ExpectedKeyButNotFound(string context, string key, string expected)
        {
            return $"Expected {context} to contain value \"{expected}\" at key \"{key}\" because it is 10, but the key was not found.";
        }

        internal static string ExpectedToContainItemButFoundNull(string context, object item)
        {
            return $"Expected {context} to contain {Formatter.ToString(item)} because it is 10 but found <null>.";
        }

        internal static string ExpectedToHaveItemMatching(string context, object list, string predicate)
        {
            return $"Expected {context} {Formatter.ToString(list)} to have an item matching {predicate} because it is 10.";
        }

        internal static string ExpectedToContainItem(string context, object list, string expected)
        {
            return $"Expected {context} {Formatter.ToString(list)} to contain {Formatter.ToString(expected)} because it is 10.";
        }

        internal static string ExpectedContextTypeXButFoundY(string context, Type expected, Type actual)
        {
            return $"Expected {context} to be of type {Formatter.ToString(expected)} but was {Formatter.ToString(actual)}.";
        }

        internal static string ExpectedContextTypeXButFoundYWithReason(string context, Type expected, Type actual)
        {
            return $"Expected {context} to be of type {Formatter.ToString(expected)} but was {Formatter.ToString(actual)} because it is 10.";
        }

        internal static string ExpectedContextTypeXButFoundNull(string context, Type expectedType)
        {
            return $"Expected {context} to be of type {expectedType}, but no value was supplied.";
        }

        internal static string ExpectedContextToBeConvertible(string context, string expectedType, string actualType)
        {
            return $"Expected {context} to be convertible to {expectedType} but it was {actualType}.";
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

        public static string AuthenticationPropertiesExpectations(object containingObject)
        {
            var failureMessage = @"Expected " + containingObject.GetType().Name + @".AuthenticationProperties to be 

Microsoft.AspNetCore.Authentication.AuthenticationProperties
{
    AllowRefresh = <null>, 
    ExpiresUtc = <null>, 
    IsPersistent = False, 
    IssuedUtc = <null>, 
    Items = {empty}, 
    Parameters = {empty}, 
    RedirectUri = <null>
} because it is 10 but found 

Microsoft.AspNetCore.Authentication.AuthenticationProperties
{
    AllowRefresh = <null>, 
    ExpiresUtc = <null>, 
    IsPersistent = False, 
    IssuedUtc = <null>, 
    Items = {empty}, 
    Parameters = {empty}, 
    RedirectUri = <null>
}.";
            return failureMessage;
        }
    }
}
