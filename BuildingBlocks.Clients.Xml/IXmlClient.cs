namespace BuildingBlocks.Clients.Xml
{
    public interface IXmlClient
    {
        string PostXmlData(string destinationUrl, string requestXml);
    }
}
