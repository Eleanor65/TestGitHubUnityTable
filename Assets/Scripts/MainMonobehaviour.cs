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
            //StartCoroutine(DownloadRepoInfoString());

            DownloadConstResponse();
        }

        private IEnumerator DownloadRepoInfoString()
        {
            using (WWW www = new WWW(Url))
            {
                yield return www;
                _repoInfoString = www.text;
            }

            var jArray = GetJArrayFromResponse();
            Debug.Log(jArray);
        }

        private void DownloadConstResponse()
        {
            _repoInfoString = RepositoriesResponse.ResponseString;
            var jArray = GetJArrayFromResponse();
            ParseRepositoryArray(jArray);
        }

        private JArray GetJArrayFromResponse()
        {
            return JArray.Parse(_repoInfoString);
        }

        private void ParseRepositoryArray(JArray jArray)
        {
            foreach (var jToken in jArray)
            {
                var jName = jToken["name"];
                Debug.LogFormat("name = {0}", jName);
            }
        }
    }
}