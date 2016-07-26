using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class MatrixVisitor<T>
    {
        public abstract SquareMatrix<T> Add(SquareMatrix<T> A, SquareMatrix<T> B);
        public abstract SquareMatrix<T> Add(SquareMatrix<T> A, SymmetrixMatrix<T> B);
        public abstract SquareMatrix<T> Add(SquareMatrix<T> A, DiagonalMatrix<T> B);

        public abstract SymmetrixMatrix<T> Add(SymmetrixMatrix<T> A, SymmetrixMatrix<T> B);
        public abstract SymmetrixMatrix<T> Add(SymmetrixMatrix<T> A, DiagonalMatrix<T> B);

        public abstract DiagonalMatrix<T> Add(DiagonalMatrix<T> A, DiagonalMatrix<T> B);
    }
}
