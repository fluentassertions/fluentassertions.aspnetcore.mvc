using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAssertions.Mvc3.Tests.Helpers
{
    static class FailureMessageHelper
    {
        public static string Format(string message, params string[] args)
        { 
            var formattedArg = args.Select(x => String.Format("\"{0}\"", x)).ToArray();

            return String.Format(message, formattedArg);
        }
    }
}
