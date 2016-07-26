using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class Matrix<T> : IEnumerable<T>
    {
        public delegate void MethodSet(int i, int j, T value);
        public abstract T GetValue(int i, int j);
        public abstract void SetValue(int i, int j, T value);
        public abstract Matrix<T> Accept(MatrixVisitor<T> visitor, Matrix<T> matrix);
        public abstract IEnumerator<T> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

        protected int size;
    }
}
