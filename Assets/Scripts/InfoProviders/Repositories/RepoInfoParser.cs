using Newtonsoft.Json.Linq;

namespace GitHubUnityTable.InfoProviders
{
    public static class RepoInfoParser
    {
        private const string RepoNameKey = "name";
        private const string DefaultBranchKey = "default_branch";
        private const string UpdatedAtKey = "updated_at";

        public static RepositoryInfo ToRepositoryInfo(this JToken jToken)
        {
            return new RepositoryInfo()
            {
                Name = jToken[RepoNameKey].Value<string>(),
                DefaultBranch = jToken[DefaultBranchKey].Value<string>(),
                UpdatedAt = jToken[UpdatedAtKey].Value<string>(),
            };
        }
    }
}