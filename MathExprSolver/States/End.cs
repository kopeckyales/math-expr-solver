using MathExprSolver.ExprParts;

namespace MathExprSolver.States
{
    internal static class End
    {
        // this exists only for better understanding of code, so we can clearly see the endpoint of the expr parsing
        public static NumberExprPart GetResult(ExprPartsMemory memory)
        {
            return memory.GetResult();
        }
    }
}
