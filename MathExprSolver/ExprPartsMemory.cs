using System;
using System.Collections.Generic;
using MathExprSolver.ExprParts;
using MathExprSolver.Extensions;

namespace MathExprSolver
{
    internal class ExprPartsMemory : LinkedList<IExprPart>
    {
        public static int InputLength = 0;
        public static int RecursionLevel = -1;

        public NumberExprPart GetResult()
        {
            OperatorExprPart[][] prioritizedOperators = {
                new[] {SupportedOperators.Pow},
                new[] {SupportedOperators.Multiply, SupportedOperators.Divide, SupportedOperators.Mod},
                new[] {SupportedOperators.Plus, SupportedOperators.Minus}
            };
            foreach (var ops in prioritizedOperators) {
                LinkedListNode<IExprPart> hOONode;
                while ((hOONode = this.FindByMany(ops)) != null) {
                    if (hOONode.Previous == null || hOONode.Next == null) {
                        throw new IndexOutOfRangeException("This should not happen");
                    }
                    var newNode = ((OperatorExprPart)hOONode.Value).Execute(hOONode.Previous.Value as NumberExprPart,
                                                                            hOONode.Next.Value as NumberExprPart);

                    Remove(hOONode.Previous);
                    AddBefore(hOONode, newNode);
                    Remove(hOONode.Next);
                    Remove(hOONode);
                }
            }

            return First.Value as NumberExprPart;
        }
    }
}
