using System.Collections.Generic;
using GitHubLogRecord.Models;
using GitHubLogRecord.Interfaces;
using System;

namespace GitHubLogRecord.Injectors
{
    public class GitHubMethod
    {
        private IGitHub _github;
        public GitHubMethod(IGitHub github) {
            _github = github;
        }

        public bool signIn(Credentials credentials) {
            try { 
                _github.signIn(credentials); 
                return false; 
            }
            catch (Exception e) { 
                return false; }
        }

        public List<string> scrape() {
            return _github.scrape();
        }
    }
}
