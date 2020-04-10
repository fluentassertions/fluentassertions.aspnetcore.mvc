using FluentAssertions.Common;
using FluentAssertions.Execution;
using System.Collections.Generic;

namespace FluentAssertions.AspNetCore.Mvc
{
    internal class AssertionHelpers
    {
        internal static void AssertStringObjectDictionary(
            IDictionary<string, object> dictionary, 
            string context,
            string key,
            object expectedValue,
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

                if (dictionary.TryGetValue(key, out object actual))
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
    }
}
