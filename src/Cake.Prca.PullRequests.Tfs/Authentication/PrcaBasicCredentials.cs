namespace Cake.Prca.PullRequests.Tfs.Authentication
{
    /// <summary>
    /// Credentials for basic authentication.
    /// </summary>
    public class PrcaBasicCredentials : IPrcaCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrcaBasicCredentials"/> class.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public PrcaBasicCredentials(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        /// Gets the user name.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public string Password { get; private set; }
    }
}
