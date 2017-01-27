using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuildingBlocks.Providers.DateTime.Unit.Tests
{
    [TestClass]
    public class UtcTest
    {
        [TestMethod]
        public void WhenNow_ThenReturnUtcNow()
        {
            var utc = new Utc();
            var utcsNow = utc.Now;
            Assert.AreEqual(utcsNow, System.DateTime.Now);
        }
    }
}
