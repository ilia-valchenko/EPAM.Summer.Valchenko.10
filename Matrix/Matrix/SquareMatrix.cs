using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : IEnumerable<T> where T : IEquatable<T>
    {
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if(value <= 0)
                    throw new ArgumentException("Size of matrix can't be less or equal to zero.");

                size = value;
            }
        }

        public SquareMatrix(T[] array)
        {
            if(array == null)
                throw new ArgumentNullException(nameof(array));

            var sqrt = Math.Sqrt(array.Length);

            if(Math.Abs(Math.Ceiling(sqrt) - Math.Floor(sqrt)) > Double.Epsilon)
                throw new ArgumentException("Square root of numbers of elements in source array must be an integer.");

            Size = (int)Math.Sqrt(array.Length);

            innerArray = new T[Size][];

            for(int i = 0; i < Size; i++)
                innerArray[i] = new T[Size];

            for (int i = 0, h = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    innerArray[i][j] = array[h];
                    h++;
                }
            }
        }

        /*public SquareMatrix(int size, T[] array)
        {
            Size = size;
            
            if(array.Length < size * size)
                throw new ArgumentException("Number of elements in source array is less then number of elements in matrix.");

            innerArray = new T[Size, Size];

            for (int i = 0, h = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    innerArray[i,j] = array[h];
                    h++;
                }
            }
        }*/

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Size; i++)
            	for(int j = 0; j < Size; j++)
            		yield return innerArray[i][j];
        }      

        IEnumerator IEnumerable.GetEnumerator() => innerArray.GetEnumerator();

        protected int size;
        protected T[][] innerArray;
    }
}
