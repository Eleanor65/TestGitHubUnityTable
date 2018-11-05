using System.Collections.Generic;
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
        private const string UserName = "mralexgray";

        [SerializeField]
        private RepositoriesTableView _repositoriesTableView;

        private IInfoDownloader _downloader;
        private Saves _saves;
        private RepositoriesInfoSave _repositoriesInfoSave;
        private RepositoryData[] _datas;

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
            SetRepositoryInfosToTable(_repositoriesInfoSave.RepositoryInfos);

            var repositoriesInfoProvider = new RepositoriesInfoProvider(Downloader);

            repositoriesInfoProvider.DownloadRepositoryInfos(UserName, OnRepositoriesDownloaded);
            Debug.Break();
        }

        private void OnRepositoriesDownloaded(RepositoryInfo[] infos)
        {
            _repositoriesInfoSave.SetRepositories(infos);
            SetRepositoryInfosToTable(infos);
            DownloadLastCommitsInfo(infos);
            Debug.Break();
        }

        private void DownloadLastCommitsInfo(RepositoryInfo[] repositories)
        {
            var commitInfoProvider = new CommitInfoProvider(Downloader, UserName,
                repositories.Select(r => r.Name).ToArray(), SetRepositoryLastCommit);
            commitInfoProvider.Download();
        }

        private void SetRepositoryInfosToTable(IEnumerable<RepositoryInfo> infos)
        {
            _datas = infos.Select(i => new RepositoryData {RepositoryInfo = i}).ToArray();
            _repositoriesTableView.SetData(_datas);
        }

        private void SetRepositoryLastCommit(CommitInfo commitInfo)
        {
            var data = _datas.First(d => d.RepositoryInfo.Name == commitInfo.RepositoryName);
            data.CommitInfo = commitInfo;
            _repositoriesTableView.SetData(_datas);
        }
    }
}