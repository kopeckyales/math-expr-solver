using System;

namespace MathExprSolver.ExprParts
{
    class OperatorExprPart : IExprPart
    {
        private readonly Func<NumberExprPart, NumberExprPart, NumberExprPart> op;
        private readonly char c;

        public OperatorExprPart(Func<NumberExprPart, NumberExprPart, NumberExprPart> op, char c)
        {
            this.op = op;
            this.c = c;
        }

        public NumberExprPart Execute(NumberExprPart left, NumberExprPart right)
        {
            return op(left, right);
        }

        public override string ToString()
        {
            return c.ToString();
        }
    }
}
