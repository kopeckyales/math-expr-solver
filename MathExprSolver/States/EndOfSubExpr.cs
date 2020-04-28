using System.Collections.Generic;
using MathExprSolver.Exceptions;
using MathExprSolver.ExprParts;
using MathExprSolver.Extensions;

namespace MathExprSolver.States
{
    internal class EndOfSubExpr
    {
        private readonly ExprPartsMemory memory;

        public EndOfSubExpr(ExprPartsMemory memory)
        {
            this.memory = memory;
        }

        public NumberExprPart ConsumeInput(Queue<char> input)
        {
            ExprPartsMemory.RecursionLevel--;
            if (!input.TryDequeue(out var c)) {
                if (ExprPartsMemory.RecursionLevel != 0) {
                    throw new UnexpectedEndOfInputException();
                }

                return End.GetResult(memory);
            }

            if (c.IsClosingBracket()) {
                return End.GetResult(memory);
            }

            if (c.IsOperator()) {
                return new NonPrefixOperator(memory, c).ConsumeInput(input);
            }

            throw new InvalidCharacterSequenceException(c, ExprPartsMemory.InputLength - input.Count);
        }
    }
}
