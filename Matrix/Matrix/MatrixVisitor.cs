using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// This class extends the base class Matrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public abstract class MatrixVisitor<T>
    {
        /// <summary>
        /// This is a custom binary operation of matrices.
        /// </summary>
        /// <param name="A">The first matrix.</param>
        /// <param name="B">The second matrix.</param>
        /// <returns>Returns a new matrix which represetns the result of binary operation.</returns>
        public abstract Matrix<T> Operation(Matrix<T> A, Matrix<T> B);
    }
}
