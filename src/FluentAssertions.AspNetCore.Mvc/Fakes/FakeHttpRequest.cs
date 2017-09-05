#if !NETSTANDARD1_6
using System.Web;
using System.Collections.Specialized;

namespace FluentAssertions.Mvc.Fakes
{
    public class FakeHttpRequest : HttpRequestBase
    {
        private string _appRelativePath;
        private string _appPath;

        public FakeHttpRequest(string appPath, string relativePath)
        {
            _appPath = appPath;
            _appRelativePath = fixRelativeUrl(relativePath);
        }

        private string fixRelativeUrl(string url)
        {
            if (url.StartsWith("/"))
                return "~" + url;

            if (!url.StartsWith("~/"))
                return "~/" + url;

            return url;
        }

        public override string ApplicationPath
        {
            get
            {
                return _appPath;
            }
        }

        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return _appRelativePath;
            }
        }

        public override string PathInfo
        {
            get
            {
                return string.Empty;
            }
        }

        public override NameValueCollection ServerVariables
        {
            get
            {
                return new NameValueCollection();
            }
        }
    }
}
#endif