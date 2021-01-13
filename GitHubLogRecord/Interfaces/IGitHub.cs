using System.Collections.Generic;
using GitHubLogRecord.Models;

namespace GitHubLogRecord.Interfaces
{
    public interface IGitHub
    {
        void signIn(Credentials credentials);
        List<string> scrape();
    }
}
