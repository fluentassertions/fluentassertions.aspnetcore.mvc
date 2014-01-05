using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace FluentAssertions.Mvc.Fakes
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

        public override object GetService(Type serviceType)
        {
            return new FakeHttpWorkerRequest();
        }

        class FakeHttpWorkerRequest : SimpleWorkerRequest
        {
            public FakeHttpWorkerRequest()
                : base(null, null, new StringWriter())
            {

            }
        }
    }


}
