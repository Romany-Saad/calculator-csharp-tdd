using System;

namespace Calculator
{
    public static class Calculator
    {
        // order matters
        private static readonly string[] Delimiters = { "+", "-", "*", "/", "^", "rt" };

        private static bool ValidateAsValue(string s)
        {
            return decimal.TryParse(s, out _);
        }

        private static decimal ParseValue(string s)
        {
            return decimal.Parse(s);
        }

        public static decimal Calculate(string s)
        {
            foreach (var d in Delimiters)
            {
                var sides = s.SplitByLast(d);
                if (sides.Length < 2) continue;

                var leftSide = sides[0];

                var rightSide = sides[1];

                switch (d)
                {
                    case "+": return Sum(Calculate(leftSide), Calculate(rightSide));
                    case "-": return Subtract(Calculate(leftSide), Calculate(rightSide));
                    case "*": return Multiply(Calculate(leftSide), Calculate(rightSide));
                    case "/": return Divide(Calculate(leftSide), Calculate(rightSide));
                    case "^": return Power(Calculate(leftSide), Calculate(rightSide));
                    case "rt": return Power(Calculate(leftSide), 1 / Calculate(rightSide));
                }
            }

            if (!ValidateAsValue(s)) throw new InvalidSyntaxException();
            return ParseValue(s);
        }

        private static decimal Power(decimal number1, decimal number2)
        {
            return (decimal)Math.Pow((double)number1, (double)number2);
        }

        private static decimal Sum(decimal number1, decimal number2)
        {
            return number1 + number2;
        }

        private static decimal Subtract(decimal number1, decimal number2)
        {
            return number1 - number2;
        }

        private static decimal Multiply(decimal number1, decimal number2)
        {
            return number1 * number2;
        }

        private static decimal Divide(decimal number1, decimal number2)
        {
            if (number2 == 0) throw new Exception("Division by zero is undefined");
            return number1 / number2;
        }
    }
}