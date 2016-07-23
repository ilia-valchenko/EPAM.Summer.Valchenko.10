using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>, IEquatable<T>
    {
        #region Public fields and properties
        public int Count => count;
        #endregion

        #region Constructors
        public BinaryTree()
        {
            head = null;
            count = 0;
        } 
        #endregion

        public void Add(T value)
        {
            if(ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            if(ReferenceEquals(head, null))
                head = new Node(value);

            AddTo(head, value);

            count++;
        }

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

        public Node FindByValue(T value) => Find(head, value);

        private Node Find(Node node, T value)
        {
            if(ReferenceEquals(value, null))
                throw new ArgumentNullException(nameof(value));

            if(ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            if(ReferenceEquals(node, null))
                throw new ArgumentNullException(nameof(node));

            if (node.Value.CompareTo(value) == 0)
                return node;

            if (node.Value.CompareTo(value) > 0)
                return Find(node.Left, value);
            
            return Find(node.Right, value);
        }

        public IEnumerator<T> Preorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<Node>();

            if(!ReferenceEquals(head.Left, null))
                roots.Push(head.Left);

            if (!ReferenceEquals(head.Right, null))
                roots.Push(head.Right);

            while (roots.Any())
            {
                var root = roots.Pop();
                yield return root.Value;

                if(!ReferenceEquals(root.Left, null))
                    roots.Push(root.Left);

                if (!ReferenceEquals(root.Right, null))
                    roots.Push(root.Right);
            }
        }

        public IEnumerator<T> Inorder()
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

        // recursion
        // fix it
        public IEnumerator<T> Postorder(Node node)
        {
            if(ReferenceEquals(node, null))
                throw new ArgumentNullException(nameof(node));

            if (!ReferenceEquals(node.Left, null))
                Postorder(node.Left);

            if (!ReferenceEquals(node.Right, null))
                Postorder(node.Right);

            yield return node.Value;
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return Preorder();
            //return Inorder();
            return Postorder(head);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }

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

            public Node() : this(default(T)) { }

            public Node(T value)
            {
                Value = value;
            }

            /*public int CompareTo(Node other) => value.CompareTo(other.value);

            public bool Equals(Node other)
            {
                if(ReferenceEquals(other, null))
                    throw new ArgumentNullException(nameof(other));

                if (this.Value.Equals(other.Value))
                    return true;

                return false;
            }*/

            public override string ToString()
            {
                if (ReferenceEquals(Left, null))
                {
                    if (ReferenceEquals(Right, null))
                        return $"Value: {value}, left: empty, right: empty.";
                    return $"Value: {value}, left: empty, right: {Right.Value}";
                }

                if(ReferenceEquals(Right, null))
                    return $"Value: {value}, left: {Left.value}, right: empty.";

                return $"Value: {value}, left: {Left.value}, right: {Right.value}.";
            }

            private T value;
        }

        private Node head;
        private int count;
    }
}
