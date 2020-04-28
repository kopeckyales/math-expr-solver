using System.Collections.Generic;
using MathExprSolver.Exceptions;
using MathExprSolver.ExprParts;
using MathExprSolver.Extensions;

namespace MathExprSolver.States
{
    internal class NonPrefixOperator
    {
        private readonly ExprPartsMemory memory;

        public NonPrefixOperator(ExprPartsMemory memory, char op)
        {
            this.memory = memory;
            this.memory.AddLast(SupportedOperators.OperatorsTable[op]);
        }

        public NumberExprPart ConsumeInput(Queue<char> input)
        {
            if (!input.TryDequeue(out var c)) {
                throw new UnexpectedEndOfInputException();
            }

            if (c.IsPartOfNumber()) {
                return new Number(memory, c.ToString()).ConsumeInput(input);
            }

            if (c.IsPrefixOperator()) {
                return new PrefixOperator(memory, c).ConsumeInput(input);
            }

            if (c.IsOpeningBracket()) {
                memory.AddLast(Start.ConsumeInput(input));
                return new EndOfSubExpr(memory).ConsumeInput(input);
            }

            throw new InvalidCharacterSequenceException(c, ExprPartsMemory.InputLength - input.Count);
        }
    }
}
