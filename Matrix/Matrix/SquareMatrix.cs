using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// This class represents a square matrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        #region Public fields and properties
        /// <summary>
        /// The event that the element responds to changes in the matrix.
        /// </summary>
        public event MethodSet OnSetValue; 
        #endregion

        #region Constructors
        /// <summary>
        /// This constructor takes one-dimensional array. The matrix size is equal to the square root of the number of elements of the input array.
        /// </summary>
        /// <param name="array">One-dimensional array which represents all elements of matrix.</param>
        public SquareMatrix(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var sqrt = Math.Sqrt(array.Length);

            if (Math.Abs(Math.Ceiling(sqrt) - Math.Floor(sqrt)) > Double.Epsilon)
                throw new ArgumentException("Square root of numbers of elements in source array must be an integer.");

            Size = (int)Math.Sqrt(array.Length);

            innerArray = new T[Size, Size];

            for (int i = 0, h = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    innerArray[i, j] = array[h];
                    h++;
                }
            }
        }

        /// <summary>
        /// This constructor takes square two-dimensional array which will be represent a new square matrix.
        /// </summary>
        /// <param name="array">Square two-dimensional array.</param>
        public SquareMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            foreach (T[] row in array)
                if (row.Length != array.Length)
                    throw new ArgumentException("Input array must be square.");

            Size = array.Length;

            innerArray = new T[Size, Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    innerArray[i, j] = array[i][j];
        }

        /// <summary>
        /// This constructor takes multidimensional square array which will be represent a new square matrix.
        /// </summary>
        /// <param name="array">Square multidimensional matrix.</param>
        public SquareMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var sqrt = Math.Sqrt(array.Length);

            if (Math.Abs(Math.Ceiling(sqrt) - Math.Floor(sqrt)) > Double.Epsilon)
                throw new ArgumentException("Input array not a square array.");

            Size = (int)sqrt;

            innerArray = array;
        }
        #endregion

        #region Get and Set mathods
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

            return innerArray[i, j];
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

            innerArray[i, j] = value;

            OnSetValue(i, j, value);
        }
        #endregion

        #region Enumerator
        /// <summary>
        /// This method returns an enumerator.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through a collection.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return innerArray[i, j];
        }
        #endregion

        #region Private fields and properties
        /// <summary>
        /// Multidimensional array which represents elements of square matrix.
        /// </summary>
        private readonly T[,] innerArray; 
        #endregion
    }
}
