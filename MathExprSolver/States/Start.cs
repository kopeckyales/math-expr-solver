using System.Collections.Generic;
using MathExprSolver.Exceptions;
using MathExprSolver.ExprParts;
using MathExprSolver.Extensions;

namespace MathExprSolver.States
{
    internal static class Start
    {
        public static NumberExprPart ConsumeInput(Queue<char> input)
        {
            ExprPartsMemory.RecursionLevel++;
            if (!input.TryDequeue(out var c)) {
                throw new UnexpectedEndOfInputException();
            }

            if (c.IsOpeningBracket()) {
                var memory = new ExprPartsMemory();
                memory.AddLast(ConsumeInput(input));
                return new EndOfSubExpr(memory).ConsumeInput(input);
            }

            if (c.IsPartOfNumber()) {
                return new Number(new ExprPartsMemory(), c.ToString()).ConsumeInput(input);
            }

            if (c.IsPrefixOperator()) {
                return new PrefixOperator(new ExprPartsMemory(), c).ConsumeInput(input);
            }

            throw new InvalidCharacterSequenceException(c, ExprPartsMemory.InputLength - input.Count);
        }
    }
}
