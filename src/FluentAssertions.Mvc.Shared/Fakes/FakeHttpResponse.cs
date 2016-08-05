#if !NETSTANDARD1_6
using System.Web;

namespace FluentAssertions.Mvc.Fakes
{
    public class FakeHttpResponse : HttpResponseBase
    {
        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath;
        }
    }
}
#endif