using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitHubLogRecord.Injectors;
using GitHubLogRecord.Services;
using GitHubLogRecord.Models;

namespace GitHubLogRecordTest
{
    [TestClass]
    public class MethodsTest
    {
        [TestMethod]
        public void signInTest() {
            Credentials credential = new Credentials();
            GitHubMethod method = new GitHubMethod(new GitHub());
            Assert.IsTrue(method.signIn(credential));
        }

        [TestMethod]
        public void scrapeTest() {
            GitHubMethod method = new GitHubMethod(new GitHub());
            Assert.IsNotNull(method.scrape());
        }
    }
}
