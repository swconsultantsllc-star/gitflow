using WebApp.Services;
using Xunit;

namespace WebApp.Tests;

public class MathServiceTests
{
    [Fact]
    public void Add_ReturnsSum_ForPositiveNumbers()
    {
        var svc = new MathService();
        Assert.Equal(7, svc.Add(3, 4));
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    [InlineData(10, -3, 7)]
    public void Add_Works_WithVariousInputs(int a, int b, int expected)
    {
        var svc = new MathService();
        Assert.Equal(expected, svc.Add(a, b));
    }
}
