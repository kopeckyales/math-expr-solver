using System;

namespace MathExprSolver.Exceptions
{
    public class InvalidCharacterSequenceException : Exception
    {
        public char Character
        {
            get;
        }

        public int Position
        {
            get;
        }

        public InvalidCharacterSequenceException(char character, int position)
        {
            Character = character;
            Position = position;
        }
    }
}
