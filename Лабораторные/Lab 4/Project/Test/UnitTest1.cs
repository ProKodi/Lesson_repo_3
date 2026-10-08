using System.Data;

namespace Test;

public class UnitTest1 {
[Theory]
[InlineData("2 1/3 + 3 1/2", "5 5/6")]
[InlineData("2 1/3 - 1 1/3", "1")]
[InlineData("1/3 + 1/6", "1/2")]
[InlineData("1/2 + 1/2", "1")]
[InlineData("2 + 3", "5")]
[InlineData("2 + 3 1/2", "5 1/2")]
[InlineData("2 1/2 + 3", "5 1/2")]
[InlineData("3/4 - 1/4", "1/2")]
[InlineData("1/3 + 1/3", "2/3")]
[InlineData("2/3 + 1/3", "1")]
public void Calculate_PositiveTests(
    string expression,
    string expected)
{
    Assert.Equal(expected, Program.Calculate(expression));
}

[Theory]
[InlineData("1 - 2", "-1")]
[InlineData("1 1/2 - 3", "-1 1/2")]
[InlineData("2 1/2 - 5", "-2 1/2")]
[InlineData("1/3 - 2/3", "-1/3")]
[InlineData("1/4 - 3/4", "-1/2")]
[InlineData("2/3 - 5/3", "-1")]
[InlineData("1 - 2 1/2", "-1 1/2")]
public void Calculate_NegativeTests(
    string expression,
    string expected)
{
    Assert.Equal(expected, Program.Calculate(expression));
}


[Theory]
[InlineData("0 + 0", "0")]
[InlineData("1 + 0", "1")]
[InlineData("0 + 1", "1")]
[InlineData("1000 + 1000", "2000")]
[InlineData("1000 - 1000", "0")]
[InlineData("1000 1000/1000 + 1000 1000/1000", "2002")]
[InlineData("1000 999/1000 + 1000 999/1000", "2001 499/500")]
[InlineData("1000 999/1000 - 0", "1000 999/1000")]
[InlineData("0 - 1000", "-1000")]
public void Calculate_BoundaryTests(
    string expression,
    string expected)
{
    Assert.Equal(expected, Program.Calculate(expression));
}


}
