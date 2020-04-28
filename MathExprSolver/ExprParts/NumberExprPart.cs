using System;
using System.Globalization;

namespace MathExprSolver.ExprParts
{
    class NumberExprPart : IExprPart
    {
        private readonly double number;

        public NumberExprPart(double number)
        {
            this.number = number;
        }

        public static NumberExprPart operator+(NumberExprPart a, NumberExprPart b)
            => new NumberExprPart(a.number + b.number);

        public static NumberExprPart operator-(NumberExprPart a, NumberExprPart b)
            => new NumberExprPart(a.number - b.number);

        public static NumberExprPart operator*(NumberExprPart a, NumberExprPart b)
            => new NumberExprPart(a.number * b.number);

        public static NumberExprPart operator/(NumberExprPart a, NumberExprPart b)
            => new NumberExprPart(a.number / b.number);

        public static NumberExprPart operator%(NumberExprPart a, NumberExprPart b)
            => new NumberExprPart(a.number % b.number);

        public static NumberExprPart operator^(NumberExprPart a, NumberExprPart b)
            => new NumberExprPart(Math.Pow(a.number, b.number));

        public static implicit operator double(NumberExprPart n) => n.number;

        public override string ToString()
        {
            return number.ToString(CultureInfo.InvariantCulture);
        }
    }
}