using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSet
{
    /// <summary>
    /// This class represents a custom set which consists of unique elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Set<T> : IEqualityComparer<T> 
    {
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

        /*/// <summary>
        /// This constructor can specify the method of comparison using the comparer parameter.
        /// </summary>
        /// <param name="comparer">Comparer parameter.</param>
        public Set(IEqualityComparer<T> comparer) { }

        /// <summary>
        /// This constructor creates a set consisting of a collection element specifies the collection and uses the specified comparison method of comparer.
        /// </summary>
        /// <param name="collection">Collection of original objects.</param>
        /// <param name="comparer">Comparer parameter.</param>
        public Set(IEnumerable<T> collection, IEqualityComparer<T> comparer) { } */
        #endregion

        public void Add(T insertItem)
        {
            if(ReferenceEquals(insertItem, null))
                throw new ArgumentNullException(nameof(insertItem));

            if(!collection.Contains(insertItem))
                collection.Add(insertItem);
        }

        public void Delete(T deletedItem)
        {
            if(ReferenceEquals(deletedItem, null))
                throw new ArgumentNullException(nameof(deletedItem));

            if(!collection.Contains(deletedItem))
                throw new ArgumentException("Elemet which must be deleted not found");

            collection.Remove(deletedItem);
        }

        public void Intersect(IEnumerable<T> otherSet)
        {
            if(ReferenceEquals(otherSet, null))
                throw new ArgumentNullException(nameof(otherSet));

            foreach (T otherItem in otherSet)
                if (collection.Contains(otherItem))
                    collection.Remove(otherItem);
        }

        #region Implementation of IEqualityComparer
        public bool Equals(T x, T y)
        {
            if(ReferenceEquals(x, null))
                throw new ArgumentNullException(nameof(x));

            if (ReferenceEquals(y, null))
                throw new ArgumentNullException(nameof(y));

            return Object.Equals(x, y);
        }

        public int GetHashCode(T obj)
        {
            if(ReferenceEquals(obj, null))
                throw new ArgumentNullException(nameof(obj));

            return typeof(T).GetHashCode();
        } 
        #endregion

        private readonly List<T> collection;
    }
}
