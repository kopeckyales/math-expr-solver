using MathExprSolver.Exceptions;
using Xunit;

namespace MathExprSolver.Tests
{
    public class SolverTests
    {
        [Fact]
        public void BasicOperatorsTest()
        {
            Assert.Equal(1d, Solver.Solve("1"));
            Assert.Equal(2d, Solver.Solve("1+1"));
            Assert.Equal(0d, Solver.Solve("1-1"));
            Assert.Equal(2d, Solver.Solve("1*2"));
            Assert.Equal(1d, Solver.Solve("2/2"));
            Assert.Equal(2d % 2d, Solver.Solve("2%2"));
            Assert.Equal(4d, Solver.Solve("2^2"));
        }

        [Fact]
        public void PrecedenceRulesTest()
        {
            Assert.Equal(3d, Solver.Solve("1+1*2"));
            Assert.Equal(9d, Solver.Solve("1+2*2^2"));
            Assert.Equal(17d, Solver.Solve("1+2*2^2+2*2^2"));
            Assert.Equal(3d * 16d / 2d + 6d - 10d / 5d * 58d, Solver.Solve("3*16/2+6-10/5*58"));
        }

        [Fact]
        public void BracketsTest()
        {
            Assert.Equal(3d, Solver.Solve("(1+2)"));
            Assert.Equal(3d, Solver.Solve("((1+2))"));
            Assert.Equal(9d, Solver.Solve("(1+2)^2"));
            Assert.Equal(20d, Solver.Solve("(1+2^(1*2))*2^2"));
        }

        [Fact]
        public void PrefixTest()
        {
            Assert.Equal(0d, Solver.Solve("-1+1"));
            Assert.Equal(0d, Solver.Solve("1+(-1)"));
            Assert.Equal(-2d, Solver.Solve("-1+(-1)"));
            Assert.Equal(2d * -1d, Solver.Solve("2*-1"));
            Assert.Equal(-5d, Solver.Solve("-(2*2)-1"));
            Assert.Equal(0.25d, Solver.Solve("2^(-2)"));
            Assert.Equal(-(1d + 1d) * -(1d + 1d), Solver.Solve("-(1+1)*-(1+1)"));
            Assert.Equal(+(1d + 1d) * +(1d + 1d), Solver.Solve("+(1+1)*+(1+1)"));
        }

        [Fact]
        public void FloatAndLongNumbersTest()
        {
            Assert.Equal(7d, Solver.Solve("3.5*2"));
            Assert.Equal(3.505d * 2d / 15d + 6d - 5d / 26d * 58d, Solver.Solve("(((3.505*2)/15)+6)-((5/26)*58)"), 5);
            Assert.Equal(305050505d * 16d / 2d + 6d - 10d / 5d * 58d, Solver.Solve("305050505*16/2+6-10/5*58"));
        }

        [Fact]
        public void InvalidInputTest()
        {
            var ex = Assert.Throws<InvalidCharacterSequenceException>(() => Solver.Solve("((1+2)*)"));
            Assert.Equal(')', ex.Character);
            Assert.Equal(8, ex.Position);

            ex = Assert.Throws<InvalidCharacterSequenceException>(() => Solver.Solve("(1+2)(2+1)"));
            Assert.Equal('(', ex.Character);
            Assert.Equal(6, ex.Position);

            ex = Assert.Throws<InvalidCharacterSequenceException>(() => Solver.Solve("(1+2)-*2"));
            Assert.Equal('*', ex.Character);
            Assert.Equal(7, ex.Position);

            ex = Assert.Throws<InvalidCharacterSequenceException>(() => Solver.Solve("2(1+2)"));
            Assert.Equal('(', ex.Character);
            Assert.Equal(2, ex.Position);

            ex = Assert.Throws<InvalidCharacterSequenceException>(() => Solver.Solve("*2"));
            Assert.Equal('*', ex.Character);
            Assert.Equal(1, ex.Position);
        }

        [Fact]
        public void UnexpectedEndOfInputTest()
        {
            Assert.Throws<UnexpectedEndOfInputException>(() => Solver.Solve("1+"));
            Assert.Throws<UnexpectedEndOfInputException>(() => Solver.Solve("1*"));
            Assert.Throws<UnexpectedEndOfInputException>(() => Solver.Solve("("));
            Assert.Throws<UnexpectedEndOfInputException>(() => Solver.Solve("((1+2)"));
        }

        [Fact]
        public void InvalidNumberTest()
        {
            var ex = Assert.Throws<InvalidNumberException>(() => Solver.Solve("1.0.0+2"));
            Assert.Equal("1.0.0", ex.Number);
            Assert.Equal(1, ex.StartPosition);
            Assert.Equal(5, ex.EndPosition);
            ex = Assert.Throws<InvalidNumberException>(() => Solver.Solve("(1^1.000.001)+2"));
            Assert.Equal("1.000.001", ex.Number);
            Assert.Equal(4, ex.StartPosition);
            Assert.Equal(12, ex.EndPosition);
        }
    }
}
