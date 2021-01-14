using System.Collections.Generic;
using GitHubLogRecord.Models;
using System.Threading.Tasks;

namespace GitHubLogRecord.Interfaces
{
    public interface IGitHub
    {
        Task<int> signIn(Credentials credentials);
        List<string> scrape();
    }
}
