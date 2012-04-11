using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FluentAssertions.Assertions;

namespace FluentAssertions.Mvc3
{
    public class RedirectResultAssertions : ReferenceTypeAssertions<RedirectResult, RedirectResultAssertions>
    {
        public RedirectResultAssertions(RedirectResult subject)
        {
            Subject = subject;
        }

        public RedirectResultAssertions HaveUrl(string expectedUrl)
        {
            HaveUrl(expectedUrl, string.Empty, null);
            return this;
        }

        public RedirectResultAssertions HaveUrl(string expectedUrl, string reason, string reasonArgs)
        {
            Execute.Verification
                    .ForCondition(string.Equals(Subject.Url, expectedUrl, StringComparison.InvariantCultureIgnoreCase))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("Expected RedirectResult.Url to be '{0}' but was '{1}'", expectedUrl, Subject.Url);

            return this;
        }

        public RedirectResultAssertions HavePermanent(bool expectedPermanent)
        {
            HavePermanent(expectedPermanent, string.Empty, null);
            return this;
        }

        public RedirectResultAssertions HavePermanent(bool expectedPermanent, string reason, string reasonArgs)
        {
            Execute.Verification
                    .ForCondition(expectedPermanent == Subject.Permanent)
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("Expected RedirectResult.Permanent to be '{0}' but was '{1}'", expectedPermanent, Subject.Permanent);

            return this;
        }
    }
}
