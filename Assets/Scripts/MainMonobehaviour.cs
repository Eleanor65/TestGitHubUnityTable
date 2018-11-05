using System.Linq;
using GitHubUnityTable.InfoDowloaders;
using GitHubUnityTable.InfoProviders;
using GitHubUnityTable.Save;
using GitHubUnityTable.Ui;
using UnityEngine;

namespace GitHubUnityTable
{
    public class MainMonobehaviour : MonoBehaviour
    {
        private const string UserName = "Eleanor65";

        [SerializeField]
        private RepositoriesTableView _repositoriesTableView;

        private IInfoDownloader _downloader;
        private Saves _saves;
        private RepositoriesInfoSave _repositoriesInfoSave;

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
            _saves = new Saves();
            _repositoriesInfoSave = _saves.RepositoriesInfoSave;
            _repositoriesTableView.SetData(_repositoriesInfoSave.RepositoryInfos
                .Select(ri => new RepositoryData() {RepositoryInfo = ri}).ToArray());

            var repositoriesInfoProvider = new RepositoriesInfoProvider(Downloader);

            repositoriesInfoProvider.DownloadRepositoryInfos(UserName, infos =>
            {
                foreach (var repositoryInfo in infos)
                {
                    Debug.LogFormat("rep name = {0}, default_branch = {1}", repositoryInfo.Name,
                        repositoryInfo.DefaultBranch);
                }

                _repositoriesInfoSave.SetRepositories(infos);
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