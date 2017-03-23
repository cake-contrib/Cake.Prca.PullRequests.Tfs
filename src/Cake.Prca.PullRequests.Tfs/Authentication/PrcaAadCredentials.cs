namespace Cake.Prca.PullRequests.Tfs.Authentication
{
    /// <summary>
    /// Credentials for authentication with an Azure Active Directory.
    /// </summary>
    public class PrcaAadCredentials : PrcaBasicCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrcaAadCredentials"/> class.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public PrcaAadCredentials(string userName, string password)
            : base(userName, password)
        {
        }
    }
}
