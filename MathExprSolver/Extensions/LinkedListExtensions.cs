using System.Collections.Generic;
using System.Linq;

namespace MathExprSolver.Extensions
{
    internal static class LinkedListExtensions
    {
        internal static LinkedListNode<T> FindByMany<T>(this LinkedList<T> list, IEnumerable<T> nodes)
        {
            return list.Where(nodes.Contains).Select(list.Find).FirstOrDefault();
        }
    }
}
