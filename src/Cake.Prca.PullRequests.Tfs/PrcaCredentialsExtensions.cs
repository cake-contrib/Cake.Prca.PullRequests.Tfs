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
                case nameof(PrcaNtlmCredentials):
                    return new VssCredentials();

                case nameof(PrcaBasicCredentials):
                    var basicCredentials = (PrcaBasicCredentials)credentials;
                    return new VssBasicCredential(basicCredentials.UserName, basicCredentials.Password);

                case nameof(PrcaOAuthCredentials):
                    var oAuthCredentials = (PrcaOAuthCredentials)credentials;
                    return new VssOAuthAccessTokenCredential(oAuthCredentials.AccessToken);

                case nameof(PrcaAadCredentials):
                    var aadCredentials = (PrcaAadCredentials)credentials;
                    return new VssAadCredential(aadCredentials.UserName, aadCredentials.Password);

                default:
                    throw new PrcaException("Unknown credential type.");
            }
        }
    }
}
