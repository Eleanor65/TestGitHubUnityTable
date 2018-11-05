using System.Collections;
using GitHubUnityTable.InfoDowloaders;
using GitHubUnityTable.InfoProviders;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GitHubUnityTable
{
    public class MainMonobehaviour : MonoBehaviour
    {
        private void Start()
        {
            //var downloader = new GameObject("WWWDownloader", typeof(WWWInfoDownloader))
            //    .GetComponent<WWWInfoDownloader>();
            var downloader = new FakeDownloader();

            var repositoriesInfoProvider = new RepositoriesInfoProvider(downloader);

            repositoriesInfoProvider.DownloadRepositoryInfos(infos =>
            {
                foreach (var repositoryInfo in infos)
                {
                    Debug.LogFormat("rep name = {0}, default_branch = {1}", repositoryInfo.Name,
                        repositoryInfo.DefaultBranch);
                }
            });
            //for testing purposes
        }
    }
}