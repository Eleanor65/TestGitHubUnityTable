using UnityEditor;
using UnityEngine;

namespace GitHubUnityTable
{
    public static class Tools
    {
        [MenuItem("Tools/Clear Player Prefs", false, 1)]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}