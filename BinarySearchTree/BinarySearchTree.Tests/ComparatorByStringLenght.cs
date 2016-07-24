using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    public class ComparatorByStringLenght : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if(x == null)
                throw new ArgumentNullException(nameof(x));

            if(y == null)
                throw new ArgumentNullException(nameof(y));

            return x.Length.CompareTo(y.Length);
        }
    }
}
