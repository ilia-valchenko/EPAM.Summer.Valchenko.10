using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    /// <summary>
    /// FibonacciMath is the class which allows users to get a sequence of Fibonacci numbers.
    /// </summary>
    public static class FibonacciMath
    {
        /// <summary>
        /// This method calcs Fibonacci numbers.
        /// </summary>
        /// <param name="amount">The number of required Fibonacci numbers.</param>
        /// <returns>Fibonnaci numbers.</returns>
        public static IEnumerable GetFibonacciNumbers(int amount)
        {
            for (int i = 1, previous = 0, current = 1; i < amount; i++)
            {
                int next = current + previous;
                previous = current;
                current = next;

                yield return next;
            }
        }
    }
}
