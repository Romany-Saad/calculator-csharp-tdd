using Calculator;
using Xunit;
using C = Calculator.Calculator;

namespace CalculatorTest
{
    public class SyntaxTests
    {
        [Fact]
        public void ItShouldDetectInvalidSyntax()
        {
            Assert.Throws<InvalidSyntaxException>(() => C.Calculate("25 + 100 rt") );
        }

        [Fact]
        public void ItShouldTolerateSpacing()
        {
            Assert.Equal(3, C.Calculate("       21/7"));
            Assert.Equal(9, C.Calculate("21/7*    3"));
            Assert.Equal(24, C.Calculate("21/7* 3+   5*3"));
            Assert.Equal(24, C.Calculate("21/7*3+5*3"));
        }

    }
}