using Newtonsoft.Json.Linq;

namespace GitHubUnityTable.InfoProviders
{
    public static class RepoInfoParser
    {
        private const string RepoNameKey = "name";
        private const string DefaultBranchKey = "default_branch";

        public static RepositoryInfo ToRepositoryInfo(this JToken jtoken)
        {
            var name = jtoken[RepoNameKey];

            return new RepositoryInfo()
            {
                Name = jtoken[RepoNameKey].ToString(),
                DefaultBranch = jtoken[DefaultBranchKey].ToString()
            };
        }
    }
}