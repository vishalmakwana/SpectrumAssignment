using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SpectrumAssignment.Models.Request
{
    public class RequestBody
    {
        public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;
        public string Uri { get; set; }
        public object json { get; set; }
        public HttpResponseType ResponseType { get; set; } = HttpResponseType.Generic;
    }
    public enum HttpResponseType
    {
        Generic,
        String,
        Bool
    }
}
