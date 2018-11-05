using GitHubUnityTable.InfoProviders;
using UnityEngine;
using UnityEngine.UI;

namespace GitHubUnityTable.Ui
{
    public class RepositoryView : MonoBehaviour
    {
        [SerializeField]
        private Text _textName;
        [SerializeField]
        private Text _textDefaultBranch;
        [SerializeField]
        private Text _textUpdatedAt;
        [Space]
        [SerializeField]
        private Text _textCommitSha;
        [SerializeField]
        private Text _textCommitAuthor;
        [SerializeField]
        private Text _textCommitEmail;
        [SerializeField]
        private Text _textCommitMessage;

        public void SetRepository(RepositoryInfo repositoryInfo)
        {
            _textName.text = repositoryInfo.Name;
            _textDefaultBranch.text = repositoryInfo.DefaultBranch;
            _textUpdatedAt.text = repositoryInfo.UpdatedAt;
        }

        public void SetCommit(CommitInfo commitInfo)
        {
            _textCommitSha.text = commitInfo == null ? null : commitInfo.Sha;
            _textCommitAuthor.text = commitInfo == null ? null : commitInfo.Author;
            _textCommitEmail.text = commitInfo == null ? null : commitInfo.Email;
            _textCommitMessage.text = commitInfo == null ? null : commitInfo.Message;
        }
    }
}