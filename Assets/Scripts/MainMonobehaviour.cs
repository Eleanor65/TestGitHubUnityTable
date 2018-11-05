using System.Collections;
using GitHubUnityTable.InfoDowloaders;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GitHubUnityTable
{
    public class MainMonobehaviour : MonoBehaviour
    {
        private const string Url = "https://api.github.com/users/Eleanor65/repos";

        private void Start()
        {
            //var wwwDownloader = new GameObject("WWWDownloader", typeof(WWWInfoDownloader))
            //    .GetComponent<WWWInfoDownloader>();

            //wwwDownloader.DownloadInfo(Url, ParseRepositoryResponse);

            var fakeDownloader = new FakeDownloader();
            fakeDownloader.DownloadInfo(Url, ParseRepositoryResponse);
        }

        private void ParseRepositoryResponse(string response)
        {
            var jArray = JArray.Parse(response);
            foreach (var jToken in jArray)
            {
                var jName = jToken["name"];
                Debug.LogFormat("name = {0}", jName);
            }
        }
    }
}