namespace BuildingBlocks.Providers.DateTime
{
    public class Utc : IUtc
    {
        public System.DateTime Now => System.DateTime.UtcNow;
    }
}