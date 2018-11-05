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

        public static CommitInfo ToCommitInfo(this JToken jToken)
        {
            return new CommitInfo
            {
                Sha = jToken[ShaKey].Value<string>(),
                Author = jToken[CommitKey][AuthorKey][AuthorNameKey].Value<string>(),
                Email = jToken[CommitKey][AuthorKey][AuthorEmailKey].Value<string>(),
                Message = jToken[CommitKey][MessageKey].Value<string>()
            };
        }

        public static CommitInfo ToEmptyCommitInfo(this JToken jToken)
        {
            return new CommitInfo
            {
                Message = jToken[MessageKey].Value<string>()
            };
        }
    }
}