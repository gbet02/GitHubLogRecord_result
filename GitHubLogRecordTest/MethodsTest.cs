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
            GitHubMethod method = new GitHubMethod(new GitHub());
            Credentials credential = setTestCredentials();
            Task<int> test = executeSignInTest(method, credential);
            Assert.AreEqual(statusCode, test.Result);
        }

        private Task<int> executeSignInTest(GitHubMethod method, Credentials credential) {
            Task<int> test = method.signIn(credential);
            Task.WaitAll(test);
            return test;
        }

        private Credentials setTestCredentials() {
            Credentials credential = new Credentials();
            credential.email = "your test username here";
            credential.password = "your test password here";
            return credential;
        }

        [TestMethod]
        public void scrapeTest() {
            GitHubMethod method = new GitHubMethod(new GitHub());
            Assert.IsNotNull(method.scrape());
        }
    }
}
