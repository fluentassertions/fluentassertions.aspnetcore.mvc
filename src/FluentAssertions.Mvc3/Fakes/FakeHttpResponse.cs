using System.Web;

namespace FluentAssertions.Mvc3.Fakes
{
    public class FakeHttpResponse : HttpResponseBase
    {
        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath;
        }
    }
}
