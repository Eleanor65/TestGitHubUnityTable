using System;

namespace GitHubUnityTable.InfoDowloaders
{
    public interface IInfoDownloader
    {
        void DownloadInfo(string url, Action<string> onComplete);
    }
}