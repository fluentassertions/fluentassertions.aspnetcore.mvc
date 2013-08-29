using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Mvc
{
    public class RedirectResultAssertions : ObjectAssertions
    {
        public RedirectResultAssertions(RedirectResult subject) : base(subject) { }

        public RedirectResultAssertions WithUrl(string expectedUrl)
        {
            WithUrl(expectedUrl, string.Empty, null);
            return this;
        }

        public RedirectResultAssertions WithUrl(string expectedUrl, string reason, string reasonArgs)
        {
            string actualUrl = (Subject as RedirectResult).Url;

            Execute.Assertion
                    .ForCondition(string.Equals(actualUrl, expectedUrl, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("Expected RedirectResult.Url to be {0}{reason} but was {1}", expectedUrl, actualUrl);

            return this;
        }

        public RedirectResultAssertions WithPermanent(bool expectedPermanent)
        {
            WithPermanent(expectedPermanent, string.Empty, null);
            return this;
        }

        public RedirectResultAssertions WithPermanent(bool expectedPermanent, string reason, string reasonArgs)
        {
            bool actualPermanent = (Subject as RedirectResult).Permanent;

            Execute.Assertion
                    .ForCondition(expectedPermanent == actualPermanent)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("Expected RedirectResult.Permanent to be {0}{reason} but was {1}", expectedPermanent, actualPermanent);

            return this;
        }
    }
}
