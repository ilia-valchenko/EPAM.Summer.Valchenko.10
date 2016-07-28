using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SumOfSquareAndSymmetricVisitor<T> : MatrixVisitor<T>
    {
        public SumOfSquareAndSymmetricVisitor(Func<T, T, T> sumOfTwoTypesOperation)
        {
            this.sumOfTwoTypesOperation = sumOfTwoTypesOperation;
        }

        public override Matrix<T> Operation(Matrix<T> A, Matrix<T> B)
        {
            if (A == null)
                throw new ArgumentNullException(nameof(A));

            if (B == null)
                throw new ArgumentNullException(nameof(B));

            if (A.Size != B.Size)
                throw new ArgumentException("The matrices have different dimensions.");

            var result = new T[A.Size][];

            for (int i = 0; i < result.Length; i++)
                result[i] = new T[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    if (j > i)
                        result[i][j] = sumOfTwoTypesOperation(A.GetValue(j, i), B.GetValue(i, j));
                    else
                        result[i][j] = sumOfTwoTypesOperation(A.GetValue(i, j), B.GetValue(i, j));
                }
            }

            return new SquareMatrix<T>(result);
        }

        private readonly Func<T, T, T> sumOfTwoTypesOperation;
    }
}
