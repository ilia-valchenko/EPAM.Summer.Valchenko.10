using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        #region Public fields and properties

        public event MethodSet OnSetValue; 

        #endregion

        public SquareMatrix(T[] array)
        {
            if(array == null)
                throw new ArgumentNullException(nameof(array));

            var sqrt = Math.Sqrt(array.Length);

            if(Math.Abs(Math.Ceiling(sqrt) - Math.Floor(sqrt)) > Double.Epsilon)
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

        public SquareMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
                if(array[i].Length != array.Length)
                    throw new ArgumentException("Input array must be square.");

            Size = array.Length;

            innerArray = new T[Size, Size];

            for (int i = 0, h = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    innerArray[i,j] = array[i][j];
        }

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

        public override T GetValue(int i, int j)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Index of element can't be less then zero.");

            if (i > Size || j > Size)
                throw new ArgumentException("Index of element can't be greater then size of matrix.");

            return innerArray[i, j];
        }

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

        public override Matrix<T> Accept(MatrixVisitor<T> visitor, Matrix<T> matrix)
        {
            return visitor.Add(this, (dynamic)matrix);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return innerArray[i, j];
        }

        private readonly T[,] innerArray;
    }
}
