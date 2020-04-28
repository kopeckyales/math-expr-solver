namespace MathExprSolver.Extensions
{
    internal static class CharExtensions
    {
        internal static bool IsOpeningBracket(this char c)
        {
            return c == '(';
        }

        internal static bool IsClosingBracket(this char c)
        {
            return c == ')';
        }

        internal static bool IsPartOfNumber(this char c)
        {
            return c >= '0' && c <= '9' || c == '.';
        }

        internal static bool IsOperator(this char c)
        {
            return SupportedOperators.OperatorsTable.ContainsKey(c);
        }

        internal static bool IsPrefixOperator(this char c)
        {
            return c == '+' || c == '-';
        }
    }
}
