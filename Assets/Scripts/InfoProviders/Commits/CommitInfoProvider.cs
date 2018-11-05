using System;
using GitHubUnityTable.InfoDowloaders;
using Newtonsoft.Json.Linq;

namespace GitHubUnityTable.InfoProviders
{
    public class CommitInfoProvider
    {
        private const string CommitsUrl = "https://api.github.com/repos/{0}/{1}/commits";

        private readonly IInfoDownloader _downloader;

        public CommitInfoProvider(IInfoDownloader downloader)
        {
            _downloader = downloader;
        }

        public void DownloadLastCommitInfo(string userName, string repositoryName, Action<CommitInfo> onComplete)
        {
            var url = string.Format(CommitsUrl, userName, repositoryName);
            _downloader.DownloadInfo(url, s=> OnDownloadedResponse(s, onComplete));
        }

        private void OnDownloadedResponse(string response, Action<CommitInfo> onComplete)
        {
            var jToken = JArray.Parse(response)[0];
            var commitInfo = jToken.ToCommitInfo();
            onComplete(commitInfo);
        }
    }
}