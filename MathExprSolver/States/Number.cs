using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MathExprSolver.Exceptions;
using MathExprSolver.ExprParts;
using MathExprSolver.Extensions;

namespace MathExprSolver.States
{
    internal class Number
    {
        private readonly ExprPartsMemory memory;
        private readonly StringBuilder currentExprPartBuilder;

        public Number(ExprPartsMemory memory, string head)
        {
            this.memory = memory;
            currentExprPartBuilder = new StringBuilder(head);
        }

        public NumberExprPart ConsumeInput(Queue<char> input)
        {
            if (!input.TryDequeue(out var c) || c.IsClosingBracket()) {
                SaveCurrentNumberExprPartToMemory(ExprPartsMemory.InputLength - input.Count);
                return End.GetResult(memory);
            }

            if (c.IsPartOfNumber()) {
                currentExprPartBuilder.Append(c);
                return ConsumeInput(input);
            }

            if (c.IsOperator()) {
                SaveCurrentNumberExprPartToMemory(ExprPartsMemory.InputLength - input.Count);
                return new NonPrefixOperator(memory, c).ConsumeInput(input);
            }

            throw new InvalidCharacterSequenceException(c, ExprPartsMemory.InputLength - input.Count);
        }

        private void SaveCurrentNumberExprPartToMemory(int currentIndex)
        {
            if (!double.TryParse(currentExprPartBuilder.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture,
                                 out var number)) {
                var length = currentExprPartBuilder.Length;
                throw new InvalidNumberException(currentExprPartBuilder.ToString(), currentIndex - length, currentIndex - 1);
            }

            memory.AddLast(new NumberExprPart(number));
        }
    }
}
