using System.Collections.Generic;
using GitHubLogRecord.Models;
using GitHubLogRecord.Interfaces;
using System;
using System.Threading.Tasks;

namespace GitHubLogRecord.Injectors
{
    public class GitHubMethod {
        private IGitHub _github;
        public GitHubMethod(IGitHub github) {
            _github = github;
        }

        public Task<int> signIn(Credentials credentials) {
            try {  return _github.signIn(credentials); }
            catch (Exception e) {
                string errorText = e.Message;
                return null; 
            }
        }

        public List<string> scrape() {
            return _github.scrape();
        }
    }
}
