using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAPIRestWithNest.Versioning
{
    public class SetVersionInResponseHeader<T> : IHttpActionResult where T : class
    {
        private HttpRequestMessage _request;
        private T _body;
        private string _version;
        private bool _willBeRetiredInNextVersion;
        private bool _isObsolete;

        public SetVersionInResponseHeader(HttpRequestMessage request, string version, T body, bool willBeRetiredInNextVersion = false, bool isObsolete = false)
        {
            _request = request;
            _version = version;
            _body = body;
            _isObsolete = isObsolete;
            _willBeRetiredInNextVersion = willBeRetiredInNextVersion;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(_body);
            response.Headers.Add("api-version", _version);
            if (_isObsolete) response.Headers.Add("api-version-obsolete", "THIS_VERSION_IS_OBSOLETE");
            if (_willBeRetiredInNextVersion) response.Headers.Add("api-version-retiring", "WILL_BE_RETIRED_IN_NEXT_VERSION");
            return Task.FromResult(response);
        }
    }
}