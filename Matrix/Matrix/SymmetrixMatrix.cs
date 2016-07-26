using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetrixMatrix<T> : Matrix<T>
    {
        public event MethodSet OnSetValue;

        public SymmetrixMatrix(T[][] array) 
        {
            if(array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
                if (array[i].Length != array.Length)
                    throw new ArgumentException("Input array must be square.");

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                    if(!array[i][j].Equals(array[j][i]))
                        throw new ArgumentException("The array has no elements symmetric about the main diagonal.");

            Size = array.Length;

            triangleArray = new T[Size][];

            for (int i = 1; i <= Size; i++)
                triangleArray[i - 1] = new T[i];

            for(int i = 0; i < Size; i++)
                for (int j = 0; j < triangleArray[i].Length; j++)
                    triangleArray[i][j] = array[i][j];
        }

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
                    if(j > i)
                        yield return triangleArray[j][i];
                    else
                        yield return triangleArray[i][j];
                }
            }
        }

        private readonly T[][] triangleArray;
    }
}
