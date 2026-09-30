# Lab 3: Code Coverage

## Add code coverage testing dependency

From `parent directory` for `MyFirstDotNetApp`

```bash
dotnet new xunit -n MyFirstDotNetApp.Tests
```
```bash
dotnet add MyFirstDotNetApp.Tests/MyFirstDotNetApp.Tests.csproj reference MyFirstDotNetApp/MyFirstDotNetApp.csproj 
```
```bash
dotnet list MyFirstDotNetApp.Tests/MyFirstDotNetApp.Tests.csproj reference
```

```bash
Delete the file MyFirstDotNetApp.Tests/UnitTest1.cs
```

## Create two files

In `MyFirstDotNetApp/Calculator.cs`
```bash
namespace MyFirstDotNetApp;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public double Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException();

        return (double)a / b;
    }
}
```

In `MyFirstDotNetApp.Tests/CalculatorTests.cs`

```cs
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
```

## Install .NET packages

Inside `MyFirstDotNetApp`

```bash
dotnet restore
```

## Initiate SAST

From `parent directory` for `MyFirstDotNetApp`

```bash
dotnet sonarscanner begin \
    /k:"<Project-Key>" \
    /d:sonar.host.url="<SONAR_HOST>" \
    /d:sonar.token="<SONAR_TOKEN>" \
    /d:sonar.cs.vscoveragexml.reportsPaths="coverage.xml"
    /d:verbose=true
    /d:skipJreProvisioning=true
```

```bash
dotnet build MyFirstDotNetApp/MyFirstDotNetApp.csproj 
```
```bash
dotnet build MyFirstDotNetApp.Tests/MyFirstDotNetApp.Tests.csproj 
```

```bash
dotnet-coverage collect \
    "dotnet test MyFirstDotNetApp.Tests/MyFirstDotNetApp.Tests.csproj --no-build" \
    -f xml \
    -o coverage.xml
```

```bash
dotnet sonarscanner end /d:sonar.token="<SONARQUBE_TOKEN>"
```