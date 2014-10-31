using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using Laposta.Entities;

namespace Laposta.Services
{
    public static class LapostaRequest
    {
        public static LapostaTuple Connect(string uri, string method, string postData)
        {
            // assemble request
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.Headers.Add("Authorization", "Basic " + GetAuthorization());
            request.UserAgent = "Laposta .NET " + LapostaConfig.WRAPPER_VERSION;

            // add postdata, if given
            if (postData != "")
            {
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }

            // and execute; return statuscode and json string in Tuple
            return ExecuteWebRequest(request);
        }

        private static string GetAuthorization()
        {
            // api key in basic auth
            var auth = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(LapostaConfig.apiKey + ":"));
            return auth;
        }

        private static LapostaTuple ExecuteWebRequest(WebRequest webRequest)
        {
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {
                    return new LapostaTuple(
                        (int)response.StatusCode,
                        ReadStream(response.GetResponseStream())
                    );
                }
            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                {
                    // get response string and statuscode
                    var statusCode = ((HttpWebResponse)webException.Response).StatusCode;
                    var response = ReadStream(webException.Response.GetResponseStream());
                    //System.Diagnostics.Debug.WriteLine(response);

                    // convert to error object, and throw exception
                    var lapostaError = Mapper<LapostaError>.MapFromJson(response, "error");
                    throw new LapostaException(statusCode, lapostaError, lapostaError.Message);
                }

                throw;
            }

      //      return new LapostaTuple(0, "");
        }

        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}