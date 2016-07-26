using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        #region Public fields and properties

        public event MethodSet OnSetValue;

        #endregion

        public DiagonalMatrix(T[] arrayOfDiagonalElements) 
        {
            if(arrayOfDiagonalElements == null)
                throw new ArgumentNullException(nameof(arrayOfDiagonalElements));

            Size = arrayOfDiagonalElements.Length;

            this.arrayOfDiagonalElements = arrayOfDiagonalElements;
        }

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

            OnSetValue(i, j, value);
        }

        public override Matrix<T> Accept(MatrixVisitor<T> visitor, Matrix<T> matrix)
        {
            throw new NotImplementedException();
        }

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

        private readonly T[] arrayOfDiagonalElements;
    }
}
