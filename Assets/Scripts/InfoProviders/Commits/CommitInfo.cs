namespace GitHubUnityTable.InfoProviders
{
    public class CommitInfo
    {
        public string RepositoryName { get; set; }
        public string Sha { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}