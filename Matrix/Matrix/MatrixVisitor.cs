using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class MatrixVisitor<T>
    {
        public abstract Matrix<T> Operation(Matrix<T> A, Matrix<T> B);
    }
}
