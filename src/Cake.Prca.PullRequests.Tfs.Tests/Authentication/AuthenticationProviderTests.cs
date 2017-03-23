namespace Cake.Prca.PullRequests.Tfs.Tests.Authentication
{
    using Tfs.Authentication;
    using Shouldly;
    using Xunit;

    public class AuthenticationProviderTests
    {
        public sealed class TheAuthenticationNtlmMethod
        {
            [Fact]
            public void Should_Return_PrcaNtlmCredentials_Object()
            {
                // Given / When
                var credentials = AuthenticationProvider.AuthenticationNtlm();

                // Then
                credentials.ShouldBeOfType<PrcaNtlmCredentials>();
            }
        }

        public sealed class TheAuthenticationBasicMethod
        {
            [Fact]
            public void Should_Throw_If_User_Name_Is_Null()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationBasic(null, "foo"));

                // Then
                result.IsArgumentNullException("userName");
            }

            [Fact]
            public void Should_Throw_If_User_Name_Is_Empty()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationBasic(string.Empty, "foo"));

                // Then
                result.IsArgumentOutOfRangeException("userName");
            }

            [Fact]
            public void Should_Throw_If_User_Name_Is_WhiteSpace()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationBasic(" ", "foo"));

                // Then
                result.IsArgumentOutOfRangeException("userName");
            }

            [Fact]
            public void Should_Throw_If_Password_Is_Null()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationBasic("foo", null));

                // Then
                result.IsArgumentNullException("password");
            }

            [Fact]
            public void Should_Throw_If_Password_Is_Empty()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationBasic("foo", string.Empty));

                // Then
                result.IsArgumentOutOfRangeException("password");
            }

            [Fact]
            public void Should_Throw_If_Password_Is_WhiteSpace()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationBasic("foo", " "));

                // Then
                result.IsArgumentOutOfRangeException("password");
            }

            [Fact]
            public void Should_Return_PrcaBasicCredentials_Object()
            {
                // Given / When
                var credentials = AuthenticationProvider.AuthenticationBasic("foo", "bar");

                // Then
                credentials.ShouldBeOfType<PrcaBasicCredentials>();
            }

            [Fact]
            public void Should_Set_User_Name()
            {
                // Given 
                const string userName = "foo";

                // When
                var credentials = AuthenticationProvider.AuthenticationBasic(userName, "bar");

                // Then
                credentials.ShouldBeOfType<PrcaBasicCredentials>();
                ((PrcaBasicCredentials)credentials).UserName.ShouldBe(userName);
            }

            [Fact]
            public void Should_Set_Password()
            {
                // Given 
                const string password = "bar";

                // When
                var credentials = AuthenticationProvider.AuthenticationBasic("foo", password);

                // Then
                credentials.ShouldBeOfType<PrcaBasicCredentials>();
                ((PrcaBasicCredentials)credentials).Password.ShouldBe(password);
            }
        }

        public sealed class TheAuthenticationPersonalAccessTokenMethod
        {
            [Fact]
            public void Should_Throw_If_Personal_Access_Token_Is_Null()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationPersonalAccessToken(null));

                // Then
                result.IsArgumentNullException("personalAccessToken");
            }

            [Fact]
            public void Should_Throw_If_Personal_Access_Token_Is_Empty()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationPersonalAccessToken(string.Empty));

                // Then
                result.IsArgumentOutOfRangeException("personalAccessToken");
            }

            [Fact]
            public void Should_Throw_If_Personal_Access_Token_Is_WhiteSpace()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationPersonalAccessToken(" "));

                // Then
                result.IsArgumentOutOfRangeException("personalAccessToken");
            }

            [Fact]
            public void Should_Return_PrcaBasicCredentials_Object()
            {
                // Given / When
                var credentials = AuthenticationProvider.AuthenticationPersonalAccessToken("foo");

                // Then
                credentials.ShouldBeOfType<PrcaBasicCredentials>();
            }

            [Fact]
            public void Should_Set_Personal_Access_Token()
            {
                // Given 
                const string personalAccessToken = "foo";

                // When
                var credentials = AuthenticationProvider.AuthenticationPersonalAccessToken(personalAccessToken);

                // Then
                credentials.ShouldBeOfType<PrcaBasicCredentials>();
                ((PrcaBasicCredentials)credentials).UserName.ShouldBe(string.Empty);
                ((PrcaBasicCredentials)credentials).Password.ShouldBe(personalAccessToken);
            }
        }

        public sealed class TheAuthenticationOAuthMethod
        {
            [Fact]
            public void Should_Throw_If_Access_Token_Is_Null()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationOAuth(null));

                // Then
                result.IsArgumentNullException("accessToken");
            }

            [Fact]
            public void Should_Throw_If_Access_Token_Is_Empty()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationOAuth(string.Empty));

                // Then
                result.IsArgumentOutOfRangeException("accessToken");
            }

            [Fact]
            public void Should_Throw_If_Access_Token_Is_WhiteSpace()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationOAuth(" "));

                // Then
                result.IsArgumentOutOfRangeException("accessToken");
            }

            [Fact]
            public void Should_Return_PrcaOAuthCredentials_Object()
            {
                // Given / When
                var credentials = AuthenticationProvider.AuthenticationOAuth("foo");

                // Then
                credentials.ShouldBeOfType<PrcaOAuthCredentials>();
            }

            [Fact]
            public void Should_Set_Access_Token()
            {
                // Given 
                const string accessToken = "foo";

                // When
                var credentials = AuthenticationProvider.AuthenticationOAuth(accessToken);

                // Then
                credentials.ShouldBeOfType<PrcaOAuthCredentials>();
                ((PrcaOAuthCredentials)credentials).AccessToken.ShouldBe(accessToken);
            }
        }

        public sealed class TheAuthenticationAzureActiveDirectoryMethod
        {
            [Fact]
            public void Should_Throw_If_User_Name_Is_Null()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationAzureActiveDirectory(null, "foo"));

                // Then
                result.IsArgumentNullException("userName");
            }

            [Fact]
            public void Should_Throw_If_User_Name_Is_Empty()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationAzureActiveDirectory(string.Empty, "foo"));

                // Then
                result.IsArgumentOutOfRangeException("userName");
            }

            [Fact]
            public void Should_Throw_If_User_Name_Is_WhiteSpace()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationAzureActiveDirectory(" ", "foo"));

                // Then
                result.IsArgumentOutOfRangeException("userName");
            }

            [Fact]
            public void Should_Throw_If_Password_Is_Null()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationAzureActiveDirectory("foo", null));

                // Then
                result.IsArgumentNullException("password");
            }

            [Fact]
            public void Should_Throw_If_Password_Is_Empty()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationAzureActiveDirectory("foo", string.Empty));

                // Then
                result.IsArgumentOutOfRangeException("password");
            }

            [Fact]
            public void Should_Throw_If_Password_Is_WhiteSpace()
            {
                // Given / When
                var result = Record.Exception(() => AuthenticationProvider.AuthenticationAzureActiveDirectory("foo", " "));

                // Then
                result.IsArgumentOutOfRangeException("password");
            }

            [Fact]
            public void Should_Return_PrcaAadCredentials_Object()
            {
                // Given / When
                var credentials = AuthenticationProvider.AuthenticationAzureActiveDirectory("foo", "bar");

                // Then
                credentials.ShouldBeOfType<PrcaAadCredentials>();
            }

            [Fact]
            public void Should_Set_User_Name()
            {
                // Given 
                const string userName = "foo";

                // When
                var credentials = AuthenticationProvider.AuthenticationAzureActiveDirectory(userName, "bar");

                // Then
                credentials.ShouldBeOfType<PrcaAadCredentials>();
                ((PrcaAadCredentials)credentials).UserName.ShouldBe(userName);
            }

            [Fact]
            public void Should_Set_Password()
            {
                // Given 
                const string password = "bar";

                // When
                var credentials = AuthenticationProvider.AuthenticationAzureActiveDirectory("foo", password);

                // Then
                credentials.ShouldBeOfType<PrcaAadCredentials>();
                ((PrcaAadCredentials)credentials).Password.ShouldBe(password);
            }
        }
    }
}
