using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GitHubUnityTable
{
    public class MainMonobehaviour : MonoBehaviour
    {
        private const string Url = "https://api.github.com/users/Eleanor65/repos";

        private string _repoInfoString;
        
        private void Start()
        {
            StartCoroutine(DownloadRepoInfoString());
        }

        private IEnumerator DownloadRepoInfoString()
        {
            using (WWW www = new WWW(Url))
            {
                yield return www;
                _repoInfoString = www.text;
            }

            var jArray = JArray.Parse(_repoInfoString);
            Debug.Log(jArray);
        }
    }
}