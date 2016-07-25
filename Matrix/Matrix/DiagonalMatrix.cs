using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T> where T : IEquatable<T>
    {
        public DiagonalMatrix(T[] arrayOfDiagonalElements) : base(new T[] {default(T)})
        {
            if(arrayOfDiagonalElements == null)
                throw new ArgumentNullException(nameof(arrayOfDiagonalElements));

            Size = arrayOfDiagonalElements.Length;

            innerArray = new T[Size][];

            for(int i = 0; i < Size; i++)
                innerArray[i] = new T[Size];

            for (int i = 0, h = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i != j)
                        innerArray[i][j] = default(T);
                    else
                    {
                        innerArray[i][j] = arrayOfDiagonalElements[h];
                        h++;
                    }
                }
            }
        }
    }
}
