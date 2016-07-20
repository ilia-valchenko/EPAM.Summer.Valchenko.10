using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueGeneric
{
    public class Queue<T>
    {
        #region Public fields and properties
        public bool isEmpty => indexOfFirstElement > indexOfLastElement;
        public int IndexOfFirstElement => indexOfFirstElement;
        public int IndexOfLastElement => indexOfLastElement;
        #endregion

        public Queue()
        {
            array = new T[10];
            indexOfLastElement = -1;
            indexOfFirstElement = -1;
        }

        #region Basic queue operations
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

            indexOfLastElement++;
            array[indexOfLastElement] = value;
        }

        public T Dequeue()
        {
            if (!isEmpty)
            {
                T result = array[indexOfFirstElement];
                array[indexOfFirstElement] = default(T);
                indexOfFirstElement++;
                indexOfCurrentElement = indexOfFirstElement;
                return result;
            }
            else throw new InvalidOperationException();
        }

        public T Peek()
        {
            if (!isEmpty)
                return array[indexOfFirstElement];
            throw new InvalidOperationException();
        }
        #endregion

        public T[] GetArrayOfQueueElements()
        {
            T[] arrayOfStackElements = new T[indexOfLastElement + 1];

            for (int i = 0; i <= indexOfLastElement; i++)
                arrayOfStackElements[i] = array[i];

            return arrayOfStackElements;
        }

        private class CustomEnumerator : IEnumerator<T>
        {
            private Queue queue;
            private int position;

            internal CustomEnumerator(Queue queue)
            {
                Reset();
                this.queue = queue;
            }

            /*public T Current
            {
                get
                {
                    if (position < 0 || queue.IndexOfCurrentElement > queue)
                        throw new InvalidOperationException();

                    return array[indexOfCurrentElement];
                }
            }*/

            public void Dispose() { }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (indexOfCurrentElement < indexOfLastElement)
                {
                    indexOfCurrentElement++;
                    return indexOfCurrentElement < indexOfLastElement;
                }

                return false;
            }

            public void Reset()
            {
                
            }
        }

        #region Private fields
        private T[] array;
        private int indexOfLastElement;
        private int indexOfFirstElement;
        private int indexOfCurrentElement;
        #endregion
    }
}
