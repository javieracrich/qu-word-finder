namespace qu_word_finder.Tests;

public class OptimizedWordFinderTests
{
    [Fact]
    public void Find_ReturnsCorrectWords()
    {
        // Arrange
        var matrix = new List<string>
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
        var finder = new OptimizedWordFinder(matrix);
        var words = new List<string> { "chill", "cold", "wind", "snow" };

        // Act
        var result = finder.Find(words);

        // Assert
        Assert.Contains("chill", result);
        Assert.Contains("cold", result);
        Assert.Contains("wind", result);
        Assert.DoesNotContain("snow", result);
    }

    [Fact]
    public void Find_ReturnsEmptyWhenNoWordsFound()
    {
        // Arrange
        var matrix = new List<string>
        {
            "abcdc",
            "fgwio",
            "chill",
            "pqnsd",
            "uvdxy"
        };
        var finder = new OptimizedWordFinder(matrix);
        var words = new List<string> { "javier", "acrich" };

        // Act
        var result = finder.Find(words);

        // Assert
        Assert.Empty(result);
    }
}