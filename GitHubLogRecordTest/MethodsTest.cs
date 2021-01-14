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
            Credentials credential = new Credentials();
            credential.email = "gilbertalonzovillafuerte@gmail.com";
            credential.password = "060683vermilion";
            GitHubMethod method = new GitHubMethod(new GitHub());
            Task<int> test = method.signIn(credential);
            Task.WaitAll(test);
            Assert.AreEqual(200, test.Result);
        }

        [TestMethod]
        public void scrapeTest() {
            GitHubMethod method = new GitHubMethod(new GitHub());
            Assert.IsNotNull(method.scrape());
        }
    }
}
