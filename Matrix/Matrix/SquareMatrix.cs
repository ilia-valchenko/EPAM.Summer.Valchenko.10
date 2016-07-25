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
        public delegate void MethodSet(int i, int j, T value);

        public event MethodSet OnSet;

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

        public virtual void Set(int i, int j, T value)
        {
            if(i < 0 || j < 0)
                throw new ArgumentException("Index of element can't be less then zero.");

            if(i > Size || j > Size)
                throw new ArgumentException("Index of element can't be greater then size of matrix.");

            if(value == null)
                throw new ArgumentNullException(nameof(value));

            innerArray[i][j] = value;

            OnSet(i, j, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            /*foreach (T item in innerArray)
                yield return item;*/
                throw new NotImplementedException();
        }      

        IEnumerator IEnumerable.GetEnumerator() => innerArray.GetEnumerator();

       public void PrintMatrix()
       {
           for (int i = 0; i < Size; i++)
           {
               for (int j = 0; j < Size; j++)
                   Console.Write(innerArray[i][j] + " ");

               Console.Write(Environment.NewLine);
           }
       }

        protected int size;
        protected T[][] innerArray;
    }
}
