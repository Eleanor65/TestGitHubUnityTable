using System;
using GitHubUnityTable.InfoDowloaders;
using Newtonsoft.Json.Linq;

namespace GitHubUnityTable.InfoProviders
{
    public class RepositoriesInfoProvider
    {
        private const string RepositoriesInfoUrl = "https://api.github.com/users/Eleanor65/repos";

        private readonly IInfoDownloader _downloader;

        public RepositoriesInfoProvider(IInfoDownloader downloader)
        {
            _downloader = downloader;
        }

        public void DownloadRepositoryInfos(Action<RepositoryInfo[]> onComplete)
        {
            _downloader.DownloadInfo(RepositoriesInfoUrl, response => OnDownloadedResponse(response, onComplete));
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