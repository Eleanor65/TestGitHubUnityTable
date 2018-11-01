using System.Collections;
using UnityEngine;

namespace GitHubUnityTable
{
    public class MainMonobehaviour : MonoBehaviour
    {
        private const string Url = "https://api.github.com/users/Eleanor65/repos";

        private IEnumerator Start()
        {
            using (WWW www = new WWW(Url))
            {
                yield return www;
                Debug.Log(www.text);
            }
        }
    }
}