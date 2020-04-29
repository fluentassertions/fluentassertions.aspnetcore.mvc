using FluentAssertions.Common;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace FluentAssertions.AspNetCore.Mvc
{
    internal class AssertionHelpers
    {
        internal static void AssertStringObjectDictionary<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary, 
            string context,
            TKey key,
            TValue expectedValue,
            string reason,
            object[] reasonArgs)
        {
            using (var scope = new AssertionScope(context))
            {
                if (dictionary is null)
                {
                    Execute.Assertion
                        .BecauseOf(reason, reasonArgs)
                        .FailWith("Expected {context} to contain value {0} at key {1}{reason}, but it is {2}.", expectedValue, key,
                            dictionary);
                }

                if (dictionary.TryGetValue(key, out TValue actual))
                {
                    Execute.Assertion
                        .BecauseOf(reason, reasonArgs)
                        .ForCondition(actual.IsSameOrEqualTo(expectedValue))
                        .FailWith("Expected {context} to contain value {0} at key {1}{reason} but found {2}.", expectedValue, key, actual);
                }
                else
                {
                    Execute.Assertion
                        .BecauseOf(reason, reasonArgs)
                        .FailWith("Expected {context} to contain value {0} at key {1}{reason}, but the key was not found.", expectedValue,
                            key);
                }
            }
        }

        internal static DateTimeOffset? RoundToSeconds(DateTimeOffset? expectedIssuedUtc)
        {
            var expectedIssuedUtcAsString = expectedIssuedUtc?.ToString("r", CultureInfo.InvariantCulture);

            var expectedResult = DateTimeOffset.TryParseExact(expectedIssuedUtcAsString, "r", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result)
                ? new DateTimeOffset?(result)
                : new DateTimeOffset?();
            return expectedResult;
        }

    }
}
