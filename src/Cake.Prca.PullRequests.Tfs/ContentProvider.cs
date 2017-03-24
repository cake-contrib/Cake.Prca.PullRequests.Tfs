namespace Cake.Prca.PullRequests.Tfs
{
    using Issues;

    /// <summary>
    /// Class for providing the content for a pull request comment.
    /// </summary>
    internal static class ContentProvider
    {
        /// <summary>
        /// Returns the content for an issue.
        /// </summary>
        /// <param name="issue">Issue for which the content should be returned.</param>
        /// <returns>Comment content for the issue.</returns>
        public static string GetContent(ICodeAnalysisIssue issue)
        {
            var result = issue.Message;
            if (!string.IsNullOrWhiteSpace(issue.Rule))
            {
                result = $"{issue.Rule}: {result}";
            }

            return result;
        }
    }
}
