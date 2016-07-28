using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// This class represents a diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class DiagonalMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// The event that the element responds to changes in the matrix.
        /// </summary>
        public event MethodSet OnSetValue;

        /// <summary>
        /// This constructor takes one-dimensional array which represents elements of diagonal elements.
        /// </summary>
        /// <param name="arrayOfDiagonalElements">One-dimensional array which represents elements of diagonal elements</param>
        public DiagonalMatrix(T[] arrayOfDiagonalElements) 
        {
            if(arrayOfDiagonalElements == null)
                throw new ArgumentNullException(nameof(arrayOfDiagonalElements));

            Size = arrayOfDiagonalElements.Length;

            this.arrayOfDiagonalElements = arrayOfDiagonalElements;
        }

        /// <summary>
        /// This method gets a value from i,j position of current matrix.
        /// </summary>
        /// <param name="i">Number of row of current matrix.</param>
        /// <param name="j">Number of column of current matrix.</param>
        /// <returns>Returns value from i,j position.</returns>
        public override T GetValue(int i, int j)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Index of element can't be less then zero.");

            if (i > Size || j > Size)
                throw new ArgumentException("Index of element can't be greater then size of matrix.");

            if (i != j)
                return default(T);

            return arrayOfDiagonalElements[i];
        }

        /// <summary>
        /// This method sets a value to i,j position of current matrix.
        /// </summary>
        /// <param name="i">Number of row of current matrix.</param>
        /// <param name="j">Number of column of current matrix.</param>
        /// <param name="value">A new value.</param>
        public override void SetValue(int i, int j, T value)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Index of element can't be less then zero.");

            if (i > Size || j > Size)
                throw new ArgumentException("Index of element can't be greater then size of matrix.");

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if(i != j)
                throw new InvalidOperationException("A diagonal matrix contains the default values are located outside the main diagonal.");

            arrayOfDiagonalElements[i] = value;

            OnSetValue?.Invoke(i, j, value);
        }

        /// <summary>
        /// This method returns an enumerator.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through a collection.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i != j)
                        yield return default(T);
                    else
                        yield return arrayOfDiagonalElements[i];
                }
            }
        }

        /// <summary>
        /// Array of diagonal elements of current diagonal matrix.
        /// </summary>
        private readonly T[] arrayOfDiagonalElements;
    }
}
