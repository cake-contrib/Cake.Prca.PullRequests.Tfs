namespace Cake.Prca.PullRequests.Tfs.Tests
{
    using Issues;
    using Shouldly;
    using Xunit;

    public class ContentProviderTests
    {
        public sealed class TheGetContentClass
        {
            [Theory]
            [InlineData(
                @"foo.cs",
                123,
                "Some message",
                1,
                "foo",
                "foo: Some message")]
            [InlineData(
                @"foo.cs",
                123,
                "Some message",
                1,
                "",
                "Some message")]
            [InlineData(
                @"foo.cs",
                123,
                "Some message",
                1,
                " ",
                "Some message")]
            public void Should_Return_Correct_Value(
                string filePath,
                int? line,
                string message,
                int priority,
                string rule,
                string expectedResult)
            {
                // Given
                var issue = new CodeAnalysisIssue(filePath, line, message, priority, rule, null, "Foo");

                // When
                var result = ContentProvider.GetContent(issue);

                // Then
                result.ShouldBe(expectedResult);
            }
        }
    }
}
