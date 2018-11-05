using System;
using GitHubUnityTable.InfoDowloaders;
using Newtonsoft.Json.Linq;

namespace GitHubUnityTable.InfoProviders
{
    public class CommitInfoProvider
    {
        private const string CommitsUrl = "https://api.github.com/repos/{0}/{1}/commits";

        private readonly IInfoDownloader _downloader;
        private readonly string _name;
        private readonly string[] _repositoryNames;
        private readonly Action<CommitInfo> _onNext;

        private bool _isDownloading;
        private int _index;

        public CommitInfoProvider(IInfoDownloader downloader, string name, string[] repositoryNames,
            Action<CommitInfo> onNext)
        {
            _downloader = downloader;
            _name = name;
            _repositoryNames = repositoryNames;
            _onNext = onNext;
        }

        public void Download()
        {
            if (_isDownloading)
                return;

            _isDownloading = true;
            DownloadNext();
        }

        private void DownloadNext()
        {
            if (_index >= _repositoryNames.Length)
            {
                _isDownloading = false;
                return;
            }

            DownloadLastCommitInfo();
        }
        
        public void DownloadLastCommitInfo()
        {
            var url = string.Format(CommitsUrl, _name, _repositoryNames[_index]);
            _downloader.DownloadInfo(url, OnDownloadedResponse);
        }

        private void OnDownloadedResponse(string response)
        {
            var jToken = JArray.Parse(response)[0];
            var commitInfo = jToken.ToCommitInfo();
            commitInfo.RepositoryName = _repositoryNames[_index];
            _onNext(commitInfo);

            _index++;
            DownloadNext();
        }
    }
}