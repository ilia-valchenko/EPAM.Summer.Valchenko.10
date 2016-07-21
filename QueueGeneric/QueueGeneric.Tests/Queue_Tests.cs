using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using QueueGeneric;

namespace QueueGeneric.Tests
{
    [TestFixture]
    public class Queue_Tests
    {
        [TestCase(new int[] { 7, 12, 6, 9, 4, 0, 0, 3, 1 }, TestName = "CreateInt32Queue")]
        public void CreateQueueTest(int[] array)
        {
            var queue = new Queue<int>();

            foreach (int item in array)
                queue.Enqueue(item);

            Assert.IsTrue(array.SequenceEqual(queue.GetArrayOfQueueElements()));
        }

        [TestCase(new double[] {1.2, 3.69, 7.12}, TestName = "CreateDoubleQueue")]
        public void CreateQueueTest(double[] array)
        {
            var queue = new Queue<double>();

            foreach (double item in array)
                queue.Enqueue(item);

            Assert.IsTrue(array.SequenceEqual(queue.GetArrayOfQueueElements()));
        }

        [TestCase(new int[] {1,2,3,4,5}, TestName = "AfterDequeueOfTwoElements", ExpectedResult = new int[] {3,4,5})]
        public int[] DequeueTest(int[] array)
        {
            var queue = new Queue<int>();

            foreach (int item in array)
                queue.Enqueue(item);

            queue.Dequeue();
            queue.Dequeue();

            return queue.GetArrayOfQueueElements();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, TestName = "AfterEnqueueOfTwoElements", ExpectedResult = new int[] { 1, 2, 3, 4, 5 , 100, 200})]
        public int[] EnqueueTest(int[] array)
        {
            var queue = new Queue<int>();

            foreach (int item in array)
                queue.Enqueue(item);

            queue.Enqueue(100);
            queue.Enqueue(200);

            return queue.GetArrayOfQueueElements();
        }
    }
}
