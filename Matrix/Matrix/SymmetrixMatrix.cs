using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetrixMatrix<T> : Matrix<T>
    {
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

            // TO-DO
        }

        public override T GetValue(int i, int j)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(int i, int j, T value)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private readonly T[][] triangleArray;
    }
}
