using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// This class represetns a symmetric matrix type of T. 
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class SymmetrixMatrix<T> : Matrix<T>
    {
        #region Public fields and properties
        /// <summary>
        /// The event that the element responds to changes in the matrix.
        /// </summary>
        public event MethodSet OnSetValue;
        #endregion

        #region Constructors
        /// <summary>
        /// This constructor takes triangle jagged array as input parameter.
        /// </summary>
        /// <param name="array">Triangle jagged array which consists of unique matrix elements.</param>
        public SymmetrixMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
                if (array[i].Length != array.Length)
                    throw new ArgumentException("Input array must be square.");

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                    if (!array[i][j].Equals(array[j][i]))
                        throw new ArgumentException("The array has no elements symmetric about the main diagonal.");

            Size = array.Length;

            triangleArray = new T[Size][];

            for (int i = 1; i <= Size; i++)
                triangleArray[i - 1] = new T[i];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < triangleArray[i].Length; j++)
                    triangleArray[i][j] = array[i][j];
        }
        #endregion

        #region GetValue and SetValue methods
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

            if (j > i)
                return triangleArray[j][i];

            return triangleArray[i][j];
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

            if (i != j)
                throw new ArgumentException("You can't change non-diagonal element of matrix. You need to change both symmetric values.");

            triangleArray[i][j] = value;

            OnSetValue?.Invoke(i, j, value);
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
            {
                for (int j = 0; j < Size; j++)
                {
                    if (j > i)
                        yield return triangleArray[j][i];
                    else
                        yield return triangleArray[i][j];
                }
            }
        }
        #endregion

        #region Private fields and properties
        /// <summary>
        /// Jagged array which represents container for symmetrix matrix.
        /// </summary>
        private readonly T[][] triangleArray; 
        #endregion
    }
}
