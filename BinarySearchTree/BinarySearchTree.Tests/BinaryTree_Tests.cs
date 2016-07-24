using System;
using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinaryTree_Tests
    {
        private BinaryTree<int> treeInt32 = new BinaryTree<int>() {7, 5, 4, 6, 1, 8, 7, 10};

        [TestCase(TestName = "Int32PreorderTraversal", ExpectedResult = new int[] {})]
        public void TestInt32Traversal()
        {
        }
    }
}
