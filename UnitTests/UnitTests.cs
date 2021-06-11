namespace Ceventas
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestNullEmptyStringEncodeDecode()
        {
            Controllers.UrlEncode urlEncode = new Controllers.UrlEncode();
            Assert.AreEqual("Please ensure that you send a properly defined url.", urlEncode.encode(""));
            Assert.AreEqual("Please ensure that you send a properly defined url.", urlEncode.decode(""));
        }
        [TestMethod]
        public void TestEncode()
        {
            Controllers.UrlEncode urlEncode = new Controllers.UrlEncode();
            Assert.IsNotNull(urlEncode.encode("https://www.google.com"));
            Assert.AreEqual("Please ensure that you send a properly defined url.", urlEncode.encode("test string"));
        }
        public void TestDecode()
        {
            Controllers.UrlEncode urlEncode = new Controllers.UrlEncode();
            Assert.IsNotNull(urlEncode.encode("https://www.google.com"));
            Assert.AreEqual("Please ensure that you send a properly defined url.", Encoder.decode("test string"));
            Assert.AreEqual("https://www.google.com", urlEncode.decode(urlEncode.encode("https://www.google.com")));
        }
        [TestMethod]
        public void TestCorrectValues()
        {
            Controllers.UrlEncode urlEncode = new Controllers.UrlEncode();
            var initialValue = "https://www.google.com";
            var encodedValue = urlEncode.encode(initialValue);
            Assert.IsNotNull(encodedValue);
            Assert.IsTrue(System.Uri.IsWellFormedUriString(encodedValue, System.UriKind.RelativeOrAbsolute));
            Assert.AreEqual(initialValue, urlEncode.decode(encodedValue));
        }
    }
}
