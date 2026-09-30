using MyFirstDotNetApp;

namespace MyFirstDotNetApp.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [Fact]
    public void Add_ShouldReturnSum()
    {
        var result = _calculator.Add(10, 5);

        Assert.Equal(15, result);
    }

    [Fact]
    public void Subtract_ShouldReturnDifference()
    {
        var result = _calculator.Subtract(10, 5);

        Assert.Equal(5, result);
    }

    [Fact]
    public void Multiply_ShouldReturnProduct()
    {
        var result = _calculator.Multiply(10, 5);

        Assert.Equal(50, result);
    }

    [Fact]
    public void Divide_ShouldReturnQuotient()
    {
        var result = _calculator.Divide(10, 5);

        Assert.Equal(2, result);
    }

    [Fact]
    public void Divide_ByZero_ShouldThrowException()
    {
        Assert.Throws<DivideByZeroException>(
            () => _calculator.Divide(10, 0)
        );
    }
}