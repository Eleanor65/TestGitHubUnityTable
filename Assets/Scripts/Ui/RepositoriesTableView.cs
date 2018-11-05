using Boo.Lang;
using UnityEngine;

namespace GitHubUnityTable.Ui
{
    public class RepositoriesTableView : MonoBehaviour
    {
        [SerializeField]
        private RepositoryView _prefabRepositoryView;
        [SerializeField]
        private Transform _root;

        private List<RepositoryView> _repositoryViews;

        public void SetData(RepositoryData[] datas)
        {
            for (var i = 0; i < datas.Length; i++)
            {
                var repositoryView = GetRepositoryView(i);
                repositoryView.SetRepository(datas[i].RepositoryInfo);
                repositoryView.SetCommit(datas[i].CommitInfo);
            }
        }

        private RepositoryView GetRepositoryView(int index)
        {
            if (_repositoryViews == null)
                _repositoryViews = new List<RepositoryView>();

            if (index >= _repositoryViews.Count)
            {
                var newRepositoryView = Instantiate(_prefabRepositoryView, _root);
                _repositoryViews.Add(newRepositoryView);
                return newRepositoryView;
            }

            return _repositoryViews[index];
        }
    }
}