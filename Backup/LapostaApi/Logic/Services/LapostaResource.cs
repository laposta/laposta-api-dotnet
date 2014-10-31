using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laposta.Entities;

namespace Laposta.Services
{
    public class LapostaResource
    {
        private string _resource;
        
        public LapostaResource(string resource)
        {
            this._resource = resource;
        }

   //     protected string Connect(string method = "GET", List<string> path = null, Dictionary<string, string> parameters = null, Dictionary<string, string> data = null)
        
        protected string Connect(string method , List<string> path , Dictionary<string, string> parameters , Dictionary<string, string> data )
        {
            // string method = "GET"
            // build uri
            var uri = this.GetBaseUri();

            // which resource?
            uri += "/" + this._resource;

            // add path, if it's there
            if (path != null)
            {
                uri += this.GetPath(path);
            }
            
            // add parameters, if needed
            if (parameters != null)
            {
                uri += this.GetParameters(parameters);
            }

            // format POST data, if needed
            var postData = "";
            if (data != null)
            {
                postData = this.GetPostData(data);
            }
            System.Diagnostics.Debug.WriteLine(postData);


            // url is complete; now connect to server
            //System.Diagnostics.Debug.WriteLine(uri);
            LapostaTuple result = LapostaRequest.Connect(uri, method, postData);

            // result contains statuscode and raw json result, but we only return the string
            return result.item2;
        }

        // add path to uri
        private string GetPath(List<string> path) {
            
            var uri = "";

            foreach (string part in path)
            {
                uri += "/" + System.Web.HttpUtility.UrlEncode(part);
            }
            
            return uri;
        }

        // add parameters to uri
        private string GetParameters(Dictionary<string, string> parameters)
        {

            var uri = "?";

            foreach (KeyValuePair<string, string> kvp in parameters)
            {
                uri += System.Web.HttpUtility.UrlEncode(kvp.Key) + "=" + System.Web.HttpUtility.UrlEncode(kvp.Value) + "&";
            }

            // remove last ampersand
            uri = uri.Remove(uri.Length - 1);
            
            return uri;
        }

        // assemble POST data string
        private string GetPostData(Dictionary<string, string> data)
        {

            var result = "";

            foreach (KeyValuePair<string, string> kvp in data)
            {
                result += System.Web.HttpUtility.UrlEncode(kvp.Key) + "=" + System.Web.HttpUtility.UrlEncode(kvp.Value) + "&";
            }

            // remove last ampersand
            result = result.Remove(result.Length - 1);

            return result;
        }

        private string GetBaseUri()
        {
            var uri = LapostaConfig.API_BASE_URI;

            if (LapostaConfig.https)
            {
                uri = "https://" + uri;
            }
            else
            {
                uri = "http://" + uri;
            }

            return uri;
        }
    }
}