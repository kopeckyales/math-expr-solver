using System.Collections.Generic;
using MathExprSolver.States;

namespace MathExprSolver
{
    public static class Solver
    {
        public static double Solve(string expr)
        {
            ExprPartsMemory.InputLength = expr.Length;
            ExprPartsMemory.RecursionLevel = -1;
            return Start.ConsumeInput(new Queue<char>(expr));
        }
    }
}
