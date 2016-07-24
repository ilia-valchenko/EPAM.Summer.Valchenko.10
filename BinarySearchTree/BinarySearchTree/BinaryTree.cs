using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// This class represents a BST.
    /// </summary>
    /// <typeparam name="T">T is a type of BST's elements.</typeparam>
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>, IEquatable<T>
    {
        #region Public fields and properties
        /// <summary>
        /// Number of elements in BST.
        /// </summary>
        public int Count => count;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor which creates empty BST.
        /// </summary>
        public BinaryTree()
        {
            head = null;
            count = 0;
        }
        #endregion

        #region Basic BTS operations
        /// <summary>
        /// This method adds elements to the BST.
        /// </summary>
        /// <param name="value">Value which will be added.</param>
        public void Add(T value)
        {
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            if (ReferenceEquals(head, null))
                head = new Node(value);

            AddTo(head, value);

            count++;
        }

        /// <summary>
        /// This is helper method which use recursion for adding value to the BST. 
        /// </summary>
        /// <param name="node">The node that will be used to determine on what go further subtree.</param>
        /// <param name="value">Value which will be added.</param>
        private void AddTo(Node node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        /// <summary>
        /// This method finds BST's node by given value.
        /// </summary>
        /// <param name="value">Value which one of nodes might contains.</param>
        /// <returns>Returns node if the BST contains this value or null if it not.</returns>
        public Node FindByValue(T value) => Find(head, value);

        /// <summary>
        /// This is the helper method which is called by FindByValue method. 
        /// </summary>
        /// <param name="node">The node that will be used to determine on what go further subtree.</param>
        /// <param name="value">Seeking value.</param>
        /// <returns>Returns node if the BST contains this value or null if it not.</returns>
        private Node Find(Node node, T value)
        {
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            if (ReferenceEquals(node, null))
                return null;
            
            if (node.Value.CompareTo(value) == 0)
                return node;

            if (node.Value.CompareTo(value) > 0)
                return Find(node.Left, value);

            return Find(node.Right, value);
        }
        #endregion

        #region Traversal methods
        /// <summary>
        /// Display the data part of the root (or current node). Traverse the left subtree by recursively calling the pre-order function. Traverse the right subtree by recursively calling the pre-order function.
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Preorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<Node>();

            if (!ReferenceEquals(head.Left, null))
                roots.Push(head.Left);

            if (!ReferenceEquals(head.Right, null))
                roots.Push(head.Right);

            while (roots.Any())
            {
                var root = roots.Pop();
                yield return root.Value;

                if (!ReferenceEquals(root.Left, null))
                    roots.Push(root.Left);

                if (!ReferenceEquals(root.Right, null))
                    roots.Push(root.Right);
            }
        }

        /// <summary>
        /// Traverse the left subtree by recursively calling the in-order function. Display the data part of the root (or current node). Traverse the right subtree by recursively calling the in-order function.
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Inorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<Node>();

            var current = head;

            bool isDone = false;

            while (!isDone)
            {
                if (!ReferenceEquals(current, null))
                {
                    roots.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (!roots.Any())
                    {
                        isDone = true;
                    }
                    else
                    {
                        current = roots.Pop();
                        yield return current.Value;
                        current = current.Right;
                    }
                }
            }
        }

        // Non recursion
        //private IEnumerator<T> Postorder()
        //{
        //    if (ReferenceEquals(head, null))
        //        throw new InvalidOperationException("Tree is empty!");

        //    var roots = new Stack<Node>();

        //    var current = head;

        //    bool isDone = false;

        //    while (!isDone)
        //    {
        //        if (!ReferenceEquals(current, null))
        //        {
        //            roots.Push(current);
        //            current = current.Left;
        //        }
        //        else
        //        {
        //            if (!roots.Any())
        //            {
        //                isDone = true;
        //            }
        //            else
        //            {
        //                current = roots.Peek().Right;

        //                if (current != null)
        //                {
        //                    yield return roots.Pop().Value;
        //                    current = roots.Pop().Right;
        //                }
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Post-order traversal with recursion. Traverse the left subtree by recursively calling the post-order function. Traverse the right subtree by recursively calling the post-order function. Display the data part of the root (or current node).
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Postorder() => DoPostOrder(head);

        /// <summary>
        /// This is the helper method which uses recurcion.
        /// </summary>
        /// <param name="node">Node for finding subtree.</param>
        /// <returns>Returns IEnumerable.</returns>
        private IEnumerable<T> DoPostOrder(Node node)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.Left != null)
            {
                foreach (var leftNode in DoPostOrder(node.Left))
                {
                    yield return leftNode;
                }
            }

            if (node.Right != null)
            {
                foreach (var rightNode in DoPostOrder(node.Right))
                {
                    yield return rightNode;
                }
            }

            yield return node.Value;
        }
        #endregion

        #region ICollection implementation

        bool ICollection<T>.IsReadOnly => false;

        /// <summary>
        /// Clear the BST.
        /// </summary>
        public void Clear() => head = null;

        /// <summary>
        /// This method determines BST contains given element or not.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns true if it contains given element.</returns>
        public bool Contains(T item)
        {
            if (!ReferenceEquals(FindByValue(item), null))
                return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destinationArray"></param>
        /// <param name="startIndex"></param>
        public void CopyTo(T[] destinationArray, int startIndex)
        {
            if (ReferenceEquals(destinationArray, null))
                throw new ArgumentNullException(nameof(destinationArray));

            if (startIndex < 0)
                throw new ArgumentException("Start index can't be less than zero.");

            if (startIndex > destinationArray.Length)
                throw new ArgumentException("Start index can't be greater than lenght of destination array.");

            if ((destinationArray.Length - 1 - startIndex) < Count)
                throw new ArgumentException("Number of tree's elements is greater then given array range.");

            foreach (T item in Inorder())
            {
                destinationArray[startIndex] = item;
                startIndex++;
            }
        }

        /// <summary>
        /// This method returs enumerator.
        /// </summary>
        /// <returns>Returns IEnumerator.</returns>
        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Remove element in tree by the value.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            throw new NotSupportedException();
        } 
        #endregion

        #region Node
        /// <summary>
        /// This class represents the node of BST.
        /// </summary>
        public class Node
        {
            /// <summary>
            /// Left node.
            /// </summary>
            public Node Left { get; set; }
            /// <summary>
            /// Right node.
            /// </summary>
            public Node Right { get; set; }

            /// <summary>
            /// Value of the current node.
            /// </summary>
            public T Value
            {
                get
                {
                    return value;
                }
                private set
                {
                    if (ReferenceEquals(value, null))
                        throw new ArgumentException("Value of tree's node can't be null.");

                    this.value = value;
                }
            }

            /// <summary>
            /// Default constructor.
            /// </summary>
            public Node() : this(default(T)) { }

            /// <summary>
            /// Constructor with parameter.
            /// </summary>
            /// <param name="value"></param>
            public Node(T value)
            {
                Value = value;
            }

            /// <summary>
            /// Overrided ToString method.
            /// </summary>
            /// <returns>Representation of node in string foemat.</returns>
            public override string ToString()
            {
                if (ReferenceEquals(Left, null))
                {
                    if (ReferenceEquals(Right, null))
                        return $"Value: {value}, left: empty, right: empty.";
                    return $"Value: {value}, left: empty, right: {Right.Value}";
                }

                if (ReferenceEquals(Right, null))
                    return $"Value: {value}, left: {Left.value}, right: empty.";

                return $"Value: {value}, left: {Left.value}, right: {Right.value}.";
            }

            /// <summary>
            /// Value of the node.
            /// </summary>
            private T value;
        }
        #endregion

        #region Private fields and properties
        /// <summary>
        /// Main root of BST.
        /// </summary>
        private Node head;
        /// <summary>
        /// Number of elements in BST.
        /// </summary>
        private int count; 
        #endregion
    }
}
