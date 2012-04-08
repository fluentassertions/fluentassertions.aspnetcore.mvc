using System.Web;
using System.Collections.Specialized;

namespace FluentAssertions.Mvc3.Fakes
{
    public class FakeHttpRequest : HttpRequestBase
    {
        private string _appRelativePath;
        private string _appPath;

        public FakeHttpRequest(string appPath, string relativePath)
        {
            _appPath = appPath;
            _appRelativePath = relativePath;
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
