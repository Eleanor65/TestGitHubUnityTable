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
                Sha = jtoken[ShaKey].Value<string>(),
                Author = jtoken[CommitKey][AuthorKey][AuthorNameKey].Value<string>(),
                Email = jtoken[CommitKey][AuthorKey][AuthorEmailKey].Value<string>(),
                Message = jtoken[CommitKey][MessageKey].Value<string>()
            };
        }
    }
}