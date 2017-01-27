using System.IO;
using System.Net;
using System.Text;

namespace BuildingBlocks.Clients.Xml
{
    public class XmlClient : IXmlClient
    {
        public string PostXmlData(string destinationUrl, string requestXml)
        {
            var response = GetResponse(requestXml, destinationUrl);
            return response.StatusCode != HttpStatusCode.OK ? null : GetResponseString(response);
        }

        private static HttpWebRequest GetRequest(string url, long contentLength)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = contentLength;
            request.Method = "POST";

            return request;
        }

        private static HttpWebResponse GetResponse(string xml, string url)
        {
            var bytes = Encoding.ASCII.GetBytes(xml);
            var request = GetRequest(url, bytes.Length);
            var requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            return (HttpWebResponse)request.GetResponse();
        }

        private static string GetResponseString(WebResponse response)
        {
            var responseStream = response.GetResponseStream();
            if (responseStream == null) return "Didnt got a response.";
            var responseStr = new StreamReader(responseStream).ReadToEnd();
            return responseStr;
        }
    }
}
