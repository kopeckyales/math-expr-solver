using System;

namespace MathExprSolver.Exceptions
{
    public class InvalidNumberException : Exception
    {
        public string Number
        {
            get;
        }

        public int StartPosition
        {
            get;
        }
        public int EndPosition
        {
            get;
        }

        public InvalidNumberException(string number, int startPosition, int endPosition)
        {
            Number = number;
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
    }
}
