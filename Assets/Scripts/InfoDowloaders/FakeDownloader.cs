using System;

namespace GitHubUnityTable.InfoDowloaders
{
    public class FakeDownloader : IInfoDownloader
    {
        public void DownloadInfo(string url, Action<string> onComplete)
        {
            var result = string.Empty;

            switch (url)
            {
                case "https://api.github.com/users/Eleanor65/repos":
                    result = RepositoriesResponse.ResponseString;
                    break;
                default:
                    throw new Exception(string.Format("There is no response for url {0}", url));
            }

            onComplete(result);
        }
    }
}