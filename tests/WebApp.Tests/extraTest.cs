using WebApp.Services;
using Xunit;

namespace WebApp.Tests;

public class MathServiceMoreTests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(-5, 3)]
    [InlineData(10, 0)]
    [InlineData(1234, -567)]
    public void Add_IsCommutative(int a, int b)
    {
        var svc = new MathService();
        Assert.Equal(svc.Add(a, b), svc.Add(b, a));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 7)]
    [InlineData(0, -8)]
    public void Add_ZeroIsIdentity(int zero, int x)
    {
        var svc = new MathService();
        Assert.Equal(x, svc.Add(zero, x));
        Assert.Equal(x, svc.Add(x, zero));
    }

    [Fact(DisplayName = "Intentional failure to test PR triage"), Trait("Category", "IntentionalFail")]
    public void This_Should_Always_Fail()
    {
        // This fails on purpose to drive the "requires updates" label.
        Assert.True(false, "Intentional failure for CI/PR triage validation.");
    }
}
