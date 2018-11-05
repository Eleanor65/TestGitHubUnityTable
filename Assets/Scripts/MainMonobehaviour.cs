using GitHubUnityTable.InfoDowloaders;
using GitHubUnityTable.InfoProviders;
using UnityEngine;

namespace GitHubUnityTable
{
    public class MainMonobehaviour : MonoBehaviour
    {
        private const string UserName = "Eleanor65";

        private IInfoDownloader _downloader;

        private IInfoDownloader Downloader
        {
            get
            {
                return _downloader ?? (_downloader = //new FakeDownloader()
                           new GameObject("WWWDownloader", typeof(WWWInfoDownloader)).GetComponent<WWWInfoDownloader>()
                       );
            }
        }

        private void Start()
        {
            var repositoriesInfoProvider = new RepositoriesInfoProvider(Downloader);

            repositoriesInfoProvider.DownloadRepositoryInfos(UserName, infos =>
            {
                foreach (var repositoryInfo in infos)
                {
                    Debug.LogFormat("rep name = {0}, default_branch = {1}", repositoryInfo.Name,
                        repositoryInfo.DefaultBranch);

                }
                DownloadLastCommitsInfo(infos);
            });
        }

        private void DownloadLastCommitsInfo(RepositoryInfo[] repositories)
        {
            var commitInfoProvider = new CommitInfoProvider(Downloader);

            foreach (var repository in repositories)
            {
                commitInfoProvider.DownloadLastCommitInfo(UserName, repository.Name, PrintCommitInfo);
            }
        }

        private void PrintCommitInfo(CommitInfo commitInfo)
        {
            Debug.LogFormat("Commit sha = {0}, author = {1}, email = {2}, message = '{3}'", commitInfo.Sha,
                commitInfo.Author, commitInfo.Email, commitInfo.Message);
        }
    }
}