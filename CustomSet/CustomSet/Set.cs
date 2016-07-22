using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CustomSet
{
    /// <summary>
    /// This class represents a custom set which consists of unique elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Set<T> : IEnumerable<T> where T : class, IEquatable<T>
    {
        #region Public fields and properties
        /// <summary>
        /// Count of elements in set.
        /// </summary>
        public int Count => collection.Count; 
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor which create an empty set.
        /// </summary>
        public Set() : this(new List<T>()) { }

        /// <summary>
        /// This constructor create the set which consists of element of collection.
        /// </summary>
        /// <param name="collection">Collection of original objects.</param>
        public Set(IEnumerable<T> collection)
        {
            if(ReferenceEquals(collection, null))
                throw new ArgumentNullException(nameof(collection));

            this.collection = new List<T>();

            foreach (T item in collection)
                Add(item);
        }
        #endregion

        #region Basic operations for set
        /// <summary>
        /// This method adds a new element to the set.
        /// </summary>
        /// <param name="insertItem">Element which must be insetred.</param>
        public void Add(T insertItem)
        {
            if (ReferenceEquals(insertItem, null))
                throw new ArgumentNullException(nameof(insertItem));

            if (!collection.Contains(insertItem))
                collection.Add(insertItem);
        }

        /// <summary>
        /// This method deletes given element from the set if it exists. If element doesn't exist then exception will be thrown.
        /// </summary>
        /// <param name="deletedItem">Element which must be deleted.</param>
        public void Delete(T deletedItem)
        {
            if (ReferenceEquals(deletedItem, null))
                throw new ArgumentNullException(nameof(deletedItem));

            if (!collection.Contains(deletedItem))
                throw new ArgumentException("Elemet which must be deleted not found");

            collection.Remove(deletedItem);
        }

        /// <summary>
        /// This method returns the result of intersection
        /// </summary>
        /// <param name="otherSet">Another set which  will be interseted to a current set.</param>
        public Set<T> Intersect(Set<T> otherSet)
        {
            if (ReferenceEquals(otherSet, null))
                throw new ArgumentNullException(nameof(otherSet));

            return new Set<T>((this.Union(otherSet)).Difference((this.Difference(otherSet)).Union(otherSet.Difference(this))));
        }

        /// <summary>
        /// This method returns the new set which represents intersection of two given sets.
        /// </summary>
        /// <param name="firstSet">The first set.</param>
        /// <param name="secondSet">The second set.</param>
        /// <returns>Returns the new set which represents intersection of two given sets.</returns>
        public static Set<T> Intersect(Set<T> firstSet, Set<T> secondSet)
        {
            if (ReferenceEquals(firstSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            if (ReferenceEquals(secondSet, null))
                throw new ArgumentNullException(nameof(secondSet));

            if (ReferenceEquals(firstSet, secondSet))
                return new Set<T>(firstSet);

            return firstSet.Intersect(secondSet);
        }

        /// <summary>
        /// This method returns the difference of two sets.
        /// </summary>
        /// <param name="other">The second set for difference.</param>
        /// <returns>The result of difference of current set and given another.</returns>
        public Set<T> Difference(Set<T> other)
        {
            if(ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            return new Set<T>(this.collection.Where(item => !other.collection.Contains(item)).ToList());
        }

        /// <summary>
        /// This method returns the new set which represents the difference between firstSet and secondSet.
        /// </summary>
        /// <param name="firstSet">First set.</param>
        /// <param name="secondSet">Second set.</param>
        /// <returns>New set which represents the result of difference.</returns>
        public static Set<T> Difference(Set<T> firstSet, Set<T> secondSet)
        {
            if(ReferenceEquals(firstSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            if(ReferenceEquals(secondSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            return firstSet.Difference(secondSet);
        }

        /// <summary>
        /// This method finds union of two sets.
        /// </summary>
        /// <param name="other">Another set.</param>
        /// <returns>Returns the new set which represents the result of union current and given another set.</returns>
        public Set<T> Union(Set<T> other)
        {
            if(ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            var result  = new List<T>(this.collection);

            foreach (T item in other.collection)
                if(!result.Contains(item))
                    result.Add(item);

            return new Set<T>(result);
        }

        /// <summary>
        /// This static method finds union of two sets.
        /// </summary>
        /// <param name="firstSet">The first set.</param>
        /// <param name="secondSet">The second set.</param>
        /// <returns>Returns the new set which represents the result of union current and given another set.</returns>
        public static Set<T> Union(Set<T> firstSet, Set<T> secondSet)
        {
            if(ReferenceEquals(firstSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            if(ReferenceEquals(secondSet, null))
                throw new ArgumentNullException(nameof(secondSet));

            return firstSet.Union(secondSet);
        }

        /// <summary>
        /// This method finds symmetric difference between two sets. 
        /// </summary>
        /// <param name="otherSet">Another set.</param>
        /// <returns>Returns a new set which represents the symmetric difference.</returns>
        public Set<T> SymmetricDifference(Set<T> otherSet)
        {
            if(ReferenceEquals(otherSet, null))
                throw new ArgumentNullException(nameof(otherSet));

            return new Set<T>((this.Union(otherSet)).Difference(this.Intersect(otherSet)));
        }

        public static Set<T> SymmetricDifference(Set<T> firstSet, Set<T> secondSet)
        {
            if(ReferenceEquals(firstSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            if(ReferenceEquals(secondSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            return firstSet.SymmetricDifference(secondSet);
        }
        #endregion

        #region IEnumerable inplementation
        /// <summary>
        /// This method returns enumerator for foreach loop.
        /// </summary>
        /// <returns>Returns enumerator.</returns>
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)collection).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion

        #region Some of ICollection methods
        /// <summary>
        /// This method returns elements of the set as an array.
        /// </summary>
        /// <returns>Returns elements of the set as an array.</returns>
        public T[] ToArray() => collection.ToArray(); 
        #endregion

        #region Private fields
        /// <summary>
        /// This List represents collection of elements which the set contains.
        /// </summary>
        private readonly List<T> collection; 
        #endregion
    }
}
