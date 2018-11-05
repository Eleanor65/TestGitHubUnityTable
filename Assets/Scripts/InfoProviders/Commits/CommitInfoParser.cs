using Newtonsoft.Json.Linq;

namespace GitHubUnityTable.InfoProviders
{
    public static class CommitInfoParser
    {
        private const string ShaKey = "sha";

        private const string CommitKey = "commit";

        private const string AuthorKey = "author";
        private const string AuthorNameKey = "name";
        private const string AuthorEmailKey = "email";

        private const string MessageKey = "message";

        public static CommitInfo ToCommitInfo(this JToken jtoken)
        {
            return new CommitInfo
            {
                Sha = jtoken[ShaKey].ToString(),
                Author = jtoken[CommitKey][AuthorKey][AuthorNameKey].ToString(),
                Email = jtoken[CommitKey][AuthorKey][AuthorEmailKey].ToString(),
                Message = jtoken[CommitKey][MessageKey].ToString()
            };
        }
    }
}