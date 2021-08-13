using System;
using Calculator;
using Xunit;
using C = Calculator.Calculator;

namespace CalculatorTest
{
    public class UnitTest1
    {
        [Fact]
        public void ItShouldSumTwoNumbers()
        {
            Assert.Equal(2, C.Calculate("1 + 1"));
            Assert.Equal(3, C.Calculate("1 + 2"));
            Assert.Equal((decimal)3.8, C.Calculate("1.5 + 2.3"));
        }

        [Fact]
        public void ItShouldSubtractTwoNumbers()
        {
            Assert.Equal(0, C.Calculate("1 - 1"));
            Assert.Equal(1, C.Calculate("2 - 1"));
            Assert.Equal((decimal)0.33, C.Calculate("1 - 0.67"));
        }

        [Fact]
        public void ItShouldMultiplyTwoNumbers()
        {
            Assert.Equal(1, C.Calculate("1 * 1"));
            Assert.Equal(2, C.Calculate("2 * 1"));
            Assert.Equal((decimal)2.5, C.Calculate("5 * 0.5"));
        }

        [Fact]
        public void ItShouldDivideTwoNumbers()
        {
            Assert.Equal(1, C.Calculate("1 / 1"));
            Assert.Equal(2, C.Calculate("2 / 1"));
            Assert.Equal((decimal)2.5, C.Calculate("5 / 2"));
            Assert.Equal((decimal)1000000 / 30, C.Calculate("1000000 / 30"));
            Assert.Equal(2, C.Calculate("0.5 / 0.25"));
        }

        [Fact]
        public void ItShouldThrowOnDivisionByZero()
        {
            Assert.Throws<Exception>(() => C.Calculate("1 / 0"));
            Assert.Throws<Exception>(() => C.Calculate("1000 / 0"));
            Assert.Throws<Exception>(() => C.Calculate("0.25 / 0"));
        }

        [Fact]
        public void ItShouldCalculateThePowerOfABase()
        {
            Assert.Equal(1, C.Calculate("1 ^ 1"));
            Assert.Equal(2, C.Calculate("2 ^ 1"));
            Assert.Equal(25, C.Calculate("5 ^ 2"));
            Assert.Equal(1024, C.Calculate("2 ^ 10"));
            Assert.Equal(5, C.Calculate("25 ^ 0.5"));
            Assert.Equal(1, C.Calculate("25 ^ 0"));
        }

        [Fact]
        public void ItShouldMultiplyBeforeSumming()
        {
            Assert.Equal(9, C.Calculate("3 + 3 * 2"));
        }

        [Fact]
        public void ItShouldPowerBeforeMultiply()
        {
            Assert.Equal(45, C.Calculate("5 * 3 ^ 2"));
        }

        [Fact]
        public void ItShouldDivideAndMultiplyBeforeSummationOrSubtraction()
        {
            Assert.Equal(3, C.Calculate("21 / 7"));
            Assert.Equal(9, C.Calculate("21 / 7 * 3"));
            Assert.Equal(24, C.Calculate("21 / 7 * 3 + 5 * 3"));
            Assert.Equal(5, C.Calculate("5 ^ 3 / 25"));
            Assert.Equal(5, C.Calculate("5 ^ 5 / 25 / 5 / 5"));
            Assert.Equal(126, C.Calculate("5 ^ 3 + 25 / 5 / 5"));
            Assert.Equal(125, C.Calculate("5 ^ 3 + 25 / 5 - 5"));
            Assert.Equal(150, C.Calculate("5 ^ 3 + 25 + 5 - 5"));
            Assert.Equal(145, C.Calculate("0 - 5 + 25 + 5 ^ 3"));
        }

        [Fact]
        public void ItShouldTolerateSpacing()
        {
            Assert.Equal(3, C.Calculate("       21/7"));
            Assert.Equal(9, C.Calculate("21/7*    3"));
            Assert.Equal(24, C.Calculate("21/7* 3+   5*3"));
            Assert.Equal(24, C.Calculate("21/7*3+5*3"));
        }

        [Fact]
        public void ItShouldBeAbleToCalculateRootForAValue()
        {
            Assert.Equal(5, C.Calculate("125 rt 3"));
        }

        [Fact]
        public void ItShouldPowerAndRootBeforeDivideAndMultiply()
        {
            Assert.Equal(30, C.Calculate("25 + 125 rt 3"));
            Assert.Equal(30, C.Calculate("125 rt 3 + 25"));
            Assert.Equal(130, C.Calculate("5 ^ 5 / 25 + 125 rt 3"));
        }

        [Fact]
        public void ItShouldDetectInvalidSyntax()
        {
            Assert.Throws<InvalidSyntaxException>(() => C.Calculate("25 + 100 rt") );
        }
    }
}