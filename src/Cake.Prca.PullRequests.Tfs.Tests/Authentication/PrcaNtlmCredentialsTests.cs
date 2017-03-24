namespace Cake.Prca.PullRequests.Tfs.Tests.Authentication
{
    using Shouldly;
    using Tfs.Authentication;
    using Xunit;

    public class PrcaNtlmCredentialsTests
    {
        public sealed class ThePrcaNtlmCredentialsCtor
        {
            [Fact]
            public void Should_Not_Throw()
            {
                // Given / When
                var credentials = new PrcaNtlmCredentials();

                // Then
                credentials.ShouldBeOfType<PrcaNtlmCredentials>();
            }
        }
    }
}
