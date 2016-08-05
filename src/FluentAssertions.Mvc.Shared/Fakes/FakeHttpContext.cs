#if !NETSTANDARD1_6
using System;
using System.Web;

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

        class FakeHttpWorkerRequest : HttpWorkerRequest
        {
            public override string GetUriPath()
            {
                throw new NotImplementedException();
            }

            public override string GetQueryString()
            {
                throw new NotImplementedException();
            }

            public override string GetRawUrl()
            {
                throw new NotImplementedException();
            }

            public override string GetHttpVerbName()
            {
                throw new NotImplementedException();
            }

            public override string GetHttpVersion()
            {
                throw new NotImplementedException();
            }

            public override string GetRemoteAddress()
            {
                throw new NotImplementedException();
            }

            public override int GetRemotePort()
            {
                throw new NotImplementedException();
            }

            public override string GetLocalAddress()
            {
                throw new NotImplementedException();
            }

            public override int GetLocalPort()
            {
                throw new NotImplementedException();
            }

            public override void SendStatus(int statusCode, string statusDescription)
            {
                throw new NotImplementedException();
            }

            public override void SendKnownResponseHeader(int index, string value)
            {
                throw new NotImplementedException();
            }

            public override void SendUnknownResponseHeader(string name, string value)
            {
                throw new NotImplementedException();
            }

            public override void SendResponseFromMemory(byte[] data, int length)
            {
                throw new NotImplementedException();
            }

            public override void SendResponseFromFile(string filename, long offset, long length)
            {
                throw new NotImplementedException();
            }

            public override void SendResponseFromFile(IntPtr handle, long offset, long length)
            {
                throw new NotImplementedException();
            }

            public override void FlushResponse(bool finalFlush)
            {
                throw new NotImplementedException();
            }

            public override void EndOfRequest()
            {
                throw new NotImplementedException();
            }
        }
    }


}
#endif