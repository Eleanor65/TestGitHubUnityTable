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
                    result = Responses.RepositoriesResponse;
                    break;
                case "https://api.github.com/repos/Eleanor65/TestGitHubUnityTable/commits":
                    result = Responses.TestGitHubUnityTableCommitsResponse;
                    break;
                case "https://api.github.com/repos/Eleanor65/test-git-unity/commits":
                    result = Responses.TestGitUnityCommitsResponse;
                    break;
                default:
                    throw new Exception(string.Format("There is no response for url {0}", url));
            }

            onComplete(result);
        }
    }
}