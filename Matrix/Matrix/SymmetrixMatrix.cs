using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetrixMatrix<T> : SquareMatrix<T> where T : IEquatable<T>
    {
        public SymmetrixMatrix(T[] array) : base(array)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if(!innerArray[i][j].Equals(innerArray[j][i]))
                        throw new ArgumentException("The elements of the matrix must be symmetrical about the main diagonal.");
                }
            }
        }
    }
}
