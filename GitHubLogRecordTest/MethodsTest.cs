using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitHubLogRecord.Injectors;
using GitHubLogRecord.Services;
using GitHubLogRecord.Models;
using System.Threading.Tasks;

namespace GitHubLogRecordTest
{
    [TestClass]
    public class MethodsTest
    {
        [TestMethod]
        public void signInTest() {
            int statusCode = 200;
            Credentials credential = new Credentials();
            credential.email = "inset username here";
            credential.password = "insert password here";
            GitHubMethod method = new GitHubMethod(new GitHub());
            Task<int> test = method.signIn(credential);
            Task.WaitAll(test);
            Assert.AreEqual(statusCode, test.Result);
        }

        [TestMethod]
        public void scrapeTest() {
            GitHubMethod method = new GitHubMethod(new GitHub());
            Assert.IsNotNull(method.scrape());
        }
    }
}
