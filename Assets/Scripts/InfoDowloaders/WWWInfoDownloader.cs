using System;
using System.Collections;
using UnityEngine;

namespace GitHubUnityTable.InfoDowloaders
{
    public class WWWInfoDownloader : MonoBehaviour, IInfoDownloader
    {
        public void DownloadInfo(string url, Action<string> onComplete)
        {
            StartCoroutine(Download(url, onComplete));
        }

        private IEnumerator Download(string url, Action<string> onComplete)
        {
            using (var www = new WWW(url))
            {
                yield return www;
                onComplete(www.text);
            }
        }
    }
}