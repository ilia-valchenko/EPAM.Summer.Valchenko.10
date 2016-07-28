using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// This class represent a han
    /// </summary>
    public class Handler
    {
        /// <summary>
        /// This method prints message to console if one of matrix elements were changed.
        /// </summary>
        /// <typeparam name="T">Type of matrix elements.</typeparam>
        /// <param name="i">Number of row.</param>
        /// <param name="j">Number of column.</param>
        /// <param name="value">The new value that has been assigned.</param>
        public void Message<T>(int i ,int j, T value)
        {
            Console.WriteLine($"Element [{i}][{j}] was changed. New value is {value}.");
        }
    }
}
