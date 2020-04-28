using System.Collections.Generic;
using MathExprSolver.ExprParts;

namespace MathExprSolver
{
    internal class SupportedOperators : Dictionary<char, OperatorExprPart>
    {
        public static readonly OperatorExprPart Plus = new OperatorExprPart((a, b) => a + b, '+');
        public static readonly OperatorExprPart Minus = new OperatorExprPart((a, b) => a - b, '-');
        public static readonly OperatorExprPart Multiply = new OperatorExprPart((a, b) => a * b, '*');
        public static readonly OperatorExprPart Divide = new OperatorExprPart((a, b) => a / b, '/');
        public static readonly OperatorExprPart Pow = new OperatorExprPart((a, b) => a ^ b, '^');
        public static readonly OperatorExprPart Mod = new OperatorExprPart((a, b) => a % b, '%');

        public static readonly Dictionary<char, OperatorExprPart> OperatorsTable = new SupportedOperators();

        private SupportedOperators()
        {
            Add('+', Plus);
            Add('-', Minus);
            Add('*', Multiply);
            Add('/', Divide);
            Add('%', Mod);
            Add('^', Pow);
        }
    }
}
