using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Laposta.Entities;

namespace Laposta.Services
{
    [Serializable]
    public class LapostaException : ApplicationException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public LapostaError LapostaError { get; set; }

        public LapostaException()
        {
        }

        public LapostaException(HttpStatusCode httpStatusCode, LapostaError lapostaError, string message)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
            LapostaError = lapostaError;
        }
    }
}