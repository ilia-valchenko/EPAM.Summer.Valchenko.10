using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// This is the base class of all matrices. It defines the basic behavior for all matrices.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        #region Public fields and properties
        /// <summary>
        /// Property which represents a size of matrix.
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Size of matrix can't be less or equal to zero.");

                size = value;
            }
        }

        /// <summary>
        /// This delegate encapsulates the method that responds to changes in the matrix element.
        /// </summary>
        /// <param name="i">Number of row of current matrix.</param>
        /// <param name="j">Number of column of current matrix.</param>
        /// <param name="value">A new value.</param>
        public delegate void MethodSet(int i, int j, T value);
        #endregion

        /// <summary>
        /// This method provides a new operation for current matrix.
        /// </summary>
        /// <param name="visitor">An instance of concrete visitor.</param>
        /// <param name="matrix">The second operand for custom operation.</param>
        /// <returns>Returns a new matrix which represetns the result of binary operation.</returns>
        public Matrix<T> Accept(MatrixVisitor<T> visitor, Matrix<T> matrix) => visitor.Operation(this, matrix);

        #region Abstract methods
        /// <summary>
        /// This method gets a value from i,j position of current matrix.
        /// </summary>
        /// <param name="i">Number of row of current matrix.</param>
        /// <param name="j">Number of column of current matrix.</param>
        /// <returns>Returns value from i,j position.</returns>
        public abstract T GetValue(int i, int j);

        /// <summary>
        /// This method sets a value to i,j position of current matrix.
        /// </summary>
        /// <param name="i">Number of row of current matrix.</param>
        /// <param name="j">Number of column of current matrix.</param>
        /// <param name="value">A new value.</param>
        public abstract void SetValue(int i, int j, T value);

        /// <summary>
        /// This method returns an enumerator.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through a collection.</returns>
        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
        #endregion

        /// <summary>
        /// Size of matrix.
        /// </summary>
        protected int size;
    }
}
