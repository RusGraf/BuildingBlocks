using System.Net;

namespace BuildingBlocks.Clients.Ftp
{
    public interface IFluentFtpClient
    {
        FluentFtpClient File(string filePath);
        FluentFtpClient Content(string contents);
        FluentFtpClient Content(byte[] contents);
        FluentFtpClient Gzip();
        FluentFtpClient Uri(string uri);
        FluentFtpClient Credentials(string userName, string password);
        FileWebResponse Upload();
    }
}
