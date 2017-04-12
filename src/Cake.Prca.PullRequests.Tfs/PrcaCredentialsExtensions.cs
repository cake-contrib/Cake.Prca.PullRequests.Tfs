namespace Cake.Prca.PullRequests.Tfs
{
    using Authentication;
    using Microsoft.VisualStudio.Services.Client;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services.OAuth;

    /// <summary>
    /// Extensions for the <see cref="IPrcaCredentials"/> interface.
    /// </summary>
    internal static class PrcaCredentialsExtensions
    {
        /// <summary>
        /// Returns the <see cref="VssCredentials"/> corresponding to a <see cref="IPrcaCredentials"/> object.
        /// </summary>
        /// <param name="credentials"><see cref="IPrcaCredentials"/> credential instance.</param>
        /// <returns><see cref="VssCredentials"/> instance.</returns>
        public static VssCredentials ToVssCredentials(this IPrcaCredentials credentials)
        {
            credentials.NotNull(nameof(credentials));

            switch (credentials.GetType().Name)
            {
                case nameof(TfsNtlmCredentials):
                    return new VssCredentials();

                case nameof(TfsBasicCredentials):
                    var basicCredentials = (TfsBasicCredentials)credentials;
                    return new VssBasicCredential(basicCredentials.UserName, basicCredentials.Password);

                case nameof(TfsOAuthCredentials):
                    var oAuthCredentials = (TfsOAuthCredentials)credentials;
                    return new VssOAuthAccessTokenCredential(oAuthCredentials.AccessToken);

                case nameof(TfsAadCredentials):
                    var aadCredentials = (TfsAadCredentials)credentials;
                    return new VssAadCredential(aadCredentials.UserName, aadCredentials.Password);

                default:
                    throw new PrcaException("Unknown credential type.");
            }
        }
    }
}
