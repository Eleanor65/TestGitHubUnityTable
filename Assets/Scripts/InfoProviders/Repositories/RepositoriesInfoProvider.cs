using System;
using GitHubUnityTable.InfoDowloaders;
using Newtonsoft.Json.Linq;

namespace GitHubUnityTable.InfoProviders
{
    public class RepositoriesInfoProvider
    {
        private const string RepositoriesUrl = "https://api.github.com/users/{0}/repos";

        private readonly IInfoDownloader _downloader;

        public RepositoriesInfoProvider(IInfoDownloader downloader)
        {
            _downloader = downloader;
        }

        public void DownloadRepositoryInfos(string userName, Action<RepositoryInfo[]> onComplete)
        {
            var url = string.Format(RepositoriesUrl, userName);
            _downloader.DownloadInfo(url, response => OnDownloadedResponse(response, onComplete));
        }

        private void OnDownloadedResponse(string responseString, Action<RepositoryInfo[]> onComplete)
        {
            var jArray = JArray.Parse(responseString);
            var infos = new RepositoryInfo[jArray.Count];
            for (int i = 0; i < jArray.Count; i++)
            {
                infos[i] = jArray[i].ToRepositoryInfo();
            }

            onComplete(infos);
        }
    }
}