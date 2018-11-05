using System;
using UnityEngine;

namespace GitHubUnityTable.InfoProviders
{
    [Serializable]
    public class RepositoryInfo
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _defaultBranch;
        [SerializeField]
        private string _updatedAt;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string DefaultBranch
        {
            get { return _defaultBranch; }
            set { _defaultBranch = value; }
        }

        public string UpdatedAt
        {
            get { return _updatedAt; }
            set { _updatedAt = value; }
        }

        public override bool Equals(object obj)
        {
            var info = obj as RepositoryInfo;
            return info != null &&
                   _name == info._name &&
                   _defaultBranch == info._defaultBranch &&
                   _updatedAt == info._updatedAt;
        }
    }
}