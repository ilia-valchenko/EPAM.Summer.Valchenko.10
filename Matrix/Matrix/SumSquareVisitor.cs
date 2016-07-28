using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SumSquareVisitor<T> : MatrixVisitor<T>
    {
        public override Matrix<T> Operation(Matrix<T> A, Matrix<T> B)
        {
            if(A == null)
                throw new ArgumentNullException(nameof(A));

            if(B == null)
                throw new ArgumentNullException(nameof(B));

            if(A.Size != B.Size)
                throw new ArgumentException("The matrices have different dimensions.");

            var reault = new T[A.Size][];

            for (int i = 0; i < reault.Length; i++)
                reault[i] = new T[reault.Length];

            for (int i = 0; i < reault.Length; i++)
            {
                for (int j = 0; j < reault.Length; j++)
                {
                    try
                    {
                        reault[i][j] = (dynamic) A.GetValue(i, j) + B.GetValue(i, j);
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("Cannot apply Operator '+' to operands of type T and T");
                    }
                }   
            }
                
            return new SquareMatrix<T>(reault);
        }
    }
}
