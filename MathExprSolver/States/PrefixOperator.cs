using System.Collections.Generic;
using MathExprSolver.Exceptions;
using MathExprSolver.ExprParts;
using MathExprSolver.Extensions;

namespace MathExprSolver.States
{
    internal class PrefixOperator
    {
        private readonly ExprPartsMemory memory;
        private readonly char op;

        public PrefixOperator(ExprPartsMemory memory, char op)
        {
            this.memory = memory;
            this.op = op;
        }

        public NumberExprPart ConsumeInput(Queue<char> input)
        {
            if (!input.TryDequeue(out var c)) {
                throw new UnexpectedEndOfInputException();
            }

            if (c.IsPartOfNumber()) {
                return new Number(memory, op + c.ToString()).ConsumeInput(input);
            }

            if (c.IsOpeningBracket()) {
                var mod = new NumberExprPart(1);
                if (op == '-') {
                    mod = new NumberExprPart(-1 * mod);
                }

                memory.AddLast(mod * Start.ConsumeInput(input));
                return new EndOfSubExpr(memory).ConsumeInput(input);
            }

            throw new InvalidCharacterSequenceException(c, ExprPartsMemory.InputLength - input.Count);
        }
    }
}
