using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueGeneric
{
    /// <summary>
    /// This class represents a custom generic queue.
    /// </summary>
    /// <typeparam name="T">T is the type which queue contains.</typeparam>
    public class Queue<T>
    {
        #region Public fields and properties
        /// <summary>
        /// This property returns true if queue is empty and false if it's not.
        /// </summary>
        public bool IsEmpty => indexOfFirstElement > indexOfLastElement || (indexOfFirstElement == -1 && indexOfLastElement == -1);
        /// <summary>
        /// This property returns number of elements in queue.
        /// </summary>
        public int Count => indexOfLastElement - indexOfFirstElement + 1;
        #endregion

        #region Constructors
        /// <summary>
        /// Public default constructor.
        /// </summary>
        public Queue()
        {
            array = new T[10];
            indexOfLastElement = -1;
            indexOfFirstElement = -1;
        } 
        #endregion

        #region Basic queue operations
        /// <summary>
        /// This method adds new elements to the end of queue.
        /// </summary>
        /// <param name="value">Element which must be added.</param>
        public void Enqueue(T value)
        {
            if (indexOfLastElement == array.Length - 1)
            {
                T[] bufferArr = new T[array.Length];

                for (int i = 0; i < array.Length - 1; i++)
                    bufferArr[i] = array[i];

                array = new T[2 * array.Length];

                for (int i = 0; i < bufferArr.Length - 1; i++)
                    array[i] = bufferArr[i];
            }

            if (IsEmpty)
                indexOfFirstElement = 0;

            indexOfLastElement++;
            array[indexOfLastElement] = value;
        }

        /// <summary>
        /// This method takes the first element of queue and returns it. This element will be remove after this.
        /// </summary>
        /// <returns>The first element of queue.</returns>
        public T Dequeue()
        {
            if (!IsEmpty)
            {
                T result = array[indexOfFirstElement];
                array[indexOfFirstElement] = default(T);
                indexOfFirstElement++;
                return result;
            }
            else throw new InvalidOperationException("Queue is empty!");
        }

        /// <summary>
        /// This method returns the first element of queue without removing.
        /// </summary>
        /// <returns>The first element of queue.</returns>
        public T Peek()
        {
            if (!IsEmpty)
                return array[indexOfFirstElement];
            throw new InvalidOperationException("Queue is empty!");
        }
        #endregion

        #region Optional operations
        /// <summary>
        /// This method returns all elements of queue as an array.
        /// </summary>
        /// <returns>Array of queue's elements.</returns>
        public T[] GetArrayOfQueueElements()
        {
            T[] arrayOfStackElements = new T[Count];

            for (int i = indexOfFirstElement, j = 0; i <= indexOfLastElement; i++, j++)
                arrayOfStackElements[j] = array[i];

            return arrayOfStackElements;
        }
        #endregion

        #region Custom iterator
        /// <summary>
        /// This is 'this' property.
        /// </summary>
        /// <param name="index">Index of element.</param>
        /// <returns>Element by given index.</returns>
        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        /// <summary>
        /// This method returns custom iterator for queue.
        /// </summary>
        /// <returns>Instnce of custom iterator.</returns>
        public CustomIterator GetEnumerator() => new CustomIterator(this);

        /// <summary>
        /// This struct represents a custom iterator.
        /// </summary>
        public struct CustomIterator
        {
            private readonly Queue<T> collection;
            private int currentIndex;

            internal CustomIterator(Queue<T> collection)
            {
                this.currentIndex = -1;
                this.collection = collection;
            }

            /// <summary>
            /// This property returns current element.
            /// </summary>
            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Count)
                        throw new InvalidOperationException();
                    return collection[currentIndex];
                }
            }
            
            /// <summary>
            /// This method set interator counter to default.
            /// </summary>
            public void Reset() => currentIndex = collection.indexOfFirstElement;

            /// <summary>
            /// This method determines can we move to the next item or not.
            /// </summary>
            /// <returns>True if we can move to the next item in collection.</returns>
            public bool MoveNext() => ++currentIndex < collection.Count;
        } 
        #endregion

        #region Private fields
        /// <summary>
        /// Array which contains of queue's elements.
        /// </summary>
        private T[] array;
        /// <summary>
        /// Index of the last element of queue.
        /// </summary>
        private int indexOfLastElement;
        /// <summary>
        /// Index of the first element of queue.
        /// </summary>
        private int indexOfFirstElement;
        #endregion
    }
}
