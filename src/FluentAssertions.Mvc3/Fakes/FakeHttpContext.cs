using System.Web;

namespace FluentAssertions.Mvc3.Fakes
{
    public class FakeHttpContext : HttpContextBase
    {
        private FakeHttpRequest _request;
        private FakeHttpResponse _response;

        public FakeHttpContext(string appPath, string relativeUrl)
        {
            _request = new FakeHttpRequest(appPath, relativeUrl);
            _response = new FakeHttpResponse();
        }

        public override HttpRequestBase Request
        {
            get
            {
                return _request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return _response;
            }
        }
    }
}
