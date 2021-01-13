using System.Collections.Generic;
using GitHubLogRecord.Interfaces;
using GitHubLogRecord.Models;

namespace GitHubLogRecord.Services
{
    public class GitHub : IGitHub
    {
        public void signIn(Credentials credentials) {
            
        }
        public List<string> scrape() {
            return null;
        }
    }
}
