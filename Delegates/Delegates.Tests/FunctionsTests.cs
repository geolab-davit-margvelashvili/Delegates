namespace Delegates.Tests;

public class FunctionsTests
{
    [Fact(DisplayName = "Find ფუნქციამ უნდა დააბრუნოს პირველი ელემენტი")]
    public void Find_Should_ReturnFirstElement()
    {
        // Arrange
        var numbers = new List<int> { -1, 10, 20, 15, -7, 50 };

        // Act
        var firstNegative = numbers.FindFirst(number => number < 0);

        // Assert
        Assert.Equal(-1, firstNegative);
    }

    [Fact(DisplayName = "Find ფუნქციამ უნდა დაარტყას ArgumentNullException როდესაც კოლექცია არის null")]
    public void Find_ShouldThrow_ArgumentNullException_IfCollectionIsNull()
    {
        // Arrange
        List<int> numbers = null;

        // Act & Assert

        Assert.Throws<ArgumentNullException>(() => numbers.FindFirst(number => number < 0));
    }
}