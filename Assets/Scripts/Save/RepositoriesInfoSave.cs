using System;
using System.Linq;
using GitHubUnityTable.InfoProviders;
using UnityEngine;

namespace GitHubUnityTable.Save
{
    [Serializable]
    public class RepositoriesInfoSave : ISavePart
    {
        [SerializeField]
        private RepositoryInfo[] _repositories;

        public event Action<ISavePart> OnChanged = _ => { };

        public RepositoriesInfoSave()
        {
            _repositories = new RepositoryInfo[0];
        }

        public void SetRepositories(RepositoryInfo[] repositories)
        {
            if (_repositories == repositories || _repositories.Length == repositories.Length &&
                                                  _repositories.All(r => repositories.Any(nr => nr.Equals(r))))
                return;

            _repositories = repositories;
            OnChanged(this);
        }
    }
}