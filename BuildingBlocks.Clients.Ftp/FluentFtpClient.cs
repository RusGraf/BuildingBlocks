using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace BuildingBlocks.Clients.Ftp
{
    public class FluentFtpClient : IFluentFtpClient
    {
        private string _uri;
        private byte[] _fileContentBytes;
        private NetworkCredential _credentials;

        public FluentFtpClient File(string filePath)
        {
            byte[] fileContents;

            using (var sourceStream = new StreamReader(filePath))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }

            _fileContentBytes = fileContents;

            return this;
        }

        public FluentFtpClient Content(string contents)
        {
            _fileContentBytes = Encoding.UTF8.GetBytes(contents);

            return this;
        }

        public FluentFtpClient Content(byte[] contents)
        {
            _fileContentBytes = contents;

            return this;
        }

        public FluentFtpClient Gzip()
        {
            using (var contentStream = new MemoryStream(_fileContentBytes))
            {
                using (var compressedDataStream = new MemoryStream())
                {
                    using (var gzipStream = new GZipStream(compressedDataStream, CompressionMode.Compress))
                    {
                        contentStream.CopyTo(gzipStream);
                    }
                    _fileContentBytes = compressedDataStream.ToArray();
                }
            }
            return this;
        }

        public FluentFtpClient Uri(string uri)
        {
            _uri = uri;

            return this;
        }

        public FluentFtpClient Credentials(string userName, string password)
        {
            _credentials = new NetworkCredential(userName, password);

            return this;
        }

        public FileWebResponse Upload()
        {
            var request = (FileWebRequest) WebRequest.Create(_uri);
            request.Method = WebRequestMethods.File.UploadFile;

            if (_credentials != null) request.Credentials = _credentials;
            request.ContentLength = _fileContentBytes.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(_fileContentBytes, 0, _fileContentBytes.Length);
            }

            return (FileWebResponse) request.GetResponse();
        }
    }
}
